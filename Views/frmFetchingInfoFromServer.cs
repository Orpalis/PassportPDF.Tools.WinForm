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
using System.ComponentModel;
using System.Windows.Forms;
using PassportPDF.Api;
using PassportPDF.Model;
using PassportPDF.Tools.Framework.Utilities;
using PassportPDF.Tools.Framework.Models;
using PassportPDF.Tools.Framework;
using PassportPDF.Tools.Framework.Errors;
using PassportPDF.Tools.WinForm.Utilities;

namespace PassportPDF.Tools.WinForm.Views
{
    // todo: the messages used in this class must be localized in this library and not in PassportPDF.Tools.Framework.
    public partial class frmFetchingInfoFromServer : Form
    {
        private readonly BackgroundWorker _passportPdfRequestWorker;

        private string _passportToBeFetchedId;

        private string _appId;

        private Version _appVersion;

        private bool? _currentAppVersionIsSupported;

        private Exception _apiCallException;

        private PassportInfo _fetchedPassportInfo;

        private StringArrayResponse _getAvailableOCRLanguagesResponse;


        private frmFetchingInfoFromServer()
        {
            _passportPdfRequestWorker = new BackgroundWorker();
            _passportPdfRequestWorker.DoWork += BackgroundWorkerDoWork;
            _passportPdfRequestWorker.RunWorkerCompleted += BackgroundWorkerRunWorkCompleted;
            InitializeComponent();
        }


        public static bool? IsCurrentApplicationVersionSupported(string appId, Version currentVersion, IWin32Window owner = null)
        {
            using (frmFetchingInfoFromServer fetchWindow = new frmFetchingInfoFromServer())
            {
                fetchWindow._appId = appId;
                fetchWindow._appVersion = currentVersion;
                fetchWindow._passportPdfRequestWorker.RunWorkerAsync(BackgroundOperationType.CheckCurrentAppVersionIsSupported);
                fetchWindow.SetFormFetchingMessageAndShowUntilWorkCompletion(owner, FrameworkGlobals.MessagesLocalizer.GetString("message_fetching_app_minimum_version", FrameworkGlobals.ApplicationLanguage));

                return fetchWindow._currentAppVersionIsSupported;
            }
        }


