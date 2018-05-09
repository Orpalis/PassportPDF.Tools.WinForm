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

using System.Windows.Forms;

namespace PassportPDF.Tools.WinForm.Utilities
{
    public static class DialogUtilities
    {
        public static void ShowInformationMessage(string informationMessage, string caption)
        {
            MessageBox.Show(informationMessage, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public static void ShowWarningMessage(string warningMessage, string caption)
        {
            MessageBox.Show(warningMessage, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        public static void ShowErrorMessage(string errorMessage, string caption)
        {
            MessageBox.Show(errorMessage, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        public static bool PromptCancellableWarningMessage(string warningMessage, string caption)
        {
            DialogResult dialogResult = MessageBox.Show(warningMessage, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            return dialogResult != DialogResult.Cancel;
        }


        public static bool PromptCancellableInformationMessage(string informationMessage, string caption)
        {
            DialogResult dialogResult = MessageBox.Show(informationMessage, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            return dialogResult != DialogResult.Cancel;
        }
    }
}
