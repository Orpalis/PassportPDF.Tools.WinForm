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
        public frmUpdateInProgress(string productName)
        {
            InitializeComponent();
            LoadLocales(productName);
        }


        private void LoadLocales(string productName)
        {
            Text = Globals.LabelsLocalizer.GetString("label_frmUpdateInProgress", FrameworkGlobals.ApplicationLanguage);
            txtUpdating.Text = LogMessagesUtils.ReplaceMessageSequencesAndReferences(Globals.LabelsLocalizer.GetString("label_txtUpdating", FrameworkGlobals.ApplicationLanguage), applicationName: productName);
        }


        public void OnUpdateDownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBarUpdate.Value = e.ProgressPercentage;
        }


        public void OnUpdateDownloadCompletion(object sender, AsyncCompletedEventArgs e)
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
    }
}
