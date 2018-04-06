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
    partial class frmRegisterPassport
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
            this.txtPassport = new System.Windows.Forms.TextBox();
            this.btSave = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.rtbRegisterPassportInstructions = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtPassport
            // 
            this.txtPassport.Location = new System.Drawing.Point(12, 93);
            this.txtPassport.MinimumSize = new System.Drawing.Size(352, 20);
            this.txtPassport.Name = "txtPassport";
            this.txtPassport.Size = new System.Drawing.Size(352, 20);
            this.txtPassport.TabIndex = 0;
            this.txtPassport.TextChanged += new System.EventHandler(this.txtPassport_TextChanged);
            // 
            // btSave
            // 
            this.btSave.Enabled = false;
            this.btSave.Location = new System.Drawing.Point(192, 119);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(174, 23);
            this.btSave.TabIndex = 2;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btRegister_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(12, 119);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(174, 23);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // rtbRegisterPassportInstructions
            // 
            this.rtbRegisterPassportInstructions.Location = new System.Drawing.Point(12, 12);
            this.rtbRegisterPassportInstructions.Name = "rtbRegisterPassportInstructions";
            this.rtbRegisterPassportInstructions.ReadOnly = true;
            this.rtbRegisterPassportInstructions.Size = new System.Drawing.Size(352, 75);
            this.rtbRegisterPassportInstructions.TabIndex = 4;
            this.rtbRegisterPassportInstructions.Text = "Please enter your Passport Number below.\\nIn order to get one, all you need to do is create an account at http://www.passportpdf.com and then get your Passport Number in the My Account section!";
            this.rtbRegisterPassportInstructions.LinkClicked += rtbRegisterPassportInstructions_LinkClicked;
            // 
            // frmRegisterPassport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 151);
            this.ControlBox = false;
            this.Controls.Add(this.rtbRegisterPassportInstructions);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.txtPassport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(392, 190);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(392, 190);
            this.Name = "frmRegisterPassport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Passport Management";
            this.TopMost = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPassport;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.RichTextBox rtbRegisterPassportInstructions;
    }
}