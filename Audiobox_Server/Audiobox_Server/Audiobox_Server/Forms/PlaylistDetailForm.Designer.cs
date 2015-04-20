namespace Audiobox_Server.Forms
{
    partial class PlaylistDetailForm
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
            this.lblCurrentTrack = new System.Windows.Forms.Label();
            this.lvwPlaylist = new System.Windows.Forms.ListView();
            this.columnNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTrackID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colummTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnVotesUp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnVotesDown = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblPlaylist = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCurrentTrack
            // 
            this.lblCurrentTrack.AutoSize = true;
            this.lblCurrentTrack.Location = new System.Drawing.Point(171, 17);
            this.lblCurrentTrack.Name = "lblCurrentTrack";
            this.lblCurrentTrack.Size = new System.Drawing.Size(72, 13);
            this.lblCurrentTrack.TabIndex = 11;
            this.lblCurrentTrack.Text = "Now Playing: ";
            // 
            // lvwPlaylist
            // 
            this.lvwPlaylist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(36)))), ((int)(((byte)(86)))));
            this.lvwPlaylist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnNumber,
            this.columnTrackID,
            this.colummTitle,
            this.columnVotesUp,
            this.columnVotesDown});
            this.lvwPlaylist.Font = new System.Drawing.Font("Courier New", 9F);
            this.lvwPlaylist.ForeColor = System.Drawing.Color.White;
            this.lvwPlaylist.FullRowSelect = true;
            this.lvwPlaylist.GridLines = true;
            this.lvwPlaylist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwPlaylist.Location = new System.Drawing.Point(12, 48);
            this.lvwPlaylist.Name = "lvwPlaylist";
            this.lvwPlaylist.Size = new System.Drawing.Size(476, 445);
            this.lvwPlaylist.TabIndex = 10;
            this.lvwPlaylist.UseCompatibleStateImageBehavior = false;
            this.lvwPlaylist.View = System.Windows.Forms.View.Details;
            // 
            // columnNumber
            // 
            this.columnNumber.Text = "#";
            this.columnNumber.Width = 25;
            // 
            // columnTrackID
            // 
            this.columnTrackID.Text = "ID";
            this.columnTrackID.Width = 79;
            // 
            // colummTitle
            // 
            this.colummTitle.Text = "Title";
            this.colummTitle.Width = 206;
            // 
            // columnVotesUp
            // 
            this.columnVotesUp.Text = "Votes(+)";
            this.columnVotesUp.Width = 70;
            // 
            // columnVotesDown
            // 
            this.columnVotesDown.Text = "Votes(-)";
            this.columnVotesDown.Width = 69;
            // 
            // lblPlaylist
            // 
            this.lblPlaylist.AutoSize = true;
            this.lblPlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaylist.Location = new System.Drawing.Point(12, 13);
            this.lblPlaylist.Name = "lblPlaylist";
            this.lblPlaylist.Size = new System.Drawing.Size(98, 18);
            this.lblPlaylist.TabIndex = 9;
            this.lblPlaylist.Text = "Playlist: None";
            // 
            // PlaylistDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 502);
            this.Controls.Add(this.lblCurrentTrack);
            this.Controls.Add(this.lvwPlaylist);
            this.Controls.Add(this.lblPlaylist);
            this.MaximizeBox = false;
            this.Name = "PlaylistDetailForm";
            this.Text = "PlaylistDetailForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurrentTrack;
        private System.Windows.Forms.ListView lvwPlaylist;
        private System.Windows.Forms.ColumnHeader columnNumber;
        private System.Windows.Forms.ColumnHeader columnTrackID;
        private System.Windows.Forms.ColumnHeader colummTitle;
        private System.Windows.Forms.ColumnHeader columnVotesUp;
        private System.Windows.Forms.ColumnHeader columnVotesDown;
        private System.Windows.Forms.Label lblPlaylist;
    }
}