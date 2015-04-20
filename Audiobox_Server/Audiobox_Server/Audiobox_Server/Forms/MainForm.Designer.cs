namespace Audiobox_Server.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.youtubeDownloadmanagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSessions = new System.Windows.Forms.Label();
            this.lvwSessions = new System.Windows.Forms.ListView();
            this.columnID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPortNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHostID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnNumberOfClients = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStarted = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnSubmitCommand = new System.Windows.Forms.Button();
            this.tbxCommand = new System.Windows.Forms.TextBox();
            this.rtbxLogConsole = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAssignedUnassigned = new System.Windows.Forms.Label();
            this.lblUsers = new System.Windows.Forms.Label();
            this.lvwUsers = new System.Windows.Forms.ListView();
            this.columnUserId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnGoogleId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAssigned = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLastKeepAliveSignal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTimeSinceLKAT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.youtubeDownloadmanagerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(954, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.terminateToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // terminateToolStripMenuItem
            // 
            this.terminateToolStripMenuItem.Name = "terminateToolStripMenuItem";
            this.terminateToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.terminateToolStripMenuItem.Text = "Terminate Server";
            this.terminateToolStripMenuItem.Click += new System.EventHandler(this.terminateToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // youtubeDownloadmanagerToolStripMenuItem
            // 
            this.youtubeDownloadmanagerToolStripMenuItem.Name = "youtubeDownloadmanagerToolStripMenuItem";
            this.youtubeDownloadmanagerToolStripMenuItem.Size = new System.Drawing.Size(168, 20);
            this.youtubeDownloadmanagerToolStripMenuItem.Text = "Youtube Downloadmanager";
            this.youtubeDownloadmanagerToolStripMenuItem.Click += new System.EventHandler(this.youtubeDownloadmanagerToolStripMenuItem_Click);
            // 
            // lblSessions
            // 
            this.lblSessions.AutoSize = true;
            this.lblSessions.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSessions.Location = new System.Drawing.Point(3, 4);
            this.lblSessions.Name = "lblSessions";
            this.lblSessions.Size = new System.Drawing.Size(70, 18);
            this.lblSessions.TabIndex = 3;
            this.lblSessions.Text = "Sessions";
            // 
            // lvwSessions
            // 
            this.lvwSessions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(36)))), ((int)(((byte)(86)))));
            this.lvwSessions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnID,
            this.columnPortNumber,
            this.columnActive,
            this.columnHostID,
            this.columnNumberOfClients,
            this.columnStarted});
            this.lvwSessions.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwSessions.ForeColor = System.Drawing.Color.White;
            this.lvwSessions.FullRowSelect = true;
            this.lvwSessions.GridLines = true;
            this.lvwSessions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwSessions.Location = new System.Drawing.Point(3, 24);
            this.lvwSessions.Name = "lvwSessions";
            this.lvwSessions.Size = new System.Drawing.Size(482, 280);
            this.lvwSessions.TabIndex = 4;
            this.lvwSessions.UseCompatibleStateImageBehavior = false;
            this.lvwSessions.View = System.Windows.Forms.View.Details;
            this.lvwSessions.DoubleClick += new System.EventHandler(this.lvwSessions_DoubleClick);
            // 
            // columnID
            // 
            this.columnID.Text = "ID";
            this.columnID.Width = 40;
            // 
            // columnPortNumber
            // 
            this.columnPortNumber.Text = "Port";
            this.columnPortNumber.Width = 55;
            // 
            // columnActive
            // 
            this.columnActive.Text = "Active";
            this.columnActive.Width = 55;
            // 
            // columnHostID
            // 
            this.columnHostID.Text = "HUID";
            this.columnHostID.Width = 50;
            // 
            // columnNumberOfClients
            // 
            this.columnNumberOfClients.Text = "Clients";
            this.columnNumberOfClients.Width = 62;
            // 
            // columnStarted
            // 
            this.columnStarted.Text = "Starttime";
            this.columnStarted.Width = 200;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(0, 30);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnSubmitCommand);
            this.splitContainer1.Panel1.Controls.Add(this.tbxCommand);
            this.splitContainer1.Panel1.Controls.Add(this.rtbxLogConsole);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.lblAssignedUnassigned);
            this.splitContainer1.Panel2.Controls.Add(this.lblUsers);
            this.splitContainer1.Panel2.Controls.Add(this.lvwUsers);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.lvwSessions);
            this.splitContainer1.Panel2.Controls.Add(this.lblSessions);
            this.splitContainer1.Size = new System.Drawing.Size(947, 574);
            this.splitContainer1.SplitterDistance = 448;
            this.splitContainer1.TabIndex = 5;
            // 
            // btnSubmitCommand
            // 
            this.btnSubmitCommand.Location = new System.Drawing.Point(368, 548);
            this.btnSubmitCommand.Name = "btnSubmitCommand";
            this.btnSubmitCommand.Size = new System.Drawing.Size(73, 21);
            this.btnSubmitCommand.TabIndex = 2;
            this.btnSubmitCommand.Text = "Submit";
            this.btnSubmitCommand.UseVisualStyleBackColor = true;
            this.btnSubmitCommand.Click += new System.EventHandler(this.btnSubmitCommand_Click);
            // 
            // tbxCommand
            // 
            this.tbxCommand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(36)))), ((int)(((byte)(86)))));
            this.tbxCommand.Font = new System.Drawing.Font("Courier New", 9F);
            this.tbxCommand.ForeColor = System.Drawing.Color.White;
            this.tbxCommand.Location = new System.Drawing.Point(6, 547);
            this.tbxCommand.Name = "tbxCommand";
            this.tbxCommand.Size = new System.Drawing.Size(356, 21);
            this.tbxCommand.TabIndex = 1;
            this.tbxCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCommand_KeyDown);
            // 
            // rtbxLogConsole
            // 
            this.rtbxLogConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(36)))), ((int)(((byte)(86)))));
            this.rtbxLogConsole.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbxLogConsole.ForeColor = System.Drawing.Color.White;
            this.rtbxLogConsole.Location = new System.Drawing.Point(6, -2);
            this.rtbxLogConsole.Name = "rtbxLogConsole";
            this.rtbxLogConsole.ReadOnly = true;
            this.rtbxLogConsole.Size = new System.Drawing.Size(435, 548);
            this.rtbxLogConsole.TabIndex = 0;
            this.rtbxLogConsole.Text = "";
            this.rtbxLogConsole.Enter += new System.EventHandler(this.rtbxLogConsole_Enter);
            this.rtbxLogConsole.Leave += new System.EventHandler(this.rtbxLogConsole_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "(doubleclick to view current playlist)";
            // 
            // lblAssignedUnassigned
            // 
            this.lblAssignedUnassigned.AutoSize = true;
            this.lblAssignedUnassigned.Location = new System.Drawing.Point(70, 318);
            this.lblAssignedUnassigned.Name = "lblAssignedUnassigned";
            this.lblAssignedUnassigned.Size = new System.Drawing.Size(84, 13);
            this.lblAssignedUnassigned.TabIndex = 11;
            this.lblAssignedUnassigned.Text = "(Un)-/Assigned: ";
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsers.Location = new System.Drawing.Point(3, 314);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(48, 18);
            this.lblUsers.TabIndex = 10;
            this.lblUsers.Text = "Users";
            // 
            // lvwUsers
            // 
            this.lvwUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(36)))), ((int)(((byte)(86)))));
            this.lvwUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnUserId,
            this.columnGoogleId,
            this.columnAssigned,
            this.columnLastKeepAliveSignal,
            this.columnTimeSinceLKAT});
            this.lvwUsers.Font = new System.Drawing.Font("Courier New", 9F);
            this.lvwUsers.ForeColor = System.Drawing.Color.White;
            this.lvwUsers.FullRowSelect = true;
            this.lvwUsers.GridLines = true;
            this.lvwUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwUsers.Location = new System.Drawing.Point(3, 335);
            this.lvwUsers.Name = "lvwUsers";
            this.lvwUsers.Size = new System.Drawing.Size(482, 231);
            this.lvwUsers.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwUsers.TabIndex = 9;
            this.lvwUsers.UseCompatibleStateImageBehavior = false;
            this.lvwUsers.View = System.Windows.Forms.View.Details;
            // 
            // columnUserId
            // 
            this.columnUserId.Text = "UID";
            this.columnUserId.Width = 40;
            // 
            // columnGoogleId
            // 
            this.columnGoogleId.Text = "Google ID";
            this.columnGoogleId.Width = 75;
            // 
            // columnAssigned
            // 
            this.columnAssigned.Text = "Assigned";
            this.columnAssigned.Width = 70;
            // 
            // columnLastKeepAliveSignal
            // 
            this.columnLastKeepAliveSignal.Text = "Last Keepalive Time";
            this.columnLastKeepAliveSignal.Width = 170;
            // 
            // columnTimeSinceLKAT
            // 
            this.columnTimeSinceLKAT.Text = "T - LKAT";
            this.columnTimeSinceLKAT.Width = 105;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(626, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 7;
            this.label1.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 607);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Audiobox Server Application";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminateToolStripMenuItem;
        private System.Windows.Forms.Label lblSessions;
        private System.Windows.Forms.ListView lvwSessions;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ColumnHeader columnID;
        private System.Windows.Forms.ColumnHeader columnActive;
        private System.Windows.Forms.ColumnHeader columnStarted;
        private System.Windows.Forms.RichTextBox rtbxLogConsole;
        private System.Windows.Forms.TextBox tbxCommand;
        private System.Windows.Forms.Button btnSubmitCommand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHostID;
        private System.Windows.Forms.ColumnHeader columnNumberOfClients;
        private System.Windows.Forms.ListView lvwUsers;
        private System.Windows.Forms.Label lblAssignedUnassigned;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.ColumnHeader columnUserId;
        private System.Windows.Forms.ColumnHeader columnGoogleId;
        private System.Windows.Forms.ColumnHeader columnAssigned;
        private System.Windows.Forms.ColumnHeader columnPortNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader columnLastKeepAliveSignal;
        private System.Windows.Forms.ColumnHeader columnTimeSinceLKAT;
        private System.Windows.Forms.ToolStripMenuItem youtubeDownloadmanagerToolStripMenuItem;
    }
}

