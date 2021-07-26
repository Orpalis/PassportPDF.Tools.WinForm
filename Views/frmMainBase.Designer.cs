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
    public partial class frmMainBase : Form
    {


        // Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }


        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components = null;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.lbSrcFolder = new System.Windows.Forms.Label();
            this.txtSourcePath = new System.Windows.Forms.TextBox();
            this.lbDstFolder = new System.Windows.Forms.Label();
            this.txtDestFolder = new System.Windows.Forms.TextBox();
            this.cmdBrowseDest = new System.Windows.Forms.Button();
            this.lbThreads = new System.Windows.Forms.Label();
            this.cboMaxProcesses = new System.Windows.Forms.ComboBox();
            this.prgProgress = new System.Windows.Forms.ProgressBar();
            this.FldBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.TabProcessLogs = new System.Windows.Forms.TabPage();
            this.lstProcessLog = new System.Windows.Forms.ListBox();
            this.TabWarnings = new System.Windows.Forms.TabPage();
            this.lstWarnLog = new System.Windows.Forms.ListBox();
            this.TabStatus = new System.Windows.Forms.TabPage();
            this.logoBitmap = new System.Windows.Forms.PictureBox();
            this.lstThreads = new System.Windows.Forms.ListBox();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.tabErrors = new System.Windows.Forms.TabPage();
            this.lstErrLog = new System.Windows.Forms.ListBox();
            this.cmdRun = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.passportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.communityForumsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facebookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForLatestUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbStatus = new System.Windows.Forms.Label();
            this.fileSelectDlg = new System.Windows.Forms.OpenFileDialog();
            this.cmdPause = new System.Windows.Forms.Button();
            this.cmdBrowseFolders = new System.Windows.Forms.Button();
            this.cmdBrowseFiles = new System.Windows.Forms.Button();
            this.TabProcessLogs.SuspendLayout();
            this.TabWarnings.SuspendLayout();
            this.TabStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoBitmap)).BeginInit();
            this.TabControl1.SuspendLayout();
            this.tabErrors.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbSrcFolder
            // 
            this.lbSrcFolder.AutoSize = true;
            this.lbSrcFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbSrcFolder.Location = new System.Drawing.Point(35, 34);
            this.lbSrcFolder.Name = "lbSrcFolder";
            this.lbSrcFolder.Size = new System.Drawing.Size(46, 15);
            this.lbSrcFolder.TabIndex = 0;
            this.lbSrcFolder.Text = "Source:";
            this.lbSrcFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSourcePath
            // 
            this.txtSourcePath.Location = new System.Drawing.Point(85, 34);
            this.txtSourcePath.MaxLength = 999999999;
            this.txtSourcePath.Name = "txtSourcePath";
            this.txtSourcePath.Size = new System.Drawing.Size(372, 23);
            this.txtSourcePath.TabIndex = 1;
            this.txtSourcePath.WordWrap = false;
            // 
            // lbDstFolder
            // 
            this.lbDstFolder.AutoSize = true;
            this.lbDstFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbDstFolder.Location = new System.Drawing.Point(16, 61);
            this.lbDstFolder.Name = "lbDstFolder";
            this.lbDstFolder.Size = new System.Drawing.Size(70, 15);
            this.lbDstFolder.TabIndex = 2;
            this.lbDstFolder.Text = "Destination:";
            this.lbDstFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDestFolder
            // 
            this.txtDestFolder.Location = new System.Drawing.Point(85, 61);
            this.txtDestFolder.Name = "txtDestFolder";
            this.txtDestFolder.Size = new System.Drawing.Size(372, 23);
            this.txtDestFolder.TabIndex = 3;
            // 
            // cmdBrowseDest
            // 
            this.cmdBrowseDest.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdBrowseDest.Location = new System.Drawing.Point(463, 61);
            this.cmdBrowseDest.Name = "cmdBrowseDest";
            this.cmdBrowseDest.Size = new System.Drawing.Size(50, 24);
            this.cmdBrowseDest.TabIndex = 5;
            this.cmdBrowseDest.Text = ".....";
            this.cmdBrowseDest.UseVisualStyleBackColor = true;
            this.cmdBrowseDest.Click += new System.EventHandler(this.cmdBrowseDest_Click);
            // 
            // lbThreads
            // 
            this.lbThreads.AutoSize = true;
            this.lbThreads.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbThreads.Location = new System.Drawing.Point(30, 89);
            this.lbThreads.Name = "lbThreads";
            this.lbThreads.Size = new System.Drawing.Size(51, 15);
            this.lbThreads.TabIndex = 7;
            this.lbThreads.Text = "Threads:";
            this.lbThreads.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboMaxProcesses
            // 
            this.cboMaxProcesses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaxProcesses.FormattingEnabled = true;
            this.cboMaxProcesses.Location = new System.Drawing.Point(85, 89);
            this.cboMaxProcesses.Name = "cboMaxProcesses";
            this.cboMaxProcesses.Size = new System.Drawing.Size(155, 23);
            this.cboMaxProcesses.TabIndex = 8;
            // 
            // prgProgress
            // 
            this.prgProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgProgress.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.prgProgress.Location = new System.Drawing.Point(4, 379);
            this.prgProgress.Name = "prgProgress";
            this.prgProgress.Size = new System.Drawing.Size(511, 20);
            this.prgProgress.TabIndex = 12;
            this.prgProgress.Visible = false;
            // 
            // FldBrowse
            // 
            this.FldBrowse.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // TabProcessLogs
            // 
            this.TabProcessLogs.Controls.Add(this.lstProcessLog);
            this.TabProcessLogs.Location = new System.Drawing.Point(4, 24);
            this.TabProcessLogs.Name = "TabProcessLogs";
            this.TabProcessLogs.Padding = new System.Windows.Forms.Padding(3);
            this.TabProcessLogs.Size = new System.Drawing.Size(505, 204);
            this.TabProcessLogs.TabIndex = 2;
            this.TabProcessLogs.Text = "Success";
            this.TabProcessLogs.UseVisualStyleBackColor = true;
            // 
            // lstProcessLog
            // 
            this.lstProcessLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstProcessLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstProcessLog.FormattingEnabled = true;
            this.lstProcessLog.IntegralHeight = false;
            this.lstProcessLog.ItemHeight = 14;
            this.lstProcessLog.Location = new System.Drawing.Point(3, 3);
            this.lstProcessLog.Name = "lstProcessLog";
            this.lstProcessLog.Size = new System.Drawing.Size(499, 198);
            this.lstProcessLog.TabIndex = 1;
            // 
            // TabWarnings
            // 
            this.TabWarnings.Controls.Add(this.lstWarnLog);
            this.TabWarnings.Location = new System.Drawing.Point(4, 24);
            this.TabWarnings.Name = "TabWarnings";
            this.TabWarnings.Padding = new System.Windows.Forms.Padding(3);
            this.TabWarnings.Size = new System.Drawing.Size(505, 204);
            this.TabWarnings.TabIndex = 1;
            this.TabWarnings.Text = "Warnings";
            this.TabWarnings.UseVisualStyleBackColor = true;
            // 
            // lstWarnLog
            // 
            this.lstWarnLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstWarnLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstWarnLog.FormattingEnabled = true;
            this.lstWarnLog.IntegralHeight = false;
            this.lstWarnLog.ItemHeight = 14;
            this.lstWarnLog.Location = new System.Drawing.Point(3, 3);
            this.lstWarnLog.Name = "lstWarnLog";
            this.lstWarnLog.Size = new System.Drawing.Size(499, 198);
            this.lstWarnLog.TabIndex = 0;
            // 
            // TabStatus
            // 
            this.TabStatus.Controls.Add(this.logoBitmap);
            this.TabStatus.Controls.Add(this.lstThreads);
            this.TabStatus.Location = new System.Drawing.Point(4, 24);
            this.TabStatus.Name = "TabStatus";
            this.TabStatus.Padding = new System.Windows.Forms.Padding(3);
            this.TabStatus.Size = new System.Drawing.Size(505, 204);
            this.TabStatus.TabIndex = 0;
            this.TabStatus.Text = "Status";
            this.TabStatus.UseVisualStyleBackColor = true;
            // 
            // logoBitmap
            // 
            this.logoBitmap.BackColor = System.Drawing.Color.White;
            this.logoBitmap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.logoBitmap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoBitmap.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.logoBitmap.Location = new System.Drawing.Point(3, 3);
            this.logoBitmap.Name = "logoBitmap";
            this.logoBitmap.Size = new System.Drawing.Size(499, 198);
            this.logoBitmap.TabIndex = 34;
            this.logoBitmap.TabStop = false;
            // 
            // lstThreads
            // 
            this.lstThreads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstThreads.FormattingEnabled = true;
            this.lstThreads.IntegralHeight = false;
            this.lstThreads.ItemHeight = 15;
            this.lstThreads.Location = new System.Drawing.Point(3, 3);
            this.lstThreads.Name = "lstThreads";
            this.lstThreads.Size = new System.Drawing.Size(499, 198);
            this.lstThreads.TabIndex = 11;
            // 
            // TabControl1
            // 
            this.TabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl1.Controls.Add(this.TabStatus);
            this.TabControl1.Controls.Add(this.TabWarnings);
            this.TabControl1.Controls.Add(this.tabErrors);
            this.TabControl1.Controls.Add(this.TabProcessLogs);
            this.TabControl1.Location = new System.Drawing.Point(4, 140);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(513, 232);
            this.TabControl1.TabIndex = 13;
            // 
            // tabErrors
            // 
            this.tabErrors.Controls.Add(this.lstErrLog);
            this.tabErrors.Location = new System.Drawing.Point(4, 24);
            this.tabErrors.Name = "tabErrors";
            this.tabErrors.Padding = new System.Windows.Forms.Padding(3);
            this.tabErrors.Size = new System.Drawing.Size(505, 204);
            this.tabErrors.TabIndex = 3;
            this.tabErrors.Text = "Errors";
            this.tabErrors.UseVisualStyleBackColor = true;
            // 
            // lstErrLog
            // 
            this.lstErrLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstErrLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstErrLog.FormattingEnabled = true;
            this.lstErrLog.IntegralHeight = false;
            this.lstErrLog.ItemHeight = 14;
            this.lstErrLog.Location = new System.Drawing.Point(3, 3);
            this.lstErrLog.Name = "lstErrLog";
            this.lstErrLog.Size = new System.Drawing.Size(499, 198);
            this.lstErrLog.TabIndex = 1;
            // 
            // cmdRun
            // 
            this.cmdRun.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdRun.Location = new System.Drawing.Point(246, 89);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(90, 24);
            this.cmdRun.TabIndex = 28;
            this.cmdRun.Text = "Start batch";
            this.cmdRun.UseVisualStyleBackColor = true;
            this.cmdRun.Click += new System.EventHandler(this.cmdRun_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.passportToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(519, 24);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // passportToolStripMenuItem
            // 
            this.passportToolStripMenuItem.Name = "passportToolStripMenuItem";
            this.passportToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.passportToolStripMenuItem.Text = "Passport";
            this.passportToolStripMenuItem.Click += new System.EventHandler(this.passportToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.communityForumsToolStripMenuItem,
            this.facebookToolStripMenuItem,
            this.checkForLatestUpdateToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(24, 20);
            this.helpToolStripMenuItem.Text = "?";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // communityForumsToolStripMenuItem
            // 
            this.communityForumsToolStripMenuItem.Name = "communityForumsToolStripMenuItem";
            this.communityForumsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.communityForumsToolStripMenuItem.Text = "Community Forums";
            this.communityForumsToolStripMenuItem.Click += new System.EventHandler(this.communityForumsToolStripMenuItem_Click);
            // 
            // facebookToolStripMenuItem
            // 
            this.facebookToolStripMenuItem.Name = "facebookToolStripMenuItem";
            this.facebookToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.facebookToolStripMenuItem.Text = "Facebook Community";
            this.facebookToolStripMenuItem.Click += new System.EventHandler(this.facebookToolStripMenuItem_Click);
            // 
            // checkForLatestUpdateToolStripMenuItem
            // 
            this.checkForLatestUpdateToolStripMenuItem.Name = "checkForLatestUpdateToolStripMenuItem";
            this.checkForLatestUpdateToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.checkForLatestUpdateToolStripMenuItem.Text = "Check for latest update";
            this.checkForLatestUpdateToolStripMenuItem.Click += new System.EventHandler(this.checkForLastUpdateToolStripMenuItem_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStatus.AutoSize = true;
            this.lbStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbStatus.Location = new System.Drawing.Point(7, 382);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(26, 15);
            this.lbStatus.TabIndex = 32;
            this.lbStatus.Text = "idle";
            this.lbStatus.Visible = false;
            // 
            // fileSelectDlg
            // 
            this.fileSelectDlg.Multiselect = true;
            // 
            // cmdPause
            // 
            this.cmdPause.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmdPause.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdPause.Location = new System.Drawing.Point(339, 90);
            this.cmdPause.Name = "cmdPause";
            this.cmdPause.Size = new System.Drawing.Size(26, 23);
            this.cmdPause.TabIndex = 34;
            this.cmdPause.UseVisualStyleBackColor = true;
            this.cmdPause.Click += new System.EventHandler(this.cmdPause_Click);
            // 
            // cmdBrowseFolders
            // 
            this.cmdBrowseFolders.Location = new System.Drawing.Point(489, 33);
            this.cmdBrowseFolders.Name = "cmdBrowseFolders";
            this.cmdBrowseFolders.Size = new System.Drawing.Size(24, 24);
            this.cmdBrowseFolders.TabIndex = 35;
            this.cmdBrowseFolders.UseVisualStyleBackColor = true;
            this.cmdBrowseFolders.Click += new System.EventHandler(this.cmdBrowseFolders_Click);
            // 
            // cmdBrowseFiles
            // 
            this.cmdBrowseFiles.Location = new System.Drawing.Point(463, 33);
            this.cmdBrowseFiles.Name = "cmdBrowseFiles";
            this.cmdBrowseFiles.Size = new System.Drawing.Size(24, 24);
            this.cmdBrowseFiles.TabIndex = 4;
            this.cmdBrowseFiles.UseVisualStyleBackColor = true;
            this.cmdBrowseFiles.Click += new System.EventHandler(this.cmdBrowseFiles_Click);
            // 
            // frmMainBase
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 408);
            this.Controls.Add(this.cmdBrowseFolders);
            this.Controls.Add(this.cmdPause);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.cmdRun);
            this.Controls.Add(this.lbThreads);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.prgProgress);
            this.Controls.Add(this.cboMaxProcesses);
            this.Controls.Add(this.cmdBrowseDest);
            this.Controls.Add(this.cmdBrowseFiles);
            this.Controls.Add(this.txtDestFolder);
            this.Controls.Add(this.lbDstFolder);
            this.Controls.Add(this.txtSourcePath);
            this.Controls.Add(this.lbSrcFolder);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(535, 447);
            this.Name = "frmMainBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmMain_DragEnter);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.TabProcessLogs.ResumeLayout(false);
            this.TabWarnings.ResumeLayout(false);
            this.TabStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoBitmap)).EndInit();
            this.TabControl1.ResumeLayout(false);
            this.tabErrors.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        internal System.Windows.Forms.Label lbSrcFolder;
        internal System.Windows.Forms.TextBox txtSourcePath;
        internal System.Windows.Forms.Label lbDstFolder;
        internal System.Windows.Forms.TextBox txtDestFolder;
        internal System.Windows.Forms.Button cmdBrowseFiles;
        internal System.Windows.Forms.Button cmdBrowseDest;
        internal System.Windows.Forms.Label lbThreads;
        internal System.Windows.Forms.ComboBox cboMaxProcesses;
        internal System.Windows.Forms.ProgressBar prgProgress;
        internal System.Windows.Forms.FolderBrowserDialog FldBrowse;
        internal System.Windows.Forms.TabPage TabProcessLogs;
        internal System.Windows.Forms.ListBox lstProcessLog;
        internal System.Windows.Forms.TabPage TabWarnings;
        internal System.Windows.Forms.ListBox lstWarnLog;
        internal System.Windows.Forms.TabPage TabStatus;
        internal System.Windows.Forms.ListBox lstThreads;
        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.Button cmdRun;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        internal ListBox lstErrLog;
        private Label lbStatus;
        internal TabPage tabErrors;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem communityForumsToolStripMenuItem;
        private ToolStripMenuItem facebookToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem languageToolStripMenuItem;
        private OpenFileDialog fileSelectDlg;
        private PictureBox logoBitmap;
        private Button cmdPause;
        internal Button cmdBrowseFolders;
        private ToolStripMenuItem passportToolStripMenuItem;
        private ToolStripMenuItem checkForLatestUpdateToolStripMenuItem;
    }
}