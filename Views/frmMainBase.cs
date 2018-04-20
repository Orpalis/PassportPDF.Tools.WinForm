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
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using PassportPDF.Tools.Framework;
using PassportPDF.Tools.Framework.Utilities;
using PassportPDF.Tools.Framework.Models;
using PassportPDF.Tools.WinForm.Models;
using PassportPDF.Tools.WinForm.Controllers;

namespace PassportPDF.Tools.WinForm.Views
{
    public partial class frmMainBase : IPassportPDFAppMainView
    {
        #region Fields

        private IPassportPDFAppController _controller;
        private string _cmdRunText;

        private readonly Dictionary<ToolStripMenuItem, string> _languageMenuItems = new Dictionary<ToolStripMenuItem, string>();
        private ToolStripMenuItem _currentlySelectedLanguageItem;
        #endregion //Fields

        #region Startup

        protected frmMainBase()
        {
            InitializeComponent();
            // Associate each event handler to its appropriate delegate, so that they can be accessed from different threads
            _updateWindowTitle = UpdateWindowTitle;
            _operationProgressEventHandler = UpdateThreadProgressLogs;
            _reduceCompletionEventHandler = UpdateThreadStatusLogs;
            _reduceErrorEventHandler = UpdateErrorsLogs;
            _reduceWarningEventHandler = UpdateWarningLogs;
            _showOperationsResultHandler = ShowOperationsResult;
            _addWorkerItem = AddWorker;
            _removeWorkerItem = RemoveWorker;
            _initializeProgressBar = InitializeProgressBar;
            _updateProgressBar = UpdateProgressBarValue;
            _populateThreadsComboBoxHandler = PopulateThreadsComboBox;
            _languageChangeHandler = ChangeLanguage;
            _loadAvailableLanguagesHandler = LoadAvailableLanguages;
            _promptCancellableInformationMessageEventHandler = PromptCancellableInformationMessage;
            _promptCancellableWarningMessageEventHandler = PromptCancellableWarningMessage;
            _promptErrorMessageHandler = PromptErrorMessage;
            _promptWarningMessageHandler = PromptWarningMessage;
            _promptInformationEventHandler = PromptInformationMessage;
            _resetViewHandler = ResetView;
            _loadLabelsHandler = LoadLabels;
            _lockViewHandler = LockView;
            _unlockUIHandler = UnlockView;
            _exitApplicationHandler = ExitApplication;
            _setCancelationButtonHandler = SetCancelationButton;
            _setPauseButtonHandler = SetButtonIconPause;
            _setResumeButtonHandler = SetButtonIconResume;
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            _controller?.OnApplicationLaunch();
        }


        private void frmMain_Shown(object sender, EventArgs e)
        {
            _controller?.OnMainViewShown();
        }

        #endregion //Startup

        #region UI Update delegates

        // UI Update delegate.
        private delegate void ChangeUILanguageDelegate(string language);
        private delegate void UpdateProgressBarDelegate(int value);
        private delegate void UpdateUITextDelegate(string text);
        private delegate void UpdateUIProgressDelegate(int workerNumber, string text);
        private delegate void UpdateWorkerListDelegate(int threadNumber);

        private delegate void PromptMessageDelegate(string message, string caption);
        private delegate bool PromptCancellableMessageDelegate(string message, string caption);

        private delegate void ViewStateDelegate();

        private readonly UpdateProgressBarDelegate _initializeProgressBar;
        private readonly UpdateProgressBarDelegate _updateProgressBar;
        private readonly UpdateWorkerListDelegate _addWorkerItem;
        private readonly UpdateWorkerListDelegate _removeWorkerItem;

        private readonly UpdateUITextDelegate _updateWindowTitle;
        private readonly UpdateUITextDelegate _reduceErrorEventHandler;
        private readonly UpdateUITextDelegate _reduceWarningEventHandler;
        private readonly UpdateUITextDelegate _reduceCompletionEventHandler;
        private readonly UpdateUITextDelegate _showOperationsResultHandler;


        private readonly PromptMessageDelegate _promptInformationEventHandler;
        private readonly PromptMessageDelegate _promptErrorMessageHandler;
        private readonly PromptMessageDelegate _promptWarningMessageHandler;
        private readonly PromptCancellableMessageDelegate _promptCancellableWarningMessageEventHandler;
        private readonly PromptCancellableMessageDelegate _promptCancellableInformationMessageEventHandler;

