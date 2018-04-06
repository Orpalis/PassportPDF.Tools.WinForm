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
using PassportPDF.Tools.Framework.Models;
using PassportPDF.Tools.Framework;

namespace PassportPDF.Tools.WinForm.Views
{
    public partial class frmRegisterPassport : Form
    {
        private frmRegisterPassport()
        {
            InitializeComponent();
            LoadLocales();
        }


        private void LoadLocales()
        {
            this.Text = Globals.LabelsLocalizer.GetString("label_frmRegisterPassportTitle", FrameworkGlobals.ApplicationLanguage);
            btCancel.Text = Globals.LabelsLocalizer.GetString("label_btCancel", FrameworkGlobals.ApplicationLanguage);
            btSave.Text = Globals.LabelsLocalizer.GetString("label_btSave", FrameworkGlobals.ApplicationLanguage);
            rtbRegisterPassportInstructions.Text = Globals.LabelsLocalizer.GetString("label_rtbRegisterPassportInstructions", FrameworkGlobals.ApplicationLanguage);
        }


        public string PassportKey
        {
            get
            {
                return txtPassport.Text.Trim();
            }
            set
            {
                txtPassport.Text = value.Trim();
            }
        }


        public static PassportInfo PromptPassportRegistration(IWin32Window owner, string passportPDFAppID, string originalValidPassportKey = null)
        {
            using (frmRegisterPassport frmRegisterPassport = new frmRegisterPassport())
            {
                if (originalValidPassportKey != null)
                {
                    frmRegisterPassport.PassportKey = originalValidPassportKey;
                }

                PassportInfo passportInfo = null;

                // Prompt user to register a new passport number, loop until he specifies a new valid passport number or close the prompted window
                while (passportInfo == null)
                {
                    DialogResult dialogResult = frmRegisterPassport.ShowDialog(owner);

                    if (dialogResult == DialogResult.No)
                    {
                        MessageBox.Show(FrameworkGlobals.MessagesLocalizer.GetString("message_must_specify_passport_key", FrameworkGlobals.ApplicationLanguage), FrameworkGlobals.MessagesLocalizer.GetString("caption_warning", FrameworkGlobals.ApplicationLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (originalValidPassportKey != null)
                        {
                            frmRegisterPassport.PassportKey = originalValidPassportKey;
                        }
                    }
                    else if (dialogResult == DialogResult.OK)
                    {
                        // A new passport number has been specified, check whether it is a valid one by fetching its info from the distant server
                        if (frmFetchingInfoFromServer.TryFetchPassportInfoFromPassportPDF(frmRegisterPassport.PassportKey, out passportInfo, owner) && passportInfo == null)
                        {
                            MessageBox.Show(FrameworkGlobals.MessagesLocalizer.GetString("message_invalid_passport_id", FrameworkGlobals.ApplicationLanguage), FrameworkGlobals.MessagesLocalizer.GetString("caption_warning", FrameworkGlobals.ApplicationLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (originalValidPassportKey != null)
                            {
                                frmRegisterPassport.PassportKey = originalValidPassportKey;
                            }
                        }
                    }
                    else if (dialogResult == DialogResult.Cancel)
                    {
                        return null;
                    }
                }

                // Register new passport number in the registry
                if (!LicensingUtilities.RegisterPassportIdInRegister(passportPDFAppID, frmRegisterPassport.PassportKey))
                {
                    MessageBox.Show(FrameworkGlobals.MessagesLocalizer.GetString("message_passport_key_registering_failure", FrameworkGlobals.ApplicationLanguage), FrameworkGlobals.MessagesLocalizer.GetString("caption_error", FrameworkGlobals.ApplicationLanguage), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return passportInfo;
            }
        }


        private void txtPassport_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PassportKey))
            {
                btSave.Enabled = false;
            }
            else
            {
                btSave.Enabled = true;
            }
        }


        private void btRegister_Click(object sender, EventArgs e)
        {
            PassportKey = txtPassport.Text;
            DialogResult = !string.IsNullOrEmpty(PassportKey) ? DialogResult.OK : DialogResult.No;
        }


        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        private void rtbRegisterPassportInstructions_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
