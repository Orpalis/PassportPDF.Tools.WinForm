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
    partial class frmAbout
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
            this.btClose = new System.Windows.Forms.Button();
            this.lkPassportPdfWebsite = new System.Windows.Forms.LinkLabel();
            this.lbBasedOn = new System.Windows.Forms.Label();
            this.lkOrpalisWebsite = new System.Windows.Forms.LinkLabel();
            this.lbCopyright = new System.Windows.Forms.Label();
            this.picProductLogo = new System.Windows.Forms.PictureBox();
            this.lbSourceCode = new System.Windows.Forms.Label();
            this.lkGithub = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picProductLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(14, 177);
            this.btClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(357, 30);
            this.btClose.TabIndex = 0;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // lkPassportPdfWebsite
            // 
            this.lkPassportPdfWebsite.AutoSize = true;
            this.lkPassportPdfWebsite.Location = new System.Drawing.Point(155, 122);
            this.lkPassportPdfWebsite.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lkPassportPdfWebsite.Name = "lkPassportPdfWebsite";
            this.lkPassportPdfWebsite.Size = new System.Drawing.Size(167, 15);
            this.lkPassportPdfWebsite.TabIndex = 17;
            this.lkPassportPdfWebsite.TabStop = true;
            this.lkPassportPdfWebsite.Text = "https://www.passportpdf.com";
            this.lkPassportPdfWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkPassportPdfWebsite_Click);
            // 
            // lbBasedOn
            // 
            this.lbBasedOn.AutoSize = true;
            this.lbBasedOn.Location = new System.Drawing.Point(14, 122);
            this.lbBasedOn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbBasedOn.Name = "lbBasedOn";
            this.lbBasedOn.Size = new System.Drawing.Size(127, 15);
            this.lbBasedOn.TabIndex = 14;
            this.lbBasedOn.Text = "Based on PassportPDF:";
            // 
            // lkOrpalisWebsite
            // 
            this.lkOrpalisWebsite.AutoSize = true;
            this.lkOrpalisWebsite.Location = new System.Drawing.Point(14, 95);
            this.lkOrpalisWebsite.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lkOrpalisWebsite.Name = "lkOrpalisWebsite";
            this.lkOrpalisWebsite.Size = new System.Drawing.Size(139, 15);
            this.lkOrpalisWebsite.TabIndex = 13;
            this.lkOrpalisWebsite.TabStop = true;
            this.lkOrpalisWebsite.Text = "https://www.orpalis.com";
            this.lkOrpalisWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btOrpalisWebsite_Click);
            // 
            // lbCopyright
            // 
            this.lbCopyright.AutoSize = true;
            this.lbCopyright.Location = new System.Drawing.Point(14, 72);
            this.lbCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCopyright.Name = "lbCopyright";
            this.lbCopyright.Size = new System.Drawing.Size(184, 15);
            this.lbCopyright.TabIndex = 16;
            this.lbCopyright.Text = "Copyright © ORPALIS 2017 - 2022";
            // 
            // picProductLogo
            // 
            this.picProductLogo.Location = new System.Drawing.Point(14, 14);
            this.picProductLogo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.picProductLogo.Name = "picProductLogo";
            this.picProductLogo.Size = new System.Drawing.Size(186, 48);
            this.picProductLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picProductLogo.TabIndex = 15;
            this.picProductLogo.TabStop = false;
            // 
            // lbSourceCode
            // 
            this.lbSourceCode.AutoSize = true;
            this.lbSourceCode.Location = new System.Drawing.Point(14, 147);
            this.lbSourceCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSourceCode.Name = "lbSourceCode";
            this.lbSourceCode.Size = new System.Drawing.Size(75, 15);
            this.lbSourceCode.TabIndex = 18;
            this.lbSourceCode.Text = "Source code:";
            // 
            // lkGithub
            // 
            this.lkGithub.AutoSize = true;
            this.lkGithub.Location = new System.Drawing.Point(98, 147);
            this.lkGithub.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lkGithub.Name = "lkGithub";
            this.lkGithub.Size = new System.Drawing.Size(73, 15);
            this.lkGithub.TabIndex = 19;
            this.lkGithub.TabStop = true;
            this.lkGithub.Text = "#github_link";
            this.lkGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkGithub_LinkClicked);
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 215);
            this.ControlBox = false;
            this.Controls.Add(this.lkGithub);
            this.Controls.Add(this.lbSourceCode);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.picProductLogo);
            this.Controls.Add(this.lkPassportPdfWebsite);
            this.Controls.Add(this.lbBasedOn);
            this.Controls.Add(this.lkOrpalisWebsite);
            this.Controls.Add(this.lbCopyright);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(401, 254);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(401, 254);
            this.Name = "frmAbout";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "#software_name";
            ((System.ComponentModel.ISupportInitialize)(this.picProductLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        internal System.Windows.Forms.LinkLabel lkPassportPdfWebsite;
        internal System.Windows.Forms.Label lbBasedOn;
        internal System.Windows.Forms.LinkLabel lkOrpalisWebsite;
        internal System.Windows.Forms.Label lbCopyright;
        private System.Windows.Forms.PictureBox picProductLogo;
        internal System.Windows.Forms.Label lbSourceCode;
        internal System.Windows.Forms.LinkLabel lkGithub;
    }
}