        private readonly UpdateUIProgressDelegate _operationProgressEventHandler;

        private readonly ChangeUILanguageDelegate _languageChangeHandler;

        private readonly ViewStateDelegate _lockViewHandler;
        private readonly ViewStateDelegate _unlockUIHandler;
        private readonly ViewStateDelegate _loadLabelsHandler;
        private readonly ViewStateDelegate _resetViewHandler;
        private readonly ViewStateDelegate _exitApplicationHandler;
        private readonly ViewStateDelegate _loadAvailableLanguagesHandler;
        private readonly ViewStateDelegate _populateThreadsComboBoxHandler;

        private readonly ViewStateDelegate _setCancelationButtonHandler;
        private readonly ViewStateDelegate _setPauseButtonHandler;
        private readonly ViewStateDelegate _setResumeButtonHandler;

        #endregion

        #region IPDFReducerView implementation

        IWin32Window IPassportPDFAppMainView.WindowInstance
        {
            get
            {
                return this;
            }
        }


        void IPassportPDFAppMainView.SetController(IPassportPDFAppController controller)
        {
            _controller = controller;
            logoBitmap.BackgroundImage = _controller.AppInfo.AppLogo;
            Icon = _controller.AppInfo.AppIcon;
            Text = _controller.AppInfo.ProductName;
        }


        void IPassportPDFAppMainView.LoadLabels()
        {
            if (InvokeRequired)
            {
                Invoke(_loadLabelsHandler);
            }
            else
            {
                LoadLabels();
            }
        }


        void IPassportPDFAppMainView.PopulateThreadsComboBox()
        {
            if (InvokeRequired)
            {
                Invoke(_populateThreadsComboBoxHandler);
            }
            else
            {
                PopulateThreadsComboBox();
            }
        }


        void IPassportPDFAppMainView.Minimize()
        {
            WindowState = FormWindowState.Minimized;
        }


        void IPassportPDFAppMainView.NotifyWorkerProgress(int workerNumber, string progressMessage)
        {
            if (InvokeRequired)
            {
                Invoke(_operationProgressEventHandler, workerNumber, progressMessage);
            }
            else
            {
                UpdateThreadProgressLogs(workerNumber, progressMessage);
            }
        }


        void IPassportPDFAppMainView.NotifyOperationError(string errorMessage)
        {
            if (InvokeRequired)
            {
                Invoke(_reduceErrorEventHandler, errorMessage);
            }
            else
            {
                UpdateErrorsLogs(errorMessage);
            }
        }


        void IPassportPDFAppMainView.NotifyOperationWarning(string warningMessage)
        {
            if (InvokeRequired)
            {
                Invoke(_reduceWarningEventHandler, warningMessage);
            }
            else
            {
                UpdateWarningLogs(warningMessage);
            }
        }


        void IPassportPDFAppMainView.NotifyOperationCompletion(string text)
        {
            if (InvokeRequired)
            {
                Invoke(_reduceCompletionEventHandler, text);
            }
            else
            {
                UpdateThreadStatusLogs(text);
            }
        }


        void IPassportPDFAppMainView.AddWorker(int workerNumber)
        {
            if (InvokeRequired)
            {
                Invoke(_addWorkerItem, workerNumber);
            }
            else
            {
                AddWorker(workerNumber);
            }
        }


        void IPassportPDFAppMainView.RemoveWorker(int workerNumber)
        {
            if (InvokeRequired)
            {
                Invoke(_removeWorkerItem, workerNumber);
            }
            else
            {
                RemoveWorker(workerNumber);
            }
        }


        void IPassportPDFAppMainView.NotifyOperationsResult(string workResultMessage)
        {
            if (InvokeRequired)
            {
                Invoke(_showOperationsResultHandler, workResultMessage);
            }
            else
            {
                ShowOperationsResult(workResultMessage);
            }
        }


        void IPassportPDFAppMainView.PromptInformationMessage(string informationMessage, string caption)
        {
            if (InvokeRequired)
            {
                Invoke(_promptInformationEventHandler, informationMessage, caption);
            }
            else
            {
                PromptInformationMessage(informationMessage, caption);
            }
        }


        void IPassportPDFAppMainView.PromptWarningMessage(string warningMessage, string caption)
        {
            if (InvokeRequired)
            {
                Invoke(_promptWarningMessageHandler, warningMessage, caption);
            }
            else
            {
                PromptWarningMessage(warningMessage, caption);
            }
        }

