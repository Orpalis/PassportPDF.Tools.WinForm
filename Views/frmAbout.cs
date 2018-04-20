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

namespace PassportPDF.Tools.WinForm.Views
{
    public partial class frmAbout : Form
    {
        public frmAbout(Bitmap productLogo, string productName, string githubLink)
        {
            InitializeComponent();
            picProductLogo.Image = productLogo;
            Text = productName;
            LoadLocales();
            lkGithub.Text = githubLink;
        }

        private void LoadLocales()
        {
            btClose.Text = Globals.LabelsLocalizer.GetString("label_btCloseAbout", FrameworkGlobals.ApplicationLanguage);
            lbCopyright.Text = Globals.LabelsLocalizer.GetString("label_lbCopyright", FrameworkGlobals.ApplicationLanguage);
            lbBasedOn.Text = Globals.LabelsLocalizer.GetString("label_lbBasedOn", FrameworkGlobals.ApplicationLanguage);
            lkPassportPdfWebsite.Text = Globals.LabelsLocalizer.GetString("label_lkPassportPdfWebsite", FrameworkGlobals.ApplicationLanguage);
            lkOrpalisWebsite.Text = Globals.LabelsLocalizer.GetString("label_lkOrpalisWebsite", FrameworkGlobals.ApplicationLanguage);
            lbSourceCode.Text = Globals.LabelsLocalizer.GetString("label_lbSourceCode", FrameworkGlobals.ApplicationLanguage);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void lkPassportPdfWebsite_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.passportpdf.com");
        }

        private void btOrpalisWebsite_Clock(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.orpalis.com");
        }

        private void lkGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(lkGithub.Text);
        }
    }
}
