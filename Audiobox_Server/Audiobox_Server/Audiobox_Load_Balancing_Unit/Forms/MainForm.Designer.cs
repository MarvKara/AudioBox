namespace Crowdsound_Master_Server_Application.Forms
{
    partial class MainForm
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
            this.msMainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminateServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lvServers = new System.Windows.Forms.ListView();
            this.columnServerID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnOnlineStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnIpAdress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSessions = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvUsers = new System.Windows.Forms.ListView();
            this.columnUserID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnServer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSession = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblServers = new System.Windows.Forms.Label();
            this.lblUsers = new System.Windows.Forms.Label();
            this.msMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMainMenu
            // 
            this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripSettings,
            this.aboutToolStripMenuItem,
            this.addServerToolStripMenuItem});
            this.msMainMenu.Location = new System.Drawing.Point(0, 0);
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Size = new System.Drawing.Size(894, 24);
            this.msMainMenu.TabIndex = 0;
            this.msMainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.terminateServerToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // terminateServerToolStripMenuItem
            // 
            this.terminateServerToolStripMenuItem.Name = "terminateServerToolStripMenuItem";
            this.terminateServerToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.terminateServerToolStripMenuItem.Text = "Terminate Server";
            this.terminateServerToolStripMenuItem.Click += new System.EventHandler(this.terminateServerToolStripMenuItem_Click);
            // 
            // settingsToolStripSettings
            // 
            this.settingsToolStripSettings.Name = "settingsToolStripSettings";
            this.settingsToolStripSettings.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripSettings.Text = "Settings";
            this.settingsToolStripSettings.Click += new System.EventHandler(this.settingsToolStripSettings_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(24, 20);
            this.aboutToolStripMenuItem.Text = "?";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // addServerToolStripMenuItem
            // 
            this.addServerToolStripMenuItem.Name = "addServerToolStripMenuItem";
            this.addServerToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // lvServers
            // 
            this.lvServers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(36)))), ((int)(((byte)(86)))));
            this.lvServers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnServerID,
            this.columnLocation,
            this.columnOnlineStatus,
            this.columnIpAdress,
            this.columnSessions});
            this.lvServers.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvServers.ForeColor = System.Drawing.Color.White;
            this.lvServers.GridLines = true;
            this.lvServers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvServers.HoverSelection = true;
            this.lvServers.Location = new System.Drawing.Point(12, 46);
            this.lvServers.Name = "lvServers";
            this.lvServers.Size = new System.Drawing.Size(487, 413);
            this.lvServers.TabIndex = 1;
            this.lvServers.UseCompatibleStateImageBehavior = false;
            this.lvServers.View = System.Windows.Forms.View.Details;
            // 
            // columnServerID
            // 
            this.columnServerID.Text = "S-ID";
            this.columnServerID.Width = 50;
            // 
            // columnLocation
            // 
            this.columnLocation.Text = "Country";
            this.columnLocation.Width = 130;
            // 
            // columnOnlineStatus
            // 
            this.columnOnlineStatus.Text = "Status";
            // 
            // columnIpAdress
            // 
            this.columnIpAdress.Text = "IP-Adress";
            this.columnIpAdress.Width = 125;
            // 
            // columnSessions
            // 
            this.columnSessions.Text = "SUM Sessions";
            this.columnSessions.Width = 100;
            // 
            // lvUsers
            // 
            this.lvUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(36)))), ((int)(((byte)(86)))));
            this.lvUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnUserID,
            this.columnStatus,
            this.columnServer,
            this.columnSession});
            this.lvUsers.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvUsers.ForeColor = System.Drawing.Color.White;
            this.lvUsers.FullRowSelect = true;
            this.lvUsers.GridLines = true;
            this.lvUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvUsers.HoverSelection = true;
            this.lvUsers.Location = new System.Drawing.Point(505, 46);
            this.lvUsers.MultiSelect = false;
            this.lvUsers.Name = "lvUsers";
            this.lvUsers.Size = new System.Drawing.Size(377, 413);
            this.lvUsers.TabIndex = 2;
            this.lvUsers.UseCompatibleStateImageBehavior = false;
            this.lvUsers.View = System.Windows.Forms.View.Details;
            // 
            // columnUserID
            // 
            this.columnUserID.Text = "User ID";
            this.columnUserID.Width = 80;
            // 
            // columnStatus
            // 
            this.columnStatus.Text = "Status";
            // 
            // columnServer
            // 
            this.columnServer.Text = "Curr. Server";
            this.columnServer.Width = 100;
            // 
            // columnSession
            // 
            this.columnSession.Text = "Curr. Session";
            this.columnSession.Width = 110;
            // 
            // lblServers
            // 
            this.lblServers.AutoSize = true;
            this.lblServers.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServers.Location = new System.Drawing.Point(12, 24);
            this.lblServers.Name = "lblServers";
            this.lblServers.Size = new System.Drawing.Size(71, 17);
            this.lblServers.TabIndex = 3;
            this.lblServers.Text = "Servers";
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsers.Location = new System.Drawing.Point(502, 24);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(53, 17);
            this.lblUsers.TabIndex = 4;
            this.lblUsers.Text = "Users";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 471);
            this.Controls.Add(this.lblUsers);
            this.Controls.Add(this.lblServers);
            this.Controls.Add(this.lvUsers);
            this.Controls.Add(this.lvServers);
            this.Controls.Add(this.msMainMenu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.msMainMenu;
            this.Name = "MainForm";
            this.Text = "Crowdsound MSA V.X.X";
            this.msMainMenu.ResumeLayout(false);
            this.msMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminateServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripSettings;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ListView lvServers;
        private System.Windows.Forms.ListView lvUsers;
        private System.Windows.Forms.Label lblServers;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.ColumnHeader columnServerID;
        private System.Windows.Forms.ColumnHeader columnLocation;
        private System.Windows.Forms.ColumnHeader columnOnlineStatus;
        private System.Windows.Forms.ColumnHeader columnSessions;
        private System.Windows.Forms.ColumnHeader columnUserID;
        private System.Windows.Forms.ColumnHeader columnStatus;
        private System.Windows.Forms.ColumnHeader columnServer;
        private System.Windows.Forms.ColumnHeader columnSession;
        private System.Windows.Forms.ColumnHeader columnIpAdress;
        private System.Windows.Forms.ToolStripMenuItem addServerToolStripMenuItem;
    }
}