        public bool PromptCancelableWarningMessage(string warningMessage, string caption)
        {
            if (InvokeRequired)
            {
                return (bool)Invoke(_promptCancellableWarningMessageEventHandler, warningMessage, caption);
            }
            else
            {
                return PromptCancellableWarningMessage(warningMessage, caption);
            }
        }


        bool IPassportPDFAppMainView.PromptCancelableInformationMessage(string informationMessage, string caption)
        {
            if (InvokeRequired)
            {
                return (bool)Invoke(_promptCancellableInformationMessageEventHandler, informationMessage, caption);
            }
            else
            {
                return PromptCancellableInformationMessage(informationMessage, caption);
            }
        }


        void IPassportPDFAppMainView.PromptErrorMessage(string errorMessage, string caption)
        {
            if (InvokeRequired)
            {
                Invoke(_promptErrorMessageHandler, errorMessage, caption);
            }
            else
            {
                PromptErrorMessage(errorMessage, caption);
            }
        }


        void IPassportPDFAppMainView.LockView()
        {
            if (InvokeRequired)
            {
                Invoke(_lockViewHandler);
            }
            else
            {
                LockView();
            }
        }


        void IPassportPDFAppMainView.UnlockView()
        {
            if (InvokeRequired)
            {
                Invoke(_unlockUIHandler);
            }
            else
            {
                UnlockView();
            }
        }


        void IPassportPDFAppMainView.ResetView()
        {
            if (InvokeRequired)
            {
                Invoke(_resetViewHandler);
            }
            else
            {
                ResetView();
            }
        }


        void IPassportPDFAppMainView.ExitApplication()
        {
            if (InvokeRequired)
            {
                Invoke(_exitApplicationHandler);
            }
            else
            {
                ExitApplication();
            }
        }


        void IPassportPDFAppMainView.LoadAvailableLanguages()
        {
            if (InvokeRequired)
            {
                Invoke(_loadAvailableLanguagesHandler);
            }
            else
            {
                LoadAvailableLanguages();
            }
        }


        void IPassportPDFAppMainView.ChangeLanguage(string language)
        {
            if (InvokeRequired)
            {
                Invoke(_languageChangeHandler, language);
            }
            else
            {
                ChangeLanguage(language);
            }
        }


        void IPassportPDFAppMainView.SetPauseButton()
        {
            if (InvokeRequired)
            {
                Invoke(_setPauseButtonHandler);
            }
            else
            {
                SetButtonIconPause();
            }
        }


        void IPassportPDFAppMainView.SetResumeButton()
        {
            if (InvokeRequired)
            {
                Invoke(_setResumeButtonHandler);
            }
            else
            {
                SetButtonIconResume();
            }
        }


        void IPassportPDFAppMainView.SetCancelationButton()
        {
            if (InvokeRequired)
            {
                Invoke(_setCancelationButtonHandler);
            }
            else
            {
                SetCancelationButton();
            }
        }

        #endregion

        #region View update methods

