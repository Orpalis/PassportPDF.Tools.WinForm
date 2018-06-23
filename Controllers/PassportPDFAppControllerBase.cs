/**********************************************************************
 * Project:                  PassportPDF.Tools.WinForm
 * Authors:                 - Evan Carrère.
 *                          - Loïc Carrère.
 *
 * (C) Copyright 2018, ORPALIS.
 ** Licensed under the Apache License, Version 2.0 (the "License");
 ** you may not use this file except in compliance with the License.
 ** You may obtain a copy of the License at
 ** http://www.apache.org/licenses/LICENSE-2.0
 ** Unless required by applicable law or agreed to in writing, software
 ** distributed under the License is distributed on an "AS IS" BASIS,
 ** WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 ** See the License for the specific language governing permissions and
 ** limitations under the License.
 *
 **********************************************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using PassportPDF.Tools.Framework;
using PassportPDF.Tools.Framework.Models;
using PassportPDF.Tools.Framework.Utilities;
using PassportPDF.Tools.Framework.Business;
using PassportPDF.Tools.Framework.Configuration;
using PassportPDF.Tools.WinForm.Models;
using PassportPDF.Tools.WinForm.Views;
using PassportPDF.Tools.WinForm.Utilities;

namespace PassportPDF.Tools.WinForm.Controllers
{
    public abstract class PassportPDFAppControllerBase : IPassportPDFAppController
    {
        private readonly OperationsManager _operationsManager;

        protected readonly PassportPDFDesktopAppInformation _appInfo;
        protected readonly OperationsStats _operationsStats;
        protected readonly Stopwatch _stopwatch;
        protected IPassportPDFAppMainView _view;
        protected OperationsStatus _operationsStatus;
        protected string[] _supportedInputFileExtensions;

        public PassportPDFAppControllerBase(PassportPDFDesktopAppInformation appInfo)
        {
            _appInfo = appInfo;
            _stopwatch = new Stopwatch();
            _operationsStats = new OperationsStats();
            _operationsManager = new OperationsManager();
            // Subscribe from the operations manager events
            _operationsManager.UploadOperationStartEventHandler += OnUploadStart;
            _operationsManager.FileOperationStartEventHandler += OnFileOperationsStart;
            _operationsManager.DownloadOperationStartEventHandler += OnDownloadStart;
            _operationsManager.FileChunkProcessingProgressEventHandler += OnFileProcessingChunkProgress;
            _operationsManager.FileOperationsSuccesfullyCompletedEventHandler += OnFileOperationsCompletion;
            _operationsManager.RemainingTokensUpdateEventHandler += OnRemainingTokensNumberUpdated;
            _operationsManager.WarningEventHandler += OnOperationWarning;
            _operationsManager.ErrorEventHandler += OnFileOperationError;
            _operationsManager.WorkerWorkCompletionEventHandler += OnWorkerWorkCompletion;
            _operationsManager.OperationsCompletionEventHandler += OnOperationsCompletion;
            _operationsManager.WorkerPauseEventHandler += OnWorkerWorkPause;
        }

        #region IPDFReducerController implementation

        public PassportPDFDesktopAppInformation AppInfo
        {
            get
            {
                return _appInfo;
            }
        }


        public OperationsStatus OperationsStatus
        {
            get
            {
                return _operationsStatus;
            }
        }


        public void SetView(IPassportPDFAppMainView view)
        {
            _view = view;
        }


        public void OnApplicationLaunch()
        {
            if (!EnsureCurrentAppVersionIsSupported() || !InitializeAppConfiguration())
            {
                _view.ExitApplication();
                return;
            }

            _supportedInputFileExtensions = AppInfo.InputFilesType == PassportPDFDesktopAppInformation.AcceptedInputFilesType.Document ?
                FrameworkGlobals.PassportPDFConfiguration.PdfApiSupportedFileFormatExtensions : FrameworkGlobals.PassportPDFConfiguration.ImageApiSupportedFileFormatExtensions;

            _view.LoadLabels();
            _view.PopulateThreadsComboBox();
            _view.LoadAvailableLanguages();
            _view.SourcePath = FrameworkGlobals.ApplicationConfiguration.InputPath;
            _view.DestinationFolder = FrameworkGlobals.ApplicationConfiguration.OutputPath;
            _view.SelectedThreadNumber = FrameworkGlobals.ApplicationConfiguration.ThreadCount;
            _view.UnlockView();
        }


        public void OnMainViewShown()
        {
            if (!EnsurePassportRegistrationAndRetrievePassportInfo())
            {
                _view.ExitApplication();
                return;
            }

            if (_appInfo.AutoRun)
            {
                OnStartOperationsRequested();
            }
            else if (FrameworkGlobals.ApplicationConfiguration.AutomaticallycheckForUpdates)
            {
                CheckForApplicationUpdate();
            }
        }


        public void OnSelectedThreadCountChanged()
        {
            FrameworkGlobals.ApplicationConfiguration.ThreadCount = _view.SelectedThreadNumber;
        }


        public void OnLanguageChangeRequested(string language)
        {
            FrameworkGlobals.ApplicationConfiguration.Language = language;
            _view.ChangeLanguage(language);
            _view.PassportStatus = LogMessagesUtils.ReplaceMessageSequencesAndReferences(FrameworkGlobals.MessagesLocalizer.GetString("label_remaining_tokens", FrameworkGlobals.ApplicationLanguage), remainingTokens: FrameworkGlobals.PassportInfo.RemainingTokens);
        }


        public void OnStartOperationsRequested()
        {
            HandleFileOperationsPreperationResult(FileToProcessCollector.ProceedToFileCollection(_view.SourcePath, _view.DestinationFolder, _supportedInputFileExtensions));
        }


        public void OnDragAndDrop(string[] data)
        {
            HandleFileOperationsPreperationResult(FileToProcessCollector.ProceedToFileCollection(data, _view.DestinationFolder, _supportedInputFileExtensions, false));
        }


        public void OnStopOperationsRequested()
        {
            _operationsStatus = OperationsStatus.Canceling;
            _view.SetCancelationButton();
            _operationsManager.AbortWork();
        }


        public void OnWorkResumeRequested()
        {
            _operationsManager.ResumeWork();
            _operationsStatus = OperationsStatus.Running;
            _view.SetPauseButton();
        }


        public void OnWorkPauseRequested()
        {
            if (_operationsManager.PauseWork())
            {
                _operationsStatus = OperationsStatus.Paused;
                _view.SetResumeButton();
            }
        }


        public void OnAppUpdateAvailable(string newVersionNumber)
        {
            if (frmNewVersionAvailable.PromptApplicationUpdate(_view.WindowInstance, newVersionNumber, _appInfo.ProductName))
            {
                bool updateSuccess = DownloadLatestVersion(out string downloadedUpdatedAppFilePath);

                if (updateSuccess)
                {
                    if (_view.PromptCancellableInformationMessage(FrameworkGlobals.MessagesLocalizer.GetString("app_update_download_success_message", FrameworkGlobals.ApplicationLanguage), FrameworkGlobals.MessagesLocalizer.GetString("caption_information", FrameworkGlobals.ApplicationLanguage)))
                    {
                        PassportPDFApplicationUpdateUtilities.StartUpdatedAppInstallation(downloadedUpdatedAppFilePath, _appInfo.AppExecutableName);
                        _view.ExitApplication();
                    }
                }
            }
        }


        void IPassportPDFAppController.OnOptionsFormOpeningRequested()
        {
            OnOptionsFormOpeningRequested();
        }



        public void OnApplicationClosed()
        {
            if (FrameworkGlobals.ApplicationConfiguration != null)
            {
                HandleApplicationClosing();
            }
        }
        #endregion //IPDFReducerControllerImplementation

        #region Operations events handlers


        private void OnUploadStart(int workerNumber, string fileName, int retries)
        {
            _view.NotifyWorkerProgress(workerNumber, LogMessagesUtils.GetFileUploadingStartText(fileName, retries));
        }


        private void OnFileOperationsStart(int workerNumber, string fileName, int retries)
        {
            _view.NotifyWorkerProgress(workerNumber, LogMessagesUtils.GetFileOperationsStartText(fileName, retries));
        }


        private void OnDownloadStart(int workerNumber, string fileName, int retries)
        {
            _view.NotifyWorkerProgress(workerNumber, LogMessagesUtils.GetFileDownloadingStartText(fileName, retries));
        }


        private void OnFileProcessingChunkProgress(int workerNumber, string fileName, string pageRange, int pageCount, int retries)
        {
            _view.NotifyWorkerProgress(workerNumber, LogMessagesUtils.GetFileChunkProcessingProgressText(fileName, pageRange, pageCount, retries));
        }


        private void OnRemainingTokensNumberUpdated(long remainingTokens)
        {
            if (FrameworkGlobals.PassportInfo.RemainingTokens > remainingTokens)
            {
                FrameworkGlobals.PassportInfo.RemainingTokens = remainingTokens;
                string updatedPassportStatus = FrameworkGlobals.MessagesLocalizer.GetString("label_remaining_tokens", FrameworkGlobals.ApplicationLanguage);
                _view.PassportStatus = LogMessagesUtils.ReplaceMessageSequencesAndReferences(updatedPassportStatus, remainingTokens: remainingTokens);
            }
        }


        private void OnOperationWarning(string warningMessage)
        {
            if (FrameworkGlobals.ApplicationConfiguration.TimestampLogs)
            {
                warningMessage = LogMessagesUtils.TimeStampLogMessage(warningMessage);
            }

            _view.NotifyOperationWarning(warningMessage);

            if (!string.IsNullOrEmpty(FrameworkGlobals.ApplicationConfiguration.LogsPath) && FrameworkGlobals.ApplicationConfiguration.ExportLogs)
            {
                // Update logs file
                FrameworkGlobals.LogsManager.LogMessage(warningMessage);
            }
        }


        private void OnFileOperationError(string errorMessage)
        {
            _operationsStats.UnsuccesfullyProcessedFileCount += 1;
            _operationsStats.ProcessedFileCount += 1;
            _view.ProcessedFileCount = _operationsStats.ProcessedFileCount;

            if (FrameworkGlobals.ApplicationConfiguration.TimestampLogs)
            {
                errorMessage = LogMessagesUtils.TimeStampLogMessage(errorMessage);
            }

            _view.NotifyOperationError(errorMessage);

            if (!string.IsNullOrEmpty(FrameworkGlobals.ApplicationConfiguration.LogsPath) && FrameworkGlobals.ApplicationConfiguration.ExportLogs)
            {
                // Update logs file
                FrameworkGlobals.LogsManager.LogMessage(errorMessage);
            }
        }


        private void OnWorkerWorkPause(int workerNumber)
        {
            _view.NotifyWorkerProgress(workerNumber, LogMessagesUtils.GetWorkerIdleStateText());
        }
        #endregion

        #region Private methods

        private bool EnsureCurrentAppVersionIsSupported()
        {
            bool? isCurrentAppVersionSupported = frmFetchingInfoFromServer.IsCurrentApplicationVersionSupported(_appInfo.AppID, _appInfo.AppVersion);

            if (isCurrentAppVersionSupported == false)
            {
                // The update is mendatory.
                ForceApplicationUpdate();
                return false;
            }
            else if (isCurrentAppVersionSupported == null)
            {
                _view.ShowErrorMessage(FrameworkGlobals.MessagesLocalizer.GetString("message_failed_to_reach_server", FrameworkGlobals.ApplicationLanguage), FrameworkGlobals.MessagesLocalizer.GetString("caption_error", FrameworkGlobals.ApplicationLanguage));
                return false;
            }
            else
            {
                return true;
            }
        }


        private void CheckForApplicationUpdate()
        {
            if (PassportPDFApplicationUpdateUtilities.IsNewVersionAvailable(_appInfo.AppID, _appInfo.AppVersion, out string latestVersionNumber) == true)
            {
                // Non-mendatory update available.
                OnAppUpdateAvailable(latestVersionNumber);
            }
        }


        private void ForceApplicationUpdate()
        {
            if (frmMustUpdate.PromptRequiredUpdate(_view.WindowInstance))
            {
                bool updateSuccess = DownloadLatestVersion(out string downloadedUpdatedAppFilePath);

                if (!updateSuccess)
                {
                    _view.ShowErrorMessage(FrameworkGlobals.MessagesLocalizer.GetString("app_update_failure_message", FrameworkGlobals.ApplicationLanguage), FrameworkGlobals.MessagesLocalizer.GetString("caption_error", FrameworkGlobals.ApplicationLanguage));
                }
                else
                {
                    if (_view.PromptCancellableInformationMessage(FrameworkGlobals.MessagesLocalizer.GetString("app_update_download_success_message", FrameworkGlobals.ApplicationLanguage), FrameworkGlobals.MessagesLocalizer.GetString("caption_information", FrameworkGlobals.ApplicationLanguage)))
                    {
                        PassportPDFApplicationUpdateUtilities.StartUpdatedAppInstallation(downloadedUpdatedAppFilePath, _appInfo.AppExecutableName);
                    }
                }
            }

            _view.ExitApplication();
        }


        private bool DownloadLatestVersion(out string downloadedUpdatedAppFilePath)
        {
            bool downloadSuccess;

            // Download the latest version of the app.
            using (frmUpdateInProgress frmUpdateInProgress = new frmUpdateInProgress(_appInfo.ProductName))
            {
                downloadedUpdatedAppFilePath = PassportPDFApplicationUpdateUtilities.DownloadAppLatestVersion(_appInfo.AppID, frmUpdateInProgress.OnUpdateDownloadCompletion, frmUpdateInProgress.OnUpdateDownloadProgress);

                if (!string.IsNullOrEmpty(downloadedUpdatedAppFilePath))
                {
                    // The download has succesfully started
                    downloadSuccess = frmUpdateInProgress.ShowDialog() == DialogResult.OK;
                }
                else
                {
                    downloadSuccess = false;
                }

                return downloadSuccess;
            }
        }


        private bool EnsurePassportRegistrationAndRetrievePassportInfo()
        {
            if (!LicensingUtilities.IsPassportKeyRegistered(_appInfo.AppID) // No passport number found in registry
                || !frmFetchingInfoFromServer.TryFetchPassportInfoFromPassportPDF(LicensingUtilities.GetRegisterPassportId(_appInfo.AppID), out PassportInfo passportInfo, _view.WindowInstance) // Server failed to be reached
                || passportInfo == null) // No passport corresponding to the passport number could be fetched
            {
                if ((passportInfo = frmRegisterPassport.PromptPassportRegistration(_view.WindowInstance, _appInfo.AppID)) == null)
                {
                    return false;
                }
            }

            FrameworkGlobals.PassportInfo = passportInfo;
            _view.PassportStatus = LogMessagesUtils.ReplaceMessageSequencesAndReferences(FrameworkGlobals.MessagesLocalizer.GetString("label_remaining_tokens", FrameworkGlobals.ApplicationLanguage), remainingTokens: passportInfo.RemainingTokens);

            return true;
        }


        private void SetupLogs()
        {
            if (FrameworkGlobals.ApplicationConfiguration.ExportLogs)
            {
                FrameworkGlobals.LogsManager.Reset(FrameworkGlobals.ApplicationConfiguration.LogsPath);
            }
        }


        private void NotifyViewOfWorkersCreation(int workerCount)
        {
            for (int workerNumber = 1; workerNumber <= workerCount; workerNumber++)
            {
                _view.AddWorker(workerNumber);
                _view.NotifyWorkerProgress(workerNumber, LogMessagesUtils.GetWorkerIdleStateText());
            }
        }


        private void HandleFileOperationsPreperationResult(FileToProcessCollector.CollectionOperationResult fileOperationsPreparationResult)
        {
            bool mustLaunchOperations;

            switch (fileOperationsPreparationResult.ResultType)
            {
                case FileToProcessCollector.OperationsPreparationResultType.UnfullfiledWithError:
                    _view.ShowErrorMessage(fileOperationsPreparationResult.ResultMessage, FrameworkGlobals.MessagesLocalizer.GetString("caption_error", FrameworkGlobals.ApplicationLanguage));
                    mustLaunchOperations = false;
                    break;

                case FileToProcessCollector.OperationsPreparationResultType.Unfullfilled:
                    _view.ShowInformationMessage(fileOperationsPreparationResult.ResultMessage, FrameworkGlobals.MessagesLocalizer.GetString("caption_information", FrameworkGlobals.ApplicationLanguage));
                    mustLaunchOperations = false;
                    break;

                case FileToProcessCollector.OperationsPreparationResultType.SuccessWithWarning:
                    mustLaunchOperations = _view.PromptCancellableWarningMessage(fileOperationsPreparationResult.ResultMessage, FrameworkGlobals.MessagesLocalizer.GetString("caption_warning", FrameworkGlobals.ApplicationLanguage));
                    break;

                default:
                    mustLaunchOperations = true;
                    break;
            }

            if (mustLaunchOperations)
            {
                LaunchOperations(fileOperationsPreparationResult.CollectedFiles, _view.DestinationFolder);
            }
        }


        private void LaunchOperations(List<FileToProcess> filesToProcess, string destinationFolder)
        {
            _view.LockView();
            _view.ResetView();
            _view.FileToBeProcessedCount = filesToProcess.Count;

            ResetStats();
            SetupLogs();

            int threadsToLaunchCount = _view.SelectedThreadNumber > filesToProcess.Count ? filesToProcess.Count : _view.SelectedThreadNumber;

            NotifyViewOfWorkersCreation(threadsToLaunchCount);

            // Feed workers and start work
            _operationsManager.Feed(filesToProcess);
            _operationsManager.Start(threadsToLaunchCount, _view.DestinationFolder, FrameworkGlobals.ApplicationConfiguration.FileProductionRules, GetOperationWorkflow(), FrameworkGlobals.PassportInfo.PassportNumber);
            _operationsStatus = OperationsStatus.Running;
        }


        private void ResetStats()
        {
            _operationsStats.ProcessedFileCount = 0;
            _operationsStats.SuccesfullyProcessedFileCount = 0;
            _operationsStats.UnsuccesfullyProcessedFileCount = 0;
            _operationsStats.TotalInputSize = 0;
            _operationsStats.TotalOutputSize = 0;
            _operationsStats.ReductionRatio = 0;
            _operationsStats.FileConvertedToPDFCount = 0;
            _stopwatch.Restart();
        }
        #endregion

        #region Virtual methods

        protected virtual bool InitializeAppConfiguration()
        {
            try
            {
                FrameworkGlobals.ApplicationConfiguration = (ApplicationConfiguration)ConfigurationManager.InitializeConfigurationInstanceEx(_appInfo.ConfigurationFilePath, typeof(ApplicationConfiguration));
            }
            catch (Exception)
            {
                _view.ShowErrorMessage(FrameworkGlobals.MessagesLocalizer.GetString("readConfigurationFailure", FrameworkGlobals.ApplicationLanguage), FrameworkGlobals.MessagesLocalizer.GetString("readConfigurationFailureTitle", FrameworkGlobals.ApplicationLanguage));
                FrameworkGlobals.ApplicationConfiguration = ConfigurationManager.ResetDefaultApplicationConfiguration();
            }

            if (!FrameworkGlobals.MessagesLocalizer.IsSupportedLanguage(FrameworkGlobals.ApplicationLanguage))
            {
                FrameworkGlobals.ApplicationConfiguration.Language = FrameworkGlobals.MessagesLocalizer.DefaultLanguage;
            }

            // Fetch the configuration information from the PassportPDF API
            if (!frmFetchingInfoFromServer.FetchConfigurationFromPassportPDF(_appInfo.AppID))
            {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(FrameworkGlobals.ApplicationLanguage))
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(FrameworkGlobals.ApplicationLanguage);
            }

            return true;
        }


        protected virtual OperationsWorkflow GetOperationWorkflow()
        {
            throw new NotImplementedException();
        }


        protected virtual void OnWorkerWorkCompletion(int workerNumber)
        {
            _view.RemoveWorker(workerNumber);
        }


        protected virtual void OnOperationsCompletion()
        {
            _stopwatch.Stop();
            _operationsStatus = OperationsStatus.Idle;

            if (FrameworkGlobals.LogsManager.Error != null)
            {
                _view.NotifyOperationError(LogMessagesUtils.ReplaceMessageSequencesAndReferences(FrameworkGlobals.MessagesLocalizer.GetString("message_logs_exportation_failure", FrameworkGlobals.ApplicationConfiguration.Language), additionalMessage: FrameworkGlobals.LogsManager.Error.Message));
            }
        }


        protected virtual void HandleApplicationClosing()
        {
            FrameworkGlobals.ApplicationConfiguration.InputPath = _view.SourcePath;
            FrameworkGlobals.ApplicationConfiguration.OutputPath = _view.DestinationFolder;
            FrameworkGlobals.ApplicationConfiguration.ThreadCount = _view.SelectedThreadNumber;
        }


        protected virtual void OnFileOperationsCompletion(FileOperationsResult fileOperationsResult)
        {
            _operationsStats.SuccesfullyProcessedFileCount += 1;
            _operationsStats.ProcessedFileCount += 1;
            _view.ProcessedFileCount = _operationsStats.ProcessedFileCount;
        }


        protected virtual void OnOptionsFormOpeningRequested()
        {

        }
        #endregion
    }
}
