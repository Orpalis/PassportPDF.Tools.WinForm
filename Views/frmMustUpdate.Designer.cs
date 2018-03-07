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

namespace PassportPDF.Tools.WinForm.Views
{
    partial class frmMustUpdate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtMustUpdate = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btUpdateNow = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMustUpdate
            // 
            this.txtMustUpdate.Location = new System.Drawing.Point(9, 12);
            this.txtMustUpdate.Name = "txtMustUpdate";
            this.txtMustUpdate.ReadOnly = true;
            this.txtMustUpdate.Size = new System.Drawing.Size(193, 89);
            this.txtMustUpdate.TabIndex = 0;
            this.txtMustUpdate.Text = "Sorry, the current version of the app is no longer supported by the PassportPDF A" +
    "PI. Please proceed to an update in order to continue using it.";
            // 
            // btUpdateNow
            // 
            this.btUpdateNow.Location = new System.Drawing.Point(9, 113);
            this.btUpdateNow.Name = "btUpdateNow";
            this.btUpdateNow.Size = new System.Drawing.Size(193, 23);
            this.btUpdateNow.TabIndex = 1;
            this.btUpdateNow.Text = "Download and install";
            this.btUpdateNow.UseVisualStyleBackColor = true;
            this.btUpdateNow.Click += new System.EventHandler(this.btUpdateNow_Click);
            // 
            // btExit
            // 
            this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btExit.Location = new System.Drawing.Point(9, 143);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(193, 23);
            this.btExit.TabIndex = 2;
            this.btExit.Text = "Exit";
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // frmMustUpdate
            // 
            this.AcceptButton = this.btUpdateNow;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btExit;
            this.ClientSize = new System.Drawing.Size(213, 177);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btUpdateNow);
            this.Controls.Add(this.txtMustUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMustUpdate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update required";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtMustUpdate;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btUpdateNow;
        private System.Windows.Forms.Button btExit;
    }
}