        protected virtual void LoadLabels()
        {
            aboutToolStripMenuItem.Text = Globals.LabelsLocalizer.GetString("label_aboutToolStripMenuItem", FrameworkGlobals.ApplicationLanguage);
            cmdRun.Text = Globals.LabelsLocalizer.GetString("label_cmdRun", FrameworkGlobals.ApplicationLanguage);
            communityForumsToolStripMenuItem.Text = Globals.LabelsLocalizer.GetString("label_communityForumsToolStripMenuItem", FrameworkGlobals.ApplicationLanguage);
            exitToolStripMenuItem.Text = Globals.LabelsLocalizer.GetString("label_exitToolStripMenuItem", FrameworkGlobals.ApplicationLanguage);
            facebookToolStripMenuItem.Text = Globals.LabelsLocalizer.GetString("label_facebookToolStripMenuItem", FrameworkGlobals.ApplicationLanguage);
            fileToolStripMenuItem.Text = Globals.LabelsLocalizer.GetString("label_fileToolStripMenuItem", FrameworkGlobals.ApplicationLanguage);
            helpToolStripMenuItem.Text = Globals.LabelsLocalizer.GetString("label_helpToolStripMenuItem", FrameworkGlobals.ApplicationLanguage);
            languageToolStripMenuItem.Text = Globals.LabelsLocalizer.GetString("label_languageToolStripMenuItem", FrameworkGlobals.ApplicationLanguage);
            checkForLatestUpdateToolStripMenuItem.Text = Globals.LabelsLocalizer.GetString("label_checkForLatestUpdateToolStripMenuItem", FrameworkGlobals.ApplicationLanguage);
            tabErrors.Text = Globals.LabelsLocalizer.GetString("label_tabErrors", FrameworkGlobals.ApplicationLanguage);
            TabProcessLogs.Text = Globals.LabelsLocalizer.GetString("label_TabProcessLogs", FrameworkGlobals.ApplicationLanguage);
            TabStatus.Text = Globals.LabelsLocalizer.GetString("label_TabStatus", FrameworkGlobals.ApplicationLanguage);
            TabWarnings.Text = Globals.LabelsLocalizer.GetString("label_TabWarnings", FrameworkGlobals.ApplicationLanguage);
            optionsToolStripMenuItem.Text = Globals.LabelsLocalizer.GetString("label_optionsToolStripMenuItem", FrameworkGlobals.ApplicationLanguage);
            passportToolStripMenuItem.Text = Globals.LabelsLocalizer.GetString("label_passportToolStripMenuItem", FrameworkGlobals.ApplicationLanguage);
            lbThreads.Text = Globals.LabelsLocalizer.GetString("label_lbThreads", FrameworkGlobals.ApplicationLanguage);
            lbSrcFolder.Text = Globals.LabelsLocalizer.GetString("label_lbSrcFolder", FrameworkGlobals.ApplicationLanguage);
            lbDstFolder.Text = Globals.LabelsLocalizer.GetString("label_lbDstFolder", FrameworkGlobals.ApplicationLanguage);
            cmdBrowseDest.Text = Globals.LabelsLocalizer.GetString("label_cmdBrowseDest", FrameworkGlobals.ApplicationLanguage);
        }


        private void UpdatePassportInfo(PassportInfo updatedPassportInfo)
        {
            FrameworkGlobals.PassportInfo = updatedPassportInfo;
            string updatedPassportStatus = LogMessagesUtils.ReplaceMessageSequencesAndReferences(FrameworkGlobals.MessagesLocalizer.GetString("label_remaining_tokens", FrameworkGlobals.ApplicationLanguage), remainingTokens: updatedPassportInfo.RemainingTokens);
            PassportStatus = updatedPassportStatus;
        }


        private void LoadAvailableLanguages()
        {
            IReadOnlyList<string> availableLanguages = Globals.LabelsLocalizer.GetLocalizedLanguages();

            foreach (string language in availableLanguages)
            {
                string isoLanguageName = Orpalis.Globals.Localization.OrpalisLocalizer.GetISOLanguageName(language);

                // Create the item for the available language for the user to be able to pick it.
                ToolStripMenuItem languageItem = new ToolStripMenuItem(isoLanguageName)
                {
                    Text = isoLanguageName
                };
                languageItem.Click += languageToolStripMenuItem_Click;

                if (language == FrameworkGlobals.ApplicationLanguage)
                {
                    _currentlySelectedLanguageItem = languageItem;
                    _currentlySelectedLanguageItem.Checked = true;
                    languageItem.Checked = true;
                }

                // Add the language to the language drop down list.
                languageToolStripMenuItem.DropDownItems.Add(languageItem);

                // Associate the ToolStripMenuItem with the appropriate language string.
                _languageMenuItems.Add(languageItem, language);
            }
        }


        private void ChangeLanguage(string language)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(language);

            LoadLabels();
            PopulateThreadsComboBox();
        }

        private void PopulateThreadsComboBox()
        {
            cboMaxProcesses.Items.Clear();
            int counter = 1;
            while (counter <= FrameworkGlobals.PassportPDFConfiguration.SuggestedMaxClientThreads)
            {
                string cboText = counter == 1 ? FrameworkGlobals.MessagesLocalizer.GetString("singleProcess", FrameworkGlobals.ApplicationLanguage) :
                    FrameworkGlobals.MessagesLocalizer.GetString("multiProcess", FrameworkGlobals.ApplicationLanguage);
                cboMaxProcesses.Items.Add(counter + " - " + cboText);
                counter++;
            }
            if (FrameworkGlobals.PassportPDFConfiguration.SuggestedMaxClientThreads > 0)
            {
                cboMaxProcesses.SelectedIndex = Math.Min(FrameworkGlobals.ApplicationConfiguration.ThreadCount, FrameworkGlobals.PassportPDFConfiguration.SuggestedMaxClientThreads) - 1;
            }
        }


