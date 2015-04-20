namespace CommandInterpreterTestTool
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
            this.btnTest = new System.Windows.Forms.Button();
            this.tbxCommand = new System.Windows.Forms.TextBox();
            this.rtbxOutput = new System.Windows.Forms.RichTextBox();
            this.tbxGetForm = new System.Windows.Forms.TextBox();
            this.btnMakeGet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHttp = new System.Windows.Forms.Label();
            this.tbxHttpCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRegUser = new System.Windows.Forms.Button();
            this.btnRegHost = new System.Windows.Forms.Button();
            this.btnRefreshGid = new System.Windows.Forms.Button();
            this.btnRegClient = new System.Windows.Forms.Button();
            this.btnVoteTrack = new System.Windows.Forms.Button();
            this.btnGetPlaylist = new System.Windows.Forms.Button();
            this.btnGetPlaylistUpdate = new System.Windows.Forms.Button();
            this.btnYoutubeSearch = new System.Windows.Forms.Button();
            this.btnAddYoutubeTrack = new System.Windows.Forms.Button();
            this.btnLogoutUser = new System.Windows.Forms.Button();
            this.btnDestroySession = new System.Windows.Forms.Button();
            this.btnAddVolume = new System.Windows.Forms.Button();
            this.btnGetVolume = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(228, 103);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(62, 20);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // tbxCommand
            // 
            this.tbxCommand.Location = new System.Drawing.Point(13, 13);
            this.tbxCommand.Name = "tbxCommand";
            this.tbxCommand.Size = new System.Drawing.Size(426, 20);
            this.tbxCommand.TabIndex = 1;
            // 
            // rtbxOutput
            // 
            this.rtbxOutput.Location = new System.Drawing.Point(228, 129);
            this.rtbxOutput.Name = "rtbxOutput";
            this.rtbxOutput.Size = new System.Drawing.Size(211, 396);
            this.rtbxOutput.TabIndex = 2;
            this.rtbxOutput.Text = "";
            // 
            // tbxGetForm
            // 
            this.tbxGetForm.Location = new System.Drawing.Point(16, 68);
            this.tbxGetForm.Name = "tbxGetForm";
            this.tbxGetForm.Size = new System.Drawing.Size(423, 20);
            this.tbxGetForm.TabIndex = 3;
            // 
            // btnMakeGet
            // 
            this.btnMakeGet.Location = new System.Drawing.Point(16, 39);
            this.btnMakeGet.Name = "btnMakeGet";
            this.btnMakeGet.Size = new System.Drawing.Size(146, 23);
            this.btnMakeGet.TabIndex = 4;
            this.btnMakeGet.Text = "Convert to Get-Statement";
            this.btnMakeGet.UseVisualStyleBackColor = true;
            this.btnMakeGet.Click += new System.EventHandler(this.btnMakeGet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "-->";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "vvv";
            // 
            // lblHttp
            // 
            this.lblHttp.AutoSize = true;
            this.lblHttp.Location = new System.Drawing.Point(296, 107);
            this.lblHttp.Name = "lblHttp";
            this.lblHttp.Size = new System.Drawing.Size(78, 13);
            this.lblHttp.TabIndex = 7;
            this.lblHttp.Text = "HTTP_CODE: ";
            // 
            // tbxHttpCode
            // 
            this.tbxHttpCode.Enabled = false;
            this.tbxHttpCode.Location = new System.Drawing.Point(380, 104);
            this.tbxHttpCode.Name = "tbxHttpCode";
            this.tbxHttpCode.Size = new System.Drawing.Size(59, 20);
            this.tbxHttpCode.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "------------------------------------------------------------------";
            // 
            // btnRegUser
            // 
            this.btnRegUser.Location = new System.Drawing.Point(16, 153);
            this.btnRegUser.Name = "btnRegUser";
            this.btnRegUser.Size = new System.Drawing.Size(197, 23);
            this.btnRegUser.TabIndex = 10;
            this.btnRegUser.Text = "REGUSER";
            this.btnRegUser.UseVisualStyleBackColor = true;
            this.btnRegUser.Click += new System.EventHandler(this.btnRegUser_Click);
            // 
            // btnRegHost
            // 
            this.btnRegHost.Location = new System.Drawing.Point(16, 182);
            this.btnRegHost.Name = "btnRegHost";
            this.btnRegHost.Size = new System.Drawing.Size(197, 23);
            this.btnRegHost.TabIndex = 11;
            this.btnRegHost.Text = "REGHOST";
            this.btnRegHost.UseVisualStyleBackColor = true;
            this.btnRegHost.Click += new System.EventHandler(this.btnRegHost_Click);
            // 
            // btnRefreshGid
            // 
            this.btnRefreshGid.Location = new System.Drawing.Point(16, 211);
            this.btnRefreshGid.Name = "btnRefreshGid";
            this.btnRefreshGid.Size = new System.Drawing.Size(197, 23);
            this.btnRefreshGid.TabIndex = 12;
            this.btnRefreshGid.Text = "REFRESHGID";
            this.btnRefreshGid.UseVisualStyleBackColor = true;
            this.btnRefreshGid.Click += new System.EventHandler(this.btnRefreshGid_Click);
            // 
            // btnRegClient
            // 
            this.btnRegClient.Location = new System.Drawing.Point(16, 240);
            this.btnRegClient.Name = "btnRegClient";
            this.btnRegClient.Size = new System.Drawing.Size(197, 23);
            this.btnRegClient.TabIndex = 13;
            this.btnRegClient.Text = "REGCLIENT";
            this.btnRegClient.UseVisualStyleBackColor = true;
            this.btnRegClient.Click += new System.EventHandler(this.btnRegClient_Click);
            // 
            // btnVoteTrack
            // 
            this.btnVoteTrack.Location = new System.Drawing.Point(16, 269);
            this.btnVoteTrack.Name = "btnVoteTrack";
            this.btnVoteTrack.Size = new System.Drawing.Size(197, 23);
            this.btnVoteTrack.TabIndex = 14;
            this.btnVoteTrack.Text = "VOTETRACK";
            this.btnVoteTrack.UseVisualStyleBackColor = true;
            this.btnVoteTrack.Click += new System.EventHandler(this.btnVoteTrack_Click);
            // 
            // btnGetPlaylist
            // 
            this.btnGetPlaylist.Location = new System.Drawing.Point(16, 298);
            this.btnGetPlaylist.Name = "btnGetPlaylist";
            this.btnGetPlaylist.Size = new System.Drawing.Size(197, 23);
            this.btnGetPlaylist.TabIndex = 15;
            this.btnGetPlaylist.Text = "GETPLAYLIST";
            this.btnGetPlaylist.UseVisualStyleBackColor = true;
            this.btnGetPlaylist.Click += new System.EventHandler(this.btnGetPlaylist_Click);
            // 
            // btnGetPlaylistUpdate
            // 
            this.btnGetPlaylistUpdate.Location = new System.Drawing.Point(16, 327);
            this.btnGetPlaylistUpdate.Name = "btnGetPlaylistUpdate";
            this.btnGetPlaylistUpdate.Size = new System.Drawing.Size(197, 23);
            this.btnGetPlaylistUpdate.TabIndex = 16;
            this.btnGetPlaylistUpdate.Text = "GETPLAYLISTUPDATETIME";
            this.btnGetPlaylistUpdate.UseVisualStyleBackColor = true;
            this.btnGetPlaylistUpdate.Click += new System.EventHandler(this.btnGetPlaylistUpdate_Click);
            // 
            // btnYoutubeSearch
            // 
            this.btnYoutubeSearch.Location = new System.Drawing.Point(16, 357);
            this.btnYoutubeSearch.Name = "btnYoutubeSearch";
            this.btnYoutubeSearch.Size = new System.Drawing.Size(197, 23);
            this.btnYoutubeSearch.TabIndex = 17;
            this.btnYoutubeSearch.Text = "YOUTUBESEARCH";
            this.btnYoutubeSearch.UseVisualStyleBackColor = true;
            this.btnYoutubeSearch.Click += new System.EventHandler(this.btnYoutubeSearch_Click);
            // 
            // btnAddYoutubeTrack
            // 
            this.btnAddYoutubeTrack.Location = new System.Drawing.Point(16, 384);
            this.btnAddYoutubeTrack.Name = "btnAddYoutubeTrack";
            this.btnAddYoutubeTrack.Size = new System.Drawing.Size(197, 23);
            this.btnAddYoutubeTrack.TabIndex = 18;
            this.btnAddYoutubeTrack.Text = "ADDYOUTUBETRACK";
            this.btnAddYoutubeTrack.UseVisualStyleBackColor = true;
            this.btnAddYoutubeTrack.Click += new System.EventHandler(this.btnAddYoutubeTrack_Click);
            // 
            // btnLogoutUser
            // 
            this.btnLogoutUser.Location = new System.Drawing.Point(16, 413);
            this.btnLogoutUser.Name = "btnLogoutUser";
            this.btnLogoutUser.Size = new System.Drawing.Size(197, 23);
            this.btnLogoutUser.TabIndex = 19;
            this.btnLogoutUser.Text = "LOGOUTUSER";
            this.btnLogoutUser.UseVisualStyleBackColor = true;
            this.btnLogoutUser.Click += new System.EventHandler(this.btnLogoutUser_Click);
            // 
            // btnDestroySession
            // 
            this.btnDestroySession.Location = new System.Drawing.Point(16, 442);
            this.btnDestroySession.Name = "btnDestroySession";
            this.btnDestroySession.Size = new System.Drawing.Size(197, 23);
            this.btnDestroySession.TabIndex = 20;
            this.btnDestroySession.Text = "DESTROYSESSION";
            this.btnDestroySession.UseVisualStyleBackColor = true;
            this.btnDestroySession.Click += new System.EventHandler(this.btnDestroySession_Click);
            // 
            // btnAddVolume
            // 
            this.btnAddVolume.Location = new System.Drawing.Point(16, 471);
            this.btnAddVolume.Name = "btnAddVolume";
            this.btnAddVolume.Size = new System.Drawing.Size(197, 23);
            this.btnAddVolume.TabIndex = 21;
            this.btnAddVolume.Text = "ADDVOLUME";
            this.btnAddVolume.UseVisualStyleBackColor = true;
            this.btnAddVolume.Click += new System.EventHandler(this.btnAddVolume_Click);
            // 
            // btnGetVolume
            // 
            this.btnGetVolume.Location = new System.Drawing.Point(16, 500);
            this.btnGetVolume.Name = "btnGetVolume";
            this.btnGetVolume.Size = new System.Drawing.Size(197, 23);
            this.btnGetVolume.TabIndex = 22;
            this.btnGetVolume.Text = "GETVOLUME";
            this.btnGetVolume.UseVisualStyleBackColor = true;
            this.btnGetVolume.Click += new System.EventHandler(this.btnGetVolume_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 537);
            this.Controls.Add(this.btnGetVolume);
            this.Controls.Add(this.btnAddVolume);
            this.Controls.Add(this.btnDestroySession);
            this.Controls.Add(this.btnLogoutUser);
            this.Controls.Add(this.btnAddYoutubeTrack);
            this.Controls.Add(this.btnYoutubeSearch);
            this.Controls.Add(this.btnGetPlaylistUpdate);
            this.Controls.Add(this.btnGetPlaylist);
            this.Controls.Add(this.btnVoteTrack);
            this.Controls.Add(this.btnRegClient);
            this.Controls.Add(this.btnRefreshGid);
            this.Controls.Add(this.btnRegHost);
            this.Controls.Add(this.btnRegUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxHttpCode);
            this.Controls.Add(this.lblHttp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMakeGet);
            this.Controls.Add(this.tbxGetForm);
            this.Controls.Add(this.rtbxOutput);
            this.Controls.Add(this.tbxCommand);
            this.Controls.Add(this.btnTest);
            this.Name = "MainForm";
            this.Text = "CommandInterpreterTestTool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox tbxCommand;
        private System.Windows.Forms.RichTextBox rtbxOutput;
        private System.Windows.Forms.TextBox tbxGetForm;
        private System.Windows.Forms.Button btnMakeGet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblHttp;
        private System.Windows.Forms.TextBox tbxHttpCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRegUser;
        private System.Windows.Forms.Button btnRegHost;
        private System.Windows.Forms.Button btnRefreshGid;
        private System.Windows.Forms.Button btnRegClient;
        private System.Windows.Forms.Button btnVoteTrack;
        private System.Windows.Forms.Button btnGetPlaylist;
        private System.Windows.Forms.Button btnGetPlaylistUpdate;
        private System.Windows.Forms.Button btnYoutubeSearch;
        private System.Windows.Forms.Button btnAddYoutubeTrack;
        private System.Windows.Forms.Button btnLogoutUser;
        private System.Windows.Forms.Button btnDestroySession;
        private System.Windows.Forms.Button btnAddVolume;
        private System.Windows.Forms.Button btnGetVolume;
    }
}

