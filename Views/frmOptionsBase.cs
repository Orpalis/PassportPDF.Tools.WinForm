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
using System.Drawing;
using PassportPDF.Tools.Framework;
using PassportPDF.Tools.Framework.Configuration;
using PassportPDF.Tools.WinForm.Properties;

namespace PassportPDF.Tools.WinForm.Views
{
    public partial class frmOptionsBase : Form
    {
        private frmOptionsBase()
        {
            InitializeComponent();
            btSelectLogFile.Image = Resources.edit;
        }


        public frmOptionsBase(Image bannerImage) : this()
        {
            pictureBoxBanner.Image = bannerImage;
        }


        public virtual void LoadLabels()
        {
            // Tab General
            tabGeneral.Text = Globals.LabelsLocalizer.GetString("label_tabGeneral", FrameworkGlobals.ApplicationLanguage);
            btApply.Text = Globals.LabelsLocalizer.GetString("label_btApply", FrameworkGlobals.ApplicationLanguage);
            btCancel.Text = Globals.LabelsLocalizer.GetString("label_btCancel", FrameworkGlobals.ApplicationLanguage);
            btReset.Text = Globals.LabelsLocalizer.GetString("label_btReset", FrameworkGlobals.ApplicationLanguage);
            chkAutomaticallycheckForUpdates.Text = Globals.LabelsLocalizer.GetString("label_chkAutomaticallyCheckForUpdates", FrameworkGlobals.ApplicationLanguage);
            chkSubfolders.Text = Globals.LabelsLocalizer.GetString("label_chkSubfolders", FrameworkGlobals.ApplicationLanguage);
            chkWarnSameInputOutputFolder.Text = Globals.LabelsLocalizer.GetString("label_chkWarnSameInputOutputFolder", FrameworkGlobals.ApplicationLanguage);

            // Tab Logs
            tabLogs.Text = Globals.LabelsLocalizer.GetString("label_tabLogs", FrameworkGlobals.ApplicationLanguage);
            chkTimestampLogs.Text = Globals.LabelsLocalizer.GetString("label_chkTimestampLogs", FrameworkGlobals.ApplicationLanguage);
            lbLogsFile.Text = Globals.LabelsLocalizer.GetString("label_lbLogsFile", FrameworkGlobals.ApplicationLanguage);
            chkExportLogs.Text = Globals.LabelsLocalizer.GetString("label_chkExportLogs", FrameworkGlobals.ApplicationLanguage);
        }


        public virtual void LoadConfiguration()
        {
            // Tab General
            chkSubfolders.Checked = FrameworkGlobals.ApplicationConfiguration.ProcessSubFolders;
            chkWarnSameInputOutputFolder.Checked = FrameworkGlobals.ApplicationConfiguration.WarnWhenSameInputOutputDirectory;
            chkAutomaticallycheckForUpdates.Checked = FrameworkGlobals.ApplicationConfiguration.AutomaticallycheckForUpdates;

            // Tab Logs
            chkTimestampLogs.Checked = FrameworkGlobals.ApplicationConfiguration.TimestampLogs;
            chkExportLogs.Checked = FrameworkGlobals.ApplicationConfiguration.ExportLogs;
            if (!(string.IsNullOrEmpty(FrameworkGlobals.ApplicationConfiguration.LogsPath)))
            {
                txtLogFile.Text = FrameworkGlobals.ApplicationConfiguration.LogsPath;
            }
            else
            {
                txtLogFile.Text = Globals.LabelsLocalizer.GetString("label_txtLogsFile", FrameworkGlobals.ApplicationLanguage);
            }
        }


        protected virtual void ApplyConfigurationChanges()
        {
            // Tab General
            FrameworkGlobals.ApplicationConfiguration.WarnWhenSameInputOutputDirectory = chkWarnSameInputOutputFolder.Checked;
            FrameworkGlobals.ApplicationConfiguration.ProcessSubFolders = chkSubfolders.Checked;
            FrameworkGlobals.ApplicationConfiguration.AutomaticallycheckForUpdates = chkAutomaticallycheckForUpdates.Checked;

            // Tab Logs
            FrameworkGlobals.ApplicationConfiguration.TimestampLogs = chkTimestampLogs.Checked;
            FrameworkGlobals.ApplicationConfiguration.ExportLogs = chkExportLogs.Checked;
            if (txtLogFile.Text != Globals.LabelsLocalizer.GetString("label_txtLogsFile", FrameworkGlobals.ApplicationLanguage))
            {
                FrameworkGlobals.ApplicationConfiguration.LogsPath = txtLogFile.Text;
            }
        }


        protected virtual void ResetDefaultConfiguration()
        {
            string applicationLanguage = FrameworkGlobals.ApplicationConfiguration.Language;
            FrameworkGlobals.ApplicationConfiguration = ConfigurationManager.ResetDefaultApplicationConfiguration();
            FrameworkGlobals.ApplicationConfiguration.Language = applicationLanguage; // Don't reset application language.
        }


        private void btReset_Click(object sender, EventArgs e)
        {
            ResetDefaultConfiguration();
        }


        private void btApply_click(object sender, EventArgs e)
        {
            ApplyConfigurationChanges();
        }


        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btSelectLogFile_Click(object sender, EventArgs e)
        {
            if (selectLogFileFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtLogFile.Text = selectLogFileFileDialog.FileName;
            }
        }
    }
}