        private void UpdateThreadProgressLogs(int workerNumber, string updatedCaption)
        {
            for (int index = 0; index <= lstThreads.Items.Count - 1; index++)
            {
                WorkerItem item = ((WorkerItem)(lstThreads.Items[index]));
                if (item.WorkerNumber == workerNumber)
                {
                    item.Caption = "Thread " + workerNumber + ": " + updatedCaption;
                    lstThreads.Items[index] = item;
                    break;
                }
            }
        }


        private void UpdateThreadStatusLogs(string text)
        {
            lstProcessLog.Items.Add(text);
            TabProcessLogs.Text = Globals.LabelsLocalizer.GetString("label_TabProcessLogs", FrameworkGlobals.ApplicationLanguage) + " (" + lstProcessLog.Items.Count + ")";
        }


        private void UpdateWarningLogs(string text)
        {
            lstWarnLog.Items.Add(text);
            TabWarnings.Text = Globals.LabelsLocalizer.GetString("label_TabWarnings", FrameworkGlobals.ApplicationLanguage) + " (" + lstWarnLog.Items.Count + ")";
        }


        private void UpdateErrorsLogs(string text)
        {
            lstErrLog.Items.Add(text);
            tabErrors.Text = Globals.LabelsLocalizer.GetString("label_tabErrors", FrameworkGlobals.ApplicationLanguage) + " (" + lstErrLog.Items.Count + ")";
        }


        private void InitializeProgressBar(int maximum)
        {
            prgProgress.Minimum = 0;
            prgProgress.Value = 0;
            prgProgress.Maximum = maximum;
        }


        private void UpdateProgressBarValue(int updatedValue)
        {
            prgProgress.Value = updatedValue;
        }


        private void UpdateWindowTitle(string passportStatus)
        {
            this.Text = _controller.AppInfo.ProductName;
            this.Text += passportStatus;
        }



        private void SetButtonIconPause()
        {
            cmdPause.Text = Globals.LabelsLocalizer.GetString("unicode_symbol_pause", FrameworkGlobals.ApplicationLanguage);
        }


        private void SetButtonIconResume()
        {
            cmdPause.Text = Globals.LabelsLocalizer.GetString("unicode_symbol_play", FrameworkGlobals.ApplicationLanguage);
        }


        private void SetCancelationButton()
        {
            cmdRun.Text = Globals.LabelsLocalizer.GetString("label_cancellation", FrameworkGlobals.ApplicationLanguage);
        }


        private void AddWorker(int workerNumber)
        {
            lstThreads.Items.Add(new WorkerItem(workerNumber));
        }


        private void RemoveWorker(int workerItemNumber)
        {
            for (int index = lstThreads.Items.Count - 1; index >= 0; index += -1)
            {
                WorkerItem item = (WorkerItem)lstThreads.Items[index];
                if (item.WorkerNumber == workerItemNumber)
                {
                    lstThreads.Items.RemoveAt(index);
                    break;
                }
            }
        }


        private void ShowOperationsResult(string resultStatus)
        {
            prgProgress.Visible = false;
            lbStatus.Visible = true;
            lbStatus.Text = resultStatus;
        }


        protected virtual void LockView()
        {
            cmdRun.Visible = true;
            _cmdRunText = cmdRun.Text;
            cmdRun.Text = Globals.LabelsLocalizer.GetString("label_stop", FrameworkGlobals.ApplicationLanguage);
            cmdBrowseDest.Enabled = false;
            cmdBrowseFiles.Enabled = false;
            cmdBrowseFolders.Enabled = false;
            txtSourcePath.ReadOnly = true;
            txtDestFolder.ReadOnly = true;
            cboMaxProcesses.Enabled = false;
            menuStrip1.Enabled = false;
            logoBitmap.Visible = false;
            cmdPause.Visible = true;
            cmdPause.Text = Globals.LabelsLocalizer.GetString("unicode_symbol_pause", FrameworkGlobals.ApplicationLanguage);
        }


        private void ResetView()
        {
            lstThreads.Items.Clear();
            lstWarnLog.Items.Clear();
            lstErrLog.Items.Clear();
            lstProcessLog.Items.Clear();
            prgProgress.Visible = true;
            lbStatus.Visible = false;
        }


