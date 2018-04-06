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

namespace PassportPDF.Tools.WinForm.Views
{
    partial class frmPassportInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPassportInfo));
            this.lbPassportInfoPassportId = new System.Windows.Forms.Label();
            this.tbPassportInfoPassportId = new System.Windows.Forms.TextBox();
            this.lbSubscriptionDate = new System.Windows.Forms.Label();
            this.tbPassportSubscriptionDate = new System.Windows.Forms.TextBox();
            this.lbUsedTokens = new System.Windows.Forms.Label();
            this.tbUsedTokens = new System.Windows.Forms.TextBox();
            this.btEditPassportId = new System.Windows.Forms.Button();
            this.rtbPassportInfoInstructions = new System.Windows.Forms.RichTextBox();
            this.lbPassportStatus = new System.Windows.Forms.Label();
            this.tbPassportStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbPassportInfoPassportId
            // 
            this.lbPassportInfoPassportId.AutoSize = true;
            this.lbPassportInfoPassportId.Location = new System.Drawing.Point(9, 101);
            this.lbPassportInfoPassportId.Name = "lbPassportInfoPassportId";
            this.lbPassportInfoPassportId.Size = new System.Drawing.Size(91, 13);
            this.lbPassportInfoPassportId.TabIndex = 0;
            this.lbPassportInfoPassportId.Text = "Passport Number:";
            // 
            // tbPassportInfoPassportId
            // 
            this.tbPassportInfoPassportId.Location = new System.Drawing.Point(12, 117);
            this.tbPassportInfoPassportId.Name = "tbPassportInfoPassportId";
            this.tbPassportInfoPassportId.ReadOnly = true;
            this.tbPassportInfoPassportId.Size = new System.Drawing.Size(367, 20);
            this.tbPassportInfoPassportId.TabIndex = 1;
            // 
            // lbSubscriptionDate
            // 
            this.lbSubscriptionDate.AutoSize = true;
            this.lbSubscriptionDate.Location = new System.Drawing.Point(82, 144);
            this.lbSubscriptionDate.Name = "lbSubscriptionDate";
            this.lbSubscriptionDate.Size = new System.Drawing.Size(94, 13);
            this.lbSubscriptionDate.TabIndex = 2;
            this.lbSubscriptionDate.Text = "Subscription Date:";
            // 
            // tbPassportSubscriptionDate
            // 
            this.tbPassportSubscriptionDate.Location = new System.Drawing.Point(85, 160);
            this.tbPassportSubscriptionDate.Name = "tbPassportSubscriptionDate";
            this.tbPassportSubscriptionDate.ReadOnly = true;
            this.tbPassportSubscriptionDate.Size = new System.Drawing.Size(159, 20);
            this.tbPassportSubscriptionDate.TabIndex = 3;
            // 
            // lbUsedTokens
            // 
            this.lbUsedTokens.AutoSize = true;
            this.lbUsedTokens.Location = new System.Drawing.Point(244, 144);
            this.lbUsedTokens.Name = "lbUsedTokens";
            this.lbUsedTokens.Size = new System.Drawing.Size(74, 13);
            this.lbUsedTokens.TabIndex = 5;
            this.lbUsedTokens.Text = "Used Tokens:";
            // 
            // tbUsedTokens
            // 
            this.tbUsedTokens.Location = new System.Drawing.Point(250, 160);
            this.tbUsedTokens.Name = "tbUsedTokens";
            this.tbUsedTokens.ReadOnly = true;
            this.tbUsedTokens.Size = new System.Drawing.Size(159, 20);
            this.tbUsedTokens.TabIndex = 6;
            // 
            // btEditPassportId
            // 
            this.btEditPassportId.Image = global::PassportPDF.Tools.WinForm.Properties.Resources.edit;
            this.btEditPassportId.Location = new System.Drawing.Point(385, 116);
            this.btEditPassportId.Name = "btEditPassportId";
            this.btEditPassportId.Size = new System.Drawing.Size(24, 24);
            this.btEditPassportId.TabIndex = 4;
            this.btEditPassportId.UseVisualStyleBackColor = true;
            this.btEditPassportId.Click += new System.EventHandler(this.btEditPassportId_Click);
            // 
            // rtbPassportInfoInstructions
            // 
            this.rtbPassportInfoInstructions.Location = new System.Drawing.Point(12, 13);
            this.rtbPassportInfoInstructions.Name = "rtbPassportInfoInstructions";
            this.rtbPassportInfoInstructions.ReadOnly = true;
            this.rtbPassportInfoInstructions.Size = new System.Drawing.Size(404, 85);
            this.rtbPassportInfoInstructions.TabIndex = 7;
            this.rtbPassportInfoInstructions.LinkClicked += new LinkClickedEventHandler(this.rtbPassportInfoInstructions_LinkClicked);
            // 
            // lbPassportStatus
            // 
            this.lbPassportStatus.AutoSize = true;
            this.lbPassportStatus.Location = new System.Drawing.Point(12, 143);
            this.lbPassportStatus.Name = "lbPassportStatus";
            this.lbPassportStatus.Size = new System.Drawing.Size(40, 13);
            this.lbPassportStatus.TabIndex = 8;
            this.lbPassportStatus.Text = "Status:";
            // 
            // tbPassportStatus
            // 
            this.tbPassportStatus.Location = new System.Drawing.Point(12, 160);
            this.tbPassportStatus.Name = "tbPassportStatus";
            this.tbPassportStatus.ReadOnly = true;
            this.tbPassportStatus.Size = new System.Drawing.Size(67, 20);
            this.tbPassportStatus.TabIndex = 9;
            // 
            // frmPassportInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 191);
            this.Controls.Add(this.tbPassportStatus);
            this.Controls.Add(this.lbPassportStatus);
            this.Controls.Add(this.rtbPassportInfoInstructions);
            this.Controls.Add(this.tbUsedTokens);
            this.Controls.Add(this.lbUsedTokens);
            this.Controls.Add(this.btEditPassportId);
            this.Controls.Add(this.tbPassportSubscriptionDate);
            this.Controls.Add(this.lbSubscriptionDate);
            this.Controls.Add(this.tbPassportInfoPassportId);
            this.Controls.Add(this.lbPassportInfoPassportId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(437, 230);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(437, 230);
            this.Name = "frmPassportInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Passport Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPassportInfoPassportId;
        private System.Windows.Forms.TextBox tbPassportInfoPassportId;
        private System.Windows.Forms.Label lbSubscriptionDate;
        private System.Windows.Forms.TextBox tbPassportSubscriptionDate;
        private System.Windows.Forms.Button btEditPassportId;
        private System.Windows.Forms.Label lbUsedTokens;
        private System.Windows.Forms.TextBox tbUsedTokens;
        private System.Windows.Forms.RichTextBox rtbPassportInfoInstructions;
        private System.Windows.Forms.Label lbPassportStatus;
        private System.Windows.Forms.TextBox tbPassportStatus;
    }
}