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
using PassportPDF.Tools.WinForm.Controllers;

namespace PassportPDF.Tools.WinForm.Views
{
    public interface IPassportPDFAppMainView
    {
        IWin32Window WindowInstance { get; } // Required in order to show new windows at the center of the parent one
        void SetController(IPassportPDFAppController controller);
        void ResetView();
        void LockView();
        void UnlockView();
        void Minimize();
        void ExitApplication();
        void LoadLabels();
        void LoadAvailableLanguages();
        void PopulateThreadsComboBox();
        void ChangeLanguage(string language);

        void AddWorker(int workerNumber);
        void NotifyWorkerProgress(int workerNumber, string message);
        void NotifyOperationError(string messagge);
        void NotifyOperationWarning(string message);
        void NotifyOperationCompletion(string message);
        void NotifyOperationsResult(string message);
        void RemoveWorker(int workerNumber);

        void PromptErrorMessage(string errorMessage, string caption);
        void PromptInformationMessage(string informationMessage, string caption);
        void PromptWarningMessage(string warningMessage, string caption);
        bool PromptCancelableWarningMessage(string warningMessage, string caption);
        bool PromptCancelableInformationMessage(string informationMessage, string caption);
        int WorkerItemCount { get; }
        int FileToBeProcessedCount { set; }
        int ProcessedFileCount { set; }
        string PassportStatus { set; }
        string SourcePath { get; set; }
        string DestinationFolder { get; set; }
        int SelectedThreadNumber { get; set; }

        void SetPauseButton();
        void SetResumeButton();
        void SetCancelationButton();
    }
}