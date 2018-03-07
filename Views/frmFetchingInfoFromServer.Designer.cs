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
    partial class frmFetchingInfoFromServer
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
            this.components = new System.ComponentModel.Container();
            this.loaderImage = new System.Windows.Forms.PictureBox();
            this.toolTipFetchingInfoFromServer = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.loaderImage)).BeginInit();
            this.SuspendLayout();
            // 
            // loaderImage
            // 
            this.loaderImage.BackColor = System.Drawing.SystemColors.Window;
            this.loaderImage.Image = global::PassportPDF.Tools.WinForm.Properties.Resources.loader;
            this.loaderImage.Location = new System.Drawing.Point(1, 1);
            this.loaderImage.Name = "loaderImage";
            this.loaderImage.Size = new System.Drawing.Size(80, 80);
            this.loaderImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loaderImage.TabIndex = 0;
            this.loaderImage.TabStop = false;
            // 
            // frmFetchingInfoFromServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(82, 82);
            this.Controls.Add(this.loaderImage);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(82, 82);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(82, 82);
            this.Name = "frmFetchingInfoFromServer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.loaderImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox loaderImage;
        private System.Windows.Forms.ToolTip toolTipFetchingInfoFromServer;
    }
}