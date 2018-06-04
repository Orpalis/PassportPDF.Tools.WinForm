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
using PassportPDF.Tools.Framework;

namespace PassportPDF.Tools.WinForm.Views
{
    public partial class frmMustUpdate : Form
    {
        public frmMustUpdate()
        {
            InitializeComponent();
            LoadLocales();
        }


        private void LoadLocales()
        {
            Text = Globals.LabelsLocalizer.GetString("label_frmMustUpdate", FrameworkGlobals.ApplicationLanguage);
            txtMustUpdate.Text = Globals.LabelsLocalizer.GetString("label_txtMustUpdate", FrameworkGlobals.ApplicationLanguage);
            btExit.Text = Globals.LabelsLocalizer.GetString("label_btExit", FrameworkGlobals.ApplicationLanguage);
            btUpdateNow.Text = Globals.LabelsLocalizer.GetString("label_btUpdateNow", FrameworkGlobals.ApplicationLanguage);
        }


        private void btUpdateNow_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }


        public static bool PromptRequiredUpdate(IWin32Window parent = null)
        {
            using (frmMustUpdate frmMustUpdate = new frmMustUpdate())
            {
                DialogResult dialogResult = frmMustUpdate.ShowDialog(parent);

                if (dialogResult == DialogResult.OK)
                {
                    // Proceed to update
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
