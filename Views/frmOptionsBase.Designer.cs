﻿/**********************************************************************
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
    partial class frmOptionsBase
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
            this.btReset = new System.Windows.Forms.Button();
            this.btApply = new System.Windows.Forms.Button();
            this.toolTipPreferredVersion = new System.Windows.Forms.ToolTip(this.components);
            this.btCancel = new System.Windows.Forms.Button();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.chkAutomaticallycheckForUpdates = new System.Windows.Forms.CheckBox();
            this.chkWarnSameInputOutputFolder = new System.Windows.Forms.CheckBox();
            this.chkSubfolders = new System.Windows.Forms.CheckBox();
            this.panelGeneral = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabLogs = new System.Windows.Forms.TabPage();
            this.btSelectLogFile = new System.Windows.Forms.Button();
            this.chkTimestampLogs = new System.Windows.Forms.CheckBox();
            this.chkExportLogs = new System.Windows.Forms.CheckBox();
            this.txtLogFile = new System.Windows.Forms.TextBox();
            this.lbLogsFile = new System.Windows.Forms.Label();
            this.panelLogs = new System.Windows.Forms.Panel();
            this.selectLogFileFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxBanner = new System.Windows.Forms.PictureBox();
            this.tabGeneral.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // btReset
            // 
            this.btReset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btReset.Location = new System.Drawing.Point(4, 358);
            this.btReset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(120, 36);
            this.btReset.TabIndex = 8;
            this.btReset.Text = "Reset to default";
            this.btReset.UseVisualStyleBackColor = true;
            this.btReset.Click += new System.EventHandler(this.btReset_Click);
            // 
            // btApply
            // 
            this.btApply.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btApply.Location = new System.Drawing.Point(329, 358);
            this.btApply.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btApply.Name = "btApply";
            this.btApply.Size = new System.Drawing.Size(120, 36);
            this.btApply.TabIndex = 7;
            this.btApply.Text = "Apply";
            this.btApply.UseVisualStyleBackColor = true;
            this.btApply.Click += new System.EventHandler(this.btApply_click);
            // 
            // toolTipPreferredVersion
            // 
            this.toolTipPreferredVersion.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipPreferredVersion.ToolTipTitle = "Preferred version";
            // 
            // btCancel
            // 
            this.btCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btCancel.Location = new System.Drawing.Point(456, 358);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(120, 36);
            this.btCancel.TabIndex = 10;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.chkAutomaticallycheckForUpdates);
            this.tabGeneral.Controls.Add(this.chkWarnSameInputOutputFolder);
            this.tabGeneral.Controls.Add(this.chkSubfolders);
            this.tabGeneral.Controls.Add(this.panelGeneral);
            this.tabGeneral.Location = new System.Drawing.Point(4, 24);
            this.tabGeneral.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabGeneral.Size = new System.Drawing.Size(567, 252);
            this.tabGeneral.TabIndex = 1;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // chkAutomaticallycheckForUpdates
            // 
            this.chkAutomaticallycheckForUpdates.AutoSize = true;
            this.chkAutomaticallycheckForUpdates.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkAutomaticallycheckForUpdates.Location = new System.Drawing.Point(18, 70);
            this.chkAutomaticallycheckForUpdates.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkAutomaticallycheckForUpdates.Name = "chkAutomaticallycheckForUpdates";
            this.chkAutomaticallycheckForUpdates.Size = new System.Drawing.Size(192, 19);
            this.chkAutomaticallycheckForUpdates.TabIndex = 16;
            this.chkAutomaticallycheckForUpdates.Text = "Automatically check for update";
            this.chkAutomaticallycheckForUpdates.UseVisualStyleBackColor = true;
            // 
            // chkWarnSameInputOutputFolder
            // 
            this.chkWarnSameInputOutputFolder.AutoSize = true;
            this.chkWarnSameInputOutputFolder.Location = new System.Drawing.Point(18, 44);
            this.chkWarnSameInputOutputFolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkWarnSameInputOutputFolder.Name = "chkWarnSameInputOutputFolder";
            this.chkWarnSameInputOutputFolder.Size = new System.Drawing.Size(334, 19);
            this.chkWarnSameInputOutputFolder.TabIndex = 11;
            this.chkWarnSameInputOutputFolder.Text = "Warn when source and destination directories are identical";
            this.chkWarnSameInputOutputFolder.UseVisualStyleBackColor = true;
            // 
            // chkSubfolders
            // 
            this.chkSubfolders.AutoSize = true;
            this.chkSubfolders.Location = new System.Drawing.Point(18, 17);
            this.chkSubfolders.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkSubfolders.Name = "chkSubfolders";
            this.chkSubfolders.Size = new System.Drawing.Size(124, 19);
            this.chkSubfolders.TabIndex = 3;
            this.chkSubfolders.Text = "Process subfolders";
            this.chkSubfolders.UseVisualStyleBackColor = true;
            // 
            // panelGeneral
            // 
            this.panelGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGeneral.Location = new System.Drawing.Point(4, 3);
            this.panelGeneral.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelGeneral.Name = "panelGeneral";
            this.panelGeneral.Size = new System.Drawing.Size(559, 246);
            this.panelGeneral.TabIndex = 17;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabLogs);
            this.tabControl1.Location = new System.Drawing.Point(4, 69);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 1;
            this.tabControl1.Size = new System.Drawing.Size(575, 280);
            this.tabControl1.TabIndex = 3;
            // 
            // tabLogs
            // 
            this.tabLogs.Controls.Add(this.btSelectLogFile);
            this.tabLogs.Controls.Add(this.chkTimestampLogs);
            this.tabLogs.Controls.Add(this.chkExportLogs);
            this.tabLogs.Controls.Add(this.txtLogFile);
            this.tabLogs.Controls.Add(this.lbLogsFile);
            this.tabLogs.Controls.Add(this.panelLogs);
            this.tabLogs.Location = new System.Drawing.Point(4, 24);
            this.tabLogs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabLogs.Size = new System.Drawing.Size(567, 252);
            this.tabLogs.TabIndex = 2;
            this.tabLogs.Text = "Logs";
            this.tabLogs.UseVisualStyleBackColor = true;
            // 
            // btSelectLogFile
            // 
            this.btSelectLogFile.Location = new System.Drawing.Point(323, 90);
            this.btSelectLogFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btSelectLogFile.Name = "btSelectLogFile";
            this.btSelectLogFile.Size = new System.Drawing.Size(24, 24);
            this.btSelectLogFile.TabIndex = 23;
            this.btSelectLogFile.UseVisualStyleBackColor = true;
            this.btSelectLogFile.Click += new System.EventHandler(this.btSelectLogFile_Click);
            // 
            // chkTimestampLogs
            // 
            this.chkTimestampLogs.AutoSize = true;
            this.chkTimestampLogs.Location = new System.Drawing.Point(18, 17);
            this.chkTimestampLogs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkTimestampLogs.Name = "chkTimestampLogs";
            this.chkTimestampLogs.Size = new System.Drawing.Size(159, 19);
            this.chkTimestampLogs.TabIndex = 26;
            this.chkTimestampLogs.Text = "Timestamp log messages";
            this.chkTimestampLogs.UseVisualStyleBackColor = true;
            // 
            // chkExportLogs
            // 
            this.chkExportLogs.AutoSize = true;
            this.chkExportLogs.Location = new System.Drawing.Point(18, 44);
            this.chkExportLogs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkExportLogs.Name = "chkExportLogs";
            this.chkExportLogs.Size = new System.Drawing.Size(154, 19);
            this.chkExportLogs.TabIndex = 24;
            this.chkExportLogs.Text = "Export the log messages";
            this.chkExportLogs.UseVisualStyleBackColor = true;
            // 
            // txtLogFile
            // 
            this.txtLogFile.Location = new System.Drawing.Point(18, 91);
            this.txtLogFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtLogFile.Name = "txtLogFile";
            this.txtLogFile.ReadOnly = true;
            this.txtLogFile.Size = new System.Drawing.Size(302, 23);
            this.txtLogFile.TabIndex = 22;
            this.txtLogFile.Text = "(click the button to select a file)";
            this.txtLogFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbLogsFile
            // 
            this.lbLogsFile.AutoSize = true;
            this.lbLogsFile.Location = new System.Drawing.Point(14, 70);
            this.lbLogsFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLogsFile.Name = "lbLogsFile";
            this.lbLogsFile.Size = new System.Drawing.Size(54, 15);
            this.lbLogsFile.TabIndex = 25;
            this.lbLogsFile.Text = "Logs file:";
            // 
            // panelLogs
            // 
            this.panelLogs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLogs.Location = new System.Drawing.Point(4, 3);
            this.panelLogs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelLogs.Name = "panelLogs";
            this.panelLogs.Size = new System.Drawing.Size(559, 246);
            this.panelLogs.TabIndex = 27;
            // 
            // selectLogFileFileDialog
            // 
            this.selectLogFileFileDialog.Filter = "Text files (*.txt)|*.txt";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Gray;
            this.pictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox2.Location = new System.Drawing.Point(4, 353);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(572, 1);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBoxBanner
            // 
            this.pictureBoxBanner.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBoxBanner.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxBanner.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBoxBanner.Name = "pictureBoxBanner";
            this.pictureBoxBanner.Size = new System.Drawing.Size(579, 63);
            this.pictureBoxBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBanner.TabIndex = 4;
            this.pictureBoxBanner.TabStop = false;
            // 
            // frmOptionsBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 397);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btReset);
            this.Controls.Add(this.btApply);
            this.Controls.Add(this.pictureBoxBanner);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOptionsBase";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabLogs.ResumeLayout(false);
            this.tabLogs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBanner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxBanner;
        internal System.Windows.Forms.Button btReset;
        internal System.Windows.Forms.Button btApply;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolTip toolTipPreferredVersion;
        internal System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.CheckBox chkAutomaticallycheckForUpdates;
        private System.Windows.Forms.CheckBox chkWarnSameInputOutputFolder;
        private System.Windows.Forms.CheckBox chkSubfolders;
        protected System.Windows.Forms.TabPage tabGeneral;
        protected System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.SaveFileDialog selectLogFileFileDialog;
        private System.Windows.Forms.TabPage tabLogs;
        private System.Windows.Forms.TextBox txtLogFile;
        private System.Windows.Forms.Button btSelectLogFile;
        private System.Windows.Forms.CheckBox chkExportLogs;
        private System.Windows.Forms.Label lbLogsFile;
        private System.Windows.Forms.CheckBox chkTimestampLogs;
        private System.Windows.Forms.Panel panelGeneral;
        private System.Windows.Forms.Panel panelLogs;
    }
}