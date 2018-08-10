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

using System.ComponentModel;
using System.Net;
using System.Windows.Forms;
using PassportPDF.Tools.Framework.Utilities;
using PassportPDF.Tools.Framework;

namespace PassportPDF.Tools.WinForm.Views
{
    public partial class frmUpdateInProgress : Form
    {
        private readonly BackgroundWorker _backgroundWorker;

        private string _downloadedUpdateFilePath;

        private delegate void ProgressBarUpdateDelegate(int percentage);

        private ProgressBarUpdateDelegate _progressBarUpdateHandler;

        public frmUpdateInProgress(string productName)
        {
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += BackgroundWorkerDoWork;
            _backgroundWorker.RunWorkerCompleted += BackgroundWorkerWorkCompleted;
            _progressBarUpdateHandler = UpdateProgressBar;
            InitializeComponent();
            LoadLocales(productName);
        }


        private void LoadLocales(string productName)
        {
            Text = Globals.LabelsLocalizer.GetString("label_frmUpdateInProgress", FrameworkGlobals.ApplicationLanguage);
            txtUpdating.Text = LogMessagesUtils.ReplaceMessageSequencesAndReferences(Globals.LabelsLocalizer.GetString("label_txtUpdating", FrameworkGlobals.ApplicationLanguage), applicationName: productName);
        }


        private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            _downloadedUpdateFilePath = PassportPDFApplicationUpdateUtilities.DownloadAppLatestVersion((string)e.Argument, OnUpdateDownloadCompletion, OnUpdateDownloadProgress);
        }


        private void BackgroundWorkerWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_downloadedUpdateFilePath == null)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }


        private void UpdateProgressBar(int percentage)
        {
            progressBarUpdate.Value = percentage;
        }


        private void OnUpdateDownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(_progressBarUpdateHandler, e.ProgressPercentage);
            }
            else
            {
                UpdateProgressBar(e.ProgressPercentage);
            }
        }


        private void OnUpdateDownloadCompletion(object sender, AsyncCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Abort;
            }
        }


        public static bool DownloadLatestAppVersion(string productName, string appId, IWin32Window owner, out string downloadedUpdateFilePath)
        {
            using (frmUpdateInProgress frmUpdateInProgress = new frmUpdateInProgress(productName))
            {
                frmUpdateInProgress._backgroundWorker.RunWorkerAsync(appId);
                frmUpdateInProgress.ShowDialog(owner);
                downloadedUpdateFilePath = frmUpdateInProgress._downloadedUpdateFilePath;

                return frmUpdateInProgress.DialogResult == DialogResult.OK;
            }
        }
    }
}
