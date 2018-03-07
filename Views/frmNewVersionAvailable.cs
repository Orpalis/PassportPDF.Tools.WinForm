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
using System.Windows.Forms;
using PassportPDF.Tools.Framework.Utilities;
using PassportPDF.Tools.Framework;

namespace PassportPDF.Tools.WinForm.Views
{
    public partial class frmNewVersionAvailable : Form
    {
        private frmNewVersionAvailable(string newVersionNumber, string productName)
        {
            InitializeComponent();
            LoadLocales(newVersionNumber, productName);
            chkAutomaticallycheckForUpdates.Checked = FrameworkGlobals.ApplicationConfiguration.AutomaticallycheckForUpdates;
        }


        private void LoadLocales(string newVersionNumber, string productName)
        {
            this.Text = PassportPDF.Tools.WinForm.Globals.LabelsLocalizer.GetString("label_frmNewVersionAvailable", FrameworkGlobals.ApplicationLanguage);
            btIgnoreUpdate.Text = PassportPDF.Tools.WinForm.Globals.LabelsLocalizer.GetString("label_btIgnoreUpdate", FrameworkGlobals.ApplicationLanguage);
            btUpdateNow.Text = PassportPDF.Tools.WinForm.Globals.LabelsLocalizer.GetString("label_btUpdateNow", FrameworkGlobals.ApplicationLanguage);
            txtNewVersionAvailable.Text = LogMessagesUtils.ReplaceMessageSequencesAndReferences(Globals.LabelsLocalizer.GetString("label_txtNewVersionAvailable", FrameworkGlobals.ApplicationLanguage), applicationName: productName, appVersionNumber: newVersionNumber);
            chkAutomaticallycheckForUpdates.Text = PassportPDF.Tools.WinForm.Globals.LabelsLocalizer.GetString("label_chkAutomaticallyCheckForUpdates", FrameworkGlobals.ApplicationLanguage);
        }


        public static bool PromptApplicationUpdate(IWin32Window parentForm, string newVersionNumber, string productName)
        {
            using (frmNewVersionAvailable frmNewVersionAvailable = new frmNewVersionAvailable(newVersionNumber, productName))
            {
                DialogResult dialogResult = frmNewVersionAvailable.ShowDialog(parentForm);
                return dialogResult == DialogResult.OK;
            }
        }


        private void btUpdateNow_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }


        private void btIgnoreUpdate_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Ignore;
        }


        private void frmNewVersionAvailable_Closed(object sender, FormClosedEventArgs e)
        {
            FrameworkGlobals.ApplicationConfiguration.AutomaticallycheckForUpdates = chkAutomaticallycheckForUpdates.Checked;
        }
    }
}
