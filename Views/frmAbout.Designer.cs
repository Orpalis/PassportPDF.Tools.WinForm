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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.btClose = new System.Windows.Forms.Button();
            this.lkPassportPdfWebsite = new System.Windows.Forms.LinkLabel();
            this.lbBasedOn = new System.Windows.Forms.Label();
            this.lkOrpalisWebsite = new System.Windows.Forms.LinkLabel();
            this.lbCopyright = new System.Windows.Forms.Label();
            this.picProductLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picProductLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Parent = this;
            this.btClose.Location = new System.Drawing.Point(5, 137);
            this.btClose.Size = new System.Drawing.Size(312, 26);
            this.btClose.TabIndex = 0;
            this.btClose.Name = "btClose";
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // lkPassportPdfWebsite
            //
            this.lkPassportPdfWebsite.Location = new System.Drawing.Point(137, 111);
            this.lkPassportPdfWebsite.Size = new System.Drawing.Size(153, 23);
            this.lkPassportPdfWebsite.TabIndex = 17;
            this.lkPassportPdfWebsite.Text = "https://www.passportpdf.com";
            this.lkPassportPdfWebsite.Name = "lkPassportPdfWebsite";
            this.lkPassportPdfWebsite.TabStop = true;
            this.lkPassportPdfWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkPassportPdfWebsite_Click);
            // 
            // lbBasedOn
            //
            this.lbBasedOn.AutoSize = true;
            this.lbBasedOn.Location = new System.Drawing.Point(11, 111);
            this.lbBasedOn.Size = new System.Drawing.Size(120, 13);
            this.lbBasedOn.TabIndex = 14;
            this.lbBasedOn.Parent = this;
            this.lbBasedOn.Text = "Based on PassportPDF:";
            this.lbBasedOn.Name = "lbBasedOn";
            // 
            // lkOrpalisWebsite
            //
            this.lkOrpalisWebsite.AutoSize = true;
            this.lkOrpalisWebsite.Location = new System.Drawing.Point(12, 82);
            this.lkOrpalisWebsite.Size = new System.Drawing.Size(118, 13);
            this.lkOrpalisWebsite.TabIndex = 13;
            this.lkOrpalisWebsite.Name = "lkOrpalisWebsite";
            this.lkOrpalisWebsite.Text = "http://www.orpalis.com";
            this.lkOrpalisWebsite.TabStop = true;
            this.lkOrpalisWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btOrpalisWebsite_Clock);
            // 
            // lbCopyright
            //
            this.lbCopyright.AutoSize = true;
            this.lbCopyright.Location = new System.Drawing.Point(12, 62);
            this.lbCopyright.Size = new System.Drawing.Size(172, 13);
            this.lbCopyright.TabIndex = 10;
            this.lbCopyright.Text = "Copyright © ORPALIS 2017 - 2018";
            this.lbCopyright.Name = "lbCopyright";
            // 
            // picProductLogo
            //
            this.picProductLogo.AutoSize = true;
            this.picProductLogo.Location = new System.Drawing.Point(12, 12);
            this.picProductLogo.Size = new System.Drawing.Size(159, 42);
            this.picProductLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lbCopyright.TabIndex = 16;
            this.picProductLogo.Name = "picProductLogo";
            this.picProductLogo.TabStop = false;
            // 
            // frmAbout
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 167);
            this.ControlBox = false;
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.picProductLogo);
            this.Controls.Add(this.lkPassportPdfWebsite);
            this.Controls.Add(this.lbBasedOn);
            this.Controls.Add(this.lkOrpalisWebsite);
            this.Controls.Add(this.lbCopyright);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(336, 206);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(336, 206);
            this.Name = "frmAbout";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
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
    }
}