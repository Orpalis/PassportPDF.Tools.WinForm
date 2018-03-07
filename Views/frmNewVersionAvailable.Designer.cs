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
    partial class frmNewVersionAvailable
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
            this.txtNewVersionAvailable = new System.Windows.Forms.RichTextBox();
            this.btUpdateNow = new System.Windows.Forms.Button();
            this.btIgnoreUpdate = new System.Windows.Forms.Button();
            this.chkAutomaticallycheckForUpdates = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtNewVersionAvailable
            // 
            this.txtNewVersionAvailable.Location = new System.Drawing.Point(13, 13);
            this.txtNewVersionAvailable.Name = "txtNewVersionAvailable";
            this.txtNewVersionAvailable.ReadOnly = true;
            this.txtNewVersionAvailable.Size = new System.Drawing.Size(267, 49);
            this.txtNewVersionAvailable.TabIndex = 0;
            this.txtNewVersionAvailable.Text = "#application_name version #version_number is available! ";
            // 
            // btUpdateNow
            // 
            this.btUpdateNow.Location = new System.Drawing.Point(13, 91);
            this.btUpdateNow.Name = "btUpdateNow";
            this.btUpdateNow.Size = new System.Drawing.Size(267, 23);
            this.btUpdateNow.TabIndex = 1;
            this.btUpdateNow.Text = "Download and install the update";
            this.btUpdateNow.UseVisualStyleBackColor = true;
            this.btUpdateNow.Click += new System.EventHandler(this.btUpdateNow_Click);
            // 
            // btIgnoreUpdate
            // 
            this.btIgnoreUpdate.Location = new System.Drawing.Point(12, 120);
            this.btIgnoreUpdate.Name = "btIgnoreUpdate";
            this.btIgnoreUpdate.Size = new System.Drawing.Size(268, 23);
            this.btIgnoreUpdate.TabIndex = 2;
            this.btIgnoreUpdate.Text = "Ignore for now";
            this.btIgnoreUpdate.UseVisualStyleBackColor = true;
            this.btIgnoreUpdate.Click += new System.EventHandler(this.btIgnoreUpdate_Click);
            // 
            // chkAutomaticallycheckForUpdates
            // 
            this.chkAutomaticallycheckForUpdates.AutoSize = true;
            this.chkAutomaticallycheckForUpdates.Location = new System.Drawing.Point(13, 68);
            this.chkAutomaticallycheckForUpdates.Name = "chkAutomaticallycheckForUpdates";
            this.chkAutomaticallycheckForUpdates.Size = new System.Drawing.Size(177, 17);
            this.chkAutomaticallycheckForUpdates.TabIndex = 3;
            this.chkAutomaticallycheckForUpdates.Text = "Automatically check for updates";
            this.chkAutomaticallycheckForUpdates.UseVisualStyleBackColor = true;
            // 
            // frmNewVersionAvailable
            // 
            this.AcceptButton = this.btUpdateNow;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 151);
            this.Controls.Add(this.chkAutomaticallycheckForUpdates);
            this.Controls.Add(this.btIgnoreUpdate);
            this.Controls.Add(this.btUpdateNow);
            this.Controls.Add(this.txtNewVersionAvailable);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(308, 190);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(308, 190);
            this.Name = "frmNewVersionAvailable";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New version available!";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmNewVersionAvailable_Closed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtNewVersionAvailable;
        private System.Windows.Forms.Button btUpdateNow;
        private System.Windows.Forms.Button btIgnoreUpdate;
        private System.Windows.Forms.CheckBox chkAutomaticallycheckForUpdates;
    }
}