        public static bool TryFetchPassportInfoFromPassportPDF(string passportId, out PassportInfo passportInfo, IWin32Window owner = null)
        {
            using (frmFetchingInfoFromServer fetchWindow = new frmFetchingInfoFromServer())
            {
                fetchWindow._passportToBeFetchedId = passportId;
                fetchWindow._passportPdfRequestWorker.RunWorkerAsync(BackgroundOperationType.FetchPassportInfo);
                fetchWindow.SetFormFetchingMessageAndShowUntilWorkCompletion(owner, FrameworkGlobals.MessagesLocalizer.GetString("message_fetching_passport_info", FrameworkGlobals.ApplicationLanguage));
                passportInfo = fetchWindow._fetchedPassportInfo;

                if (fetchWindow._apiCallException != null)
                {
                    // An exception occured when calling the API
                    DialogUtilities.ShowErrorMessage(LogMessagesUtils.ReplaceMessageSequencesAndReferences(FrameworkGlobals.MessagesLocalizer.GetString("message_passport_info_synchronization_failure", FrameworkGlobals.ApplicationLanguage),
                        additionalMessage: fetchWindow._apiCallException.Message), FrameworkGlobals.MessagesLocalizer.GetString("caption_error", FrameworkGlobals.ApplicationLanguage));
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }


        public static bool FetchConfigurationFromPassportPDF(string appId, IWin32Window owner = null)
        {
            using (frmFetchingInfoFromServer fetchWindow = new frmFetchingInfoFromServer())
            {
                fetchWindow._appId = appId;
                fetchWindow._passportPdfRequestWorker.RunWorkerAsync(BackgroundOperationType.FetchConfiguration);
                fetchWindow.SetFormFetchingMessageAndShowUntilWorkCompletion(owner, FrameworkGlobals.MessagesLocalizer.GetString("message_fetching_configuration", FrameworkGlobals.ApplicationLanguage));

                if (fetchWindow._apiCallException != null)
                {
                    // An exception occured when calling the API
                    DialogUtilities.ShowErrorMessage(LogMessagesUtils.ReplaceMessageSequencesAndReferences(FrameworkGlobals.MessagesLocalizer.GetString("message_configuration_fetching_failure", FrameworkGlobals.ApplicationLanguage),
                        additionalMessage: fetchWindow._apiCallException.Message), FrameworkGlobals.MessagesLocalizer.GetString("caption_error", FrameworkGlobals.ApplicationLanguage));
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }


        public static bool TryFetchAvailableOCRLanguagesFromPassportPDF(out string[] availableLanguages, IWin32Window owner = null)
        {
            using (frmFetchingInfoFromServer fetchWindow = new frmFetchingInfoFromServer())
            {
                fetchWindow._passportPdfRequestWorker.RunWorkerAsync(BackgroundOperationType.FetchOCRSupportedLanguages);
                fetchWindow.SetFormFetchingMessageAndShowUntilWorkCompletion(owner, FrameworkGlobals.MessagesLocalizer.GetString("message_fetching_ocr_languages", FrameworkGlobals.ApplicationLanguage));

                if (fetchWindow._apiCallException != null)
                {
                    // An exception occured when calling the API
                    DialogUtilities.ShowErrorMessage(LogMessagesUtils.ReplaceMessageSequencesAndReferences(FrameworkGlobals.MessagesLocalizer.GetString("message_fetching_ocr_languages_failure", FrameworkGlobals.ApplicationLanguage),
                        additionalMessage: fetchWindow._apiCallException.Message), FrameworkGlobals.MessagesLocalizer.GetString("caption_error", FrameworkGlobals.ApplicationLanguage));
                    availableLanguages = null;
                    return false;
                }
                else
                {
                    if (fetchWindow._getAvailableOCRLanguagesResponse.Error == null)
                    {
                        availableLanguages = fetchWindow._getAvailableOCRLanguagesResponse.Value.ToArray();
                        return true;
                    }
                    else
                    {
                        DialogUtilities.ShowErrorMessage(LogMessagesUtils.ReplaceMessageSequencesAndReferences(FrameworkGlobals.MessagesLocalizer.GetString("message_fetching_ocr_languages_failure", FrameworkGlobals.ApplicationLanguage),
                            additionalMessage: PassportPDFErrorUtilities.GetMessageFromResultCode(fetchWindow._getAvailableOCRLanguagesResponse.Error.Resultcode)), FrameworkGlobals.MessagesLocalizer.GetString("caption_error", FrameworkGlobals.ApplicationLanguage));
                        availableLanguages = null;
                        return false;
                    }
                }
            }
        }


        // Blocks the executing thread until the Background worker completion event is raised
        private void SetFormFetchingMessageAndShowUntilWorkCompletion(IWin32Window owner, string text)
        {
            toolTipFetchingInfoFromServer.SetToolTip(loaderImage, text);
            if (owner != null)
            {
                StartPosition = FormStartPosition.CenterParent;
                ShowDialog(owner);
            }
            else
            {
                StartPosition = FormStartPosition.CenterScreen;
                ShowDialog();
            }
        }


        private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundOperationType backgroundOperationType = (BackgroundOperationType)e.Argument;

            try
            {
                if (backgroundOperationType == BackgroundOperationType.CheckCurrentAppVersionIsSupported)
                {
                    _currentAppVersionIsSupported = PassportPDFApplicationUpdateUtilities.IsCurrentApplicationVersionSupported(_appId, _appVersion);
                }
                if (backgroundOperationType == BackgroundOperationType.FetchPassportInfo)
                {
                    PassportPDFPassport passportPdfPassport = PassportPDFRequestsUtilities.GetPassportInfo(_passportToBeFetchedId);
                    if (passportPdfPassport != null)
                    {
                        _fetchedPassportInfo = new PassportInfo
                        {
                            PassportNumber = passportPdfPassport.PassportId,
                            IsActive = passportPdfPassport.IsActive.Value,
                            SubscriptionDate = passportPdfPassport.SubscriptionDate.Value,
                            TokensUsed = passportPdfPassport.CurrentTokensUsed.Value,
                            RemainingTokens = passportPdfPassport.RemainingTokens.Value,
                        };
                    }
                }
                else if (backgroundOperationType == BackgroundOperationType.FetchConfiguration)
                {
                    FrameworkGlobals.FetchPassportPDFConfigurationEx(_appId);
                }
                else if (backgroundOperationType == BackgroundOperationType.FetchOCRSupportedLanguages)
                {
                    _getAvailableOCRLanguagesResponse = PassportPDFRequestsUtilities.GetAvailableOCRLanguages();
                }
            }
            catch (Exception exception)
            {
                _apiCallException = exception;
            }
        }


        private void BackgroundWorkerRunWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }


        private enum BackgroundOperationType
        {
            CheckCurrentAppVersionIsSupported,
            FetchPassportInfo,
            FetchConfiguration,
            FetchOCRSupportedLanguages,
        }
    }
}