        protected virtual void UnlockView()
        {
            if (_cmdRunText != null) cmdRun.Text = _cmdRunText;
            menuStrip1.Enabled = true;
            cboMaxProcesses.Enabled = true;
            cmdRun.Visible = true;
            cmdBrowseDest.Enabled = true;
            cmdBrowseFiles.Enabled = true;
            cmdBrowseFolders.Enabled = true;
            txtSourcePath.ReadOnly = false;
            txtDestFolder.ReadOnly = false;
            cmdPause.Visible = false;
            logoBitmap.Visible = true;
        }


        private void ExitApplication()
        {
            Application.Exit();
        }


        private void PromptInformationMessage(string informationMessage, string caption)
        {
            MessageBox.Show(informationMessage, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private bool PromptCancellableWarningMessage(string warningMessage, string caption)
        {
            DialogResult dialogResult = MessageBox.Show(warningMessage, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            return dialogResult != DialogResult.Cancel;
        }


        private bool PromptCancellableInformationMessage(string informationMessage, string caption)
        {
            DialogResult dialogResult = MessageBox.Show(informationMessage, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            return dialogResult != DialogResult.Cancel;
        }


        private void PromptErrorMessage(string errorMessage, string caption)
        {
            MessageBox.Show(errorMessage, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void PromptWarningMessage(string warningMessage, string caption)
        {
            MessageBox.Show(warningMessage, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion //View update methods

        #region Event handlers

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_controller.OperationsStatus == OperationsStatus.Running)
            {
                if ((MessageBox.Show(FrameworkGlobals.MessagesLocalizer.GetString("message_operations_still_running", FrameworkGlobals.ApplicationLanguage),
                    FrameworkGlobals.MessagesLocalizer.GetString("caption_operations_still_running", FrameworkGlobals.ApplicationLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes))
                {
                    e.Cancel = true;
                }
            }
        }


        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            _controller.OnApplicationClosed();
        }


        private void cmdBrowseFiles_Click(object sender, EventArgs e)
        {
            fileSelectDlg.Filter = "Any|*.*";

            if (fileSelectDlg.ShowDialog() == DialogResult.OK)
            {
                StringBuilder fileNames = new StringBuilder();
                int count = fileSelectDlg.FileNames.Length;

                for (int i = 0; i < count; i++)
                {
                    if (i > 0)
                    {
                        fileNames.Append("|");
                    }

                    fileNames.Append(fileSelectDlg.FileNames[i]);
                }

                txtSourcePath.Text = fileNames.ToString();
            }
        }


        private void cmdBrowseFolders_Click(object sender, EventArgs e)
        {
            FldBrowse.SelectedPath = Directory.GetCurrentDirectory();
            if (FldBrowse.ShowDialog() == DialogResult.OK)
            {
                txtSourcePath.Text = FldBrowse.SelectedPath;
            }
        }


        private void cmdBrowseDest_Click(object sender, EventArgs e)
        {
            FldBrowse.SelectedPath = Directory.GetCurrentDirectory();
            if (FldBrowse.ShowDialog() == DialogResult.OK)
            {
                txtDestFolder.Text = FldBrowse.SelectedPath;
            }
        }


        private void cboMaxProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controller.OnSelectedThreadCountChanged();
        }


        private void cmdRun_Click(object sender, EventArgs e)
        {
            if (_controller.OperationsStatus == OperationsStatus.Idle)
            {
                // Start requested
                _controller.OnStartOperationsRequested();
            }
            else
            {
                // Cancelation requested
                _controller.OnStopOperationsRequested();
            }
        }


        private void cmdPause_Click(object sender, EventArgs e)
        {
            if (_controller.OperationsStatus == OperationsStatus.Paused)
            {
                _controller.OnWorkResumeRequested();
            }
            else if (_controller.OperationsStatus == OperationsStatus.Running)
            {
                _controller.OnWorkPauseRequested();
            }
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.OnOptionsFormOpeningRequested();
        }


        private void frmMain_DragEnter(object sender, DragEventArgs e)
        {
            if (_controller.OperationsStatus == OperationsStatus.Idle && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void frmMain_DragDrop(object sender, DragEventArgs e)
        {
            if (_controller.OperationsStatus == OperationsStatus.Idle)
            {
                string[] data = (string[])e.Data.GetData(DataFormats.FileDrop);
                _controller.OnDragAndDrop(data);
            }
        }


        private void communityForumsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://forums.orpalis.com/");
        }


        private void facebookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/ORPALIS");
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmAbout about = new frmAbout(_controller.AppInfo.AppLogo, _controller.AppInfo.ProductName, _controller.AppInfo.AppSourceCodeUrl))
            {
                about.ShowDialog(this);
            }
        }


        private void languageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedLanguageMenuItem = (ToolStripMenuItem)sender;

            // Uncheck previously selected language then check and save newly selected one.
            _currentlySelectedLanguageItem.Checked = false;
            _currentlySelectedLanguageItem = clickedLanguageMenuItem;
            _currentlySelectedLanguageItem.Checked = true;
            _controller.OnLanguageChangeRequested(_languageMenuItems[clickedLanguageMenuItem]);
        }


        private void passportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmFetchingInfoFromServer.TryFetchPassportInfoFromPassportPDF(FrameworkGlobals.PassportInfo.PassportNumber, out PassportInfo updatedPassportInfo, this) && updatedPassportInfo != null)
            {
                FrameworkGlobals.PassportInfo = updatedPassportInfo;

                using (frmPassportInfo frmPassportInfo = new frmPassportInfo(_controller.AppInfo.AppID))
                {
                    frmPassportInfo.OnNewPassportRegistered += UpdatePassportInfo;
                    frmPassportInfo.LoadPassportInfo(FrameworkGlobals.PassportInfo);
                    frmPassportInfo.ShowDialog(this);
                }
            }
        }


        private void checkForLastUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool? newVersionAvailable = PassportPDFApplicationUpdateUtilities.IsNewVersionAvailable(_controller.AppInfo.AppID, _controller.AppInfo.AppVersion, out string latestVersionNumber);

            if (newVersionAvailable == true)
            {
                _controller.OnAppUpdateAvailable(latestVersionNumber);
            }
            else if (newVersionAvailable == false)
            {
                PromptInformationMessage(LogMessagesUtils.ReplaceMessageSequencesAndReferences(FrameworkGlobals.MessagesLocalizer.GetString("message_already_up_to_date", FrameworkGlobals.ApplicationLanguage), applicationName: _controller.AppInfo.ProductName), FrameworkGlobals.MessagesLocalizer.GetString("caption_information", FrameworkGlobals.ApplicationLanguage));
            }
            else
            {
                PromptErrorMessage(LogMessagesUtils.ReplaceMessageSequencesAndReferences(FrameworkGlobals.MessagesLocalizer.GetString("message_failed_to_retrieve_latest_version", FrameworkGlobals.ApplicationLanguage), applicationName: _controller.AppInfo.ProductName), FrameworkGlobals.MessagesLocalizer.GetString("caption_error", FrameworkGlobals.ApplicationLanguage));
            }
        }


        private void frmMain_Resize(object sender, EventArgs e)
        {
            FrameworkGlobals.ApplicationConfiguration.MinimizedWindow = WindowState == FormWindowState.Minimized;
            Refresh();
        }

        #endregion //Control interactions event handlers

        #region Control properties accessors

        public int SelectedThreadNumber
        {
            get
            {
                return cboMaxProcesses.SelectedIndex + 1;
            }
            set
            {
                cboMaxProcesses.SelectedIndex = Math.Min(value - 1, FrameworkGlobals.PassportPDFConfiguration.SuggestedMaxClientThreads - 1);
            }
        }


        public int WorkerItemCount
        {
            get
            {
                return lstThreads.Items.Count;
            }
        }


        public string SourcePath
        {
            get
            {
                return txtSourcePath.Text;
            }
            set
            {
                txtSourcePath.Text = value;
            }
        }


        public string DestinationFolder
        {
            get
            {
                return txtDestFolder.Text;
            }
            set
            {
                txtDestFolder.Text = value;
            }
        }


        public int FileToBeProcessedCount
        {
            set
            {
                if (InvokeRequired)
                {
                    Invoke(_initializeProgressBar, value);
                }
                else
                {
                    InitializeProgressBar(value);
                }
            }
        }


        public string PassportStatus
        {
            set
            {
                if (InvokeRequired)
                {
                    Invoke(_updateWindowTitle, value);
                }
                else
                {
                    UpdateWindowTitle(value);
                }
            }
        }


        public int ProcessedFileCount
        {
            set
            {
                if (InvokeRequired)
                {
                    Invoke(_updateProgressBar, value);
                }
                else
                {
                    UpdateProgressBarValue(value);
                }
            }
        }

        #endregion
    }
}