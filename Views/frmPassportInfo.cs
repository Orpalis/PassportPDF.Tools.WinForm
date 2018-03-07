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
using PassportPDF.Tools.Framework.Models;
using PassportPDF.Tools.Framework.Utilities;
using PassportPDF.Tools.Framework;

namespace PassportPDF.Tools.WinForm.Views
{
    public partial class frmPassportInfo : Form
    {

        private readonly string _passportPDFAppID;

        public delegate void NewPassportRegisteredDelegate(PassportInfo newPassportInfo);

        public event NewPassportRegisteredDelegate OnNewPassportRegistered;

        public frmPassportInfo(string passportPDFAppID)
        {
            _passportPDFAppID = passportPDFAppID;
            InitializeComponent();
            LoadLocales();
        }

        private void LoadLocales()
        {
            this.Text = Globals.LabelsLocalizer.GetString("label_passportInfoTitle", FrameworkGlobals.ApplicationLanguage);
            rtbPassportInfoInstructions.Text = Globals.LabelsLocalizer.GetString("label_rtbPassportInfoInstructions", FrameworkGlobals.ApplicationLanguage);
            lbPassportInfoPassportId.Text = Globals.LabelsLocalizer.GetString("label_lbPassportInfoPassportId", FrameworkGlobals.ApplicationLanguage);
            lbPassportStatus.Text = Globals.LabelsLocalizer.GetString("label_lbPassportStatus", FrameworkGlobals.ApplicationLanguage);
            lbSubscriptionDate.Text = Globals.LabelsLocalizer.GetString("label_lbSubscriptionDate", FrameworkGlobals.ApplicationLanguage);
            lbUsedTokens.Text = Globals.LabelsLocalizer.GetString("label_lbUsedTokens", FrameworkGlobals.ApplicationLanguage);
        }

        public void LoadPassportInfo(PassportInfo passportInfo)
        {
            tbPassportInfoPassportId.Text = passportInfo.PassportNumber;
            tbPassportStatus.Text = FrameworkGlobals.MessagesLocalizer.GetString(passportInfo.IsActive ? "passport_status_active" : "passport_status_inactive", FrameworkGlobals.ApplicationLanguage);
            tbPassportSubscriptionDate.Text = passportInfo.SubscriptionDate.ToString();
            tbUsedTokens.Text = LogMessagesUtils.ReplaceMessageSequencesAndReferences(FrameworkGlobals.MessagesLocalizer.GetString("passport_status_remaining_tokens", FrameworkGlobals.ApplicationLanguage), remainingTokens: passportInfo.RemainingTokens, usedTokens: passportInfo.TokensUsed);
        }

        private void btEditPassportId_Click(object sender, EventArgs e)
        {
            PassportInfo passportInfo = frmRegisterPassport.PromptPassportRegistration(this, _passportPDFAppID, FrameworkGlobals.PassportInfo.PassportNumber);

            if (passportInfo != null)
            {
                // A new valid passport has been specified
                OnNewPassportRegistered(passportInfo);
                LoadPassportInfo(passportInfo);
            }
        }
    }
}
