namespace Audiobox_Server.Forms
{
    partial class YoutubeDownloadManagerForm
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
            this.lvDownloads = new System.Windows.Forms.ListView();
            this.columnURL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnOwner = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnProgress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.progressBar4 = new System.Windows.Forms.ProgressBar();
            this.progressBar5 = new System.Windows.Forms.ProgressBar();
            this.lvQueue = new System.Windows.Forms.ListView();
            this.columnDownloadURl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDownloadOwner = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnInfo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvDownloads
            // 
            this.lvDownloads.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(36)))), ((int)(((byte)(86)))));
            this.lvDownloads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnURL,
            this.columnOwner,
            this.columnProgress});
            this.lvDownloads.Font = new System.Drawing.Font("Courier New", 9F);
            this.lvDownloads.ForeColor = System.Drawing.Color.White;
            this.lvDownloads.FullRowSelect = true;
            this.lvDownloads.GridLines = true;
            this.lvDownloads.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvDownloads.Location = new System.Drawing.Point(12, 178);
            this.lvDownloads.Name = "lvDownloads";
            this.lvDownloads.Scrollable = false;
            this.lvDownloads.Size = new System.Drawing.Size(470, 115);
            this.lvDownloads.TabIndex = 0;
            this.lvDownloads.UseCompatibleStateImageBehavior = false;
            this.lvDownloads.View = System.Windows.Forms.View.Details;
            // 
            // columnURL
            // 
            this.columnURL.Text = "URL";
            this.columnURL.Width = 120;
            // 
            // columnOwner
            // 
            this.columnOwner.Text = "Session";
            this.columnOwner.Width = 80;
            // 
            // columnProgress
            // 
            this.columnProgress.Text = "Progress";
            this.columnProgress.Width = 265;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Downloads";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(215, 203);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(267, 17);
            this.progressBar1.TabIndex = 2;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(215, 220);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(267, 17);
            this.progressBar2.TabIndex = 3;
            // 
            // progressBar3
            // 
            this.progressBar3.Location = new System.Drawing.Point(215, 237);
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(267, 17);
            this.progressBar3.TabIndex = 4;
            // 
            // progressBar4
            // 
            this.progressBar4.Location = new System.Drawing.Point(215, 254);
            this.progressBar4.Name = "progressBar4";
            this.progressBar4.Size = new System.Drawing.Size(267, 17);
            this.progressBar4.TabIndex = 5;
            // 
            // progressBar5
            // 
            this.progressBar5.Location = new System.Drawing.Point(215, 271);
            this.progressBar5.Name = "progressBar5";
            this.progressBar5.Size = new System.Drawing.Size(267, 17);
            this.progressBar5.TabIndex = 6;
            // 
            // lvQueue
            // 
            this.lvQueue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(36)))), ((int)(((byte)(86)))));
            this.lvQueue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnDownloadURl,
            this.columnDownloadOwner,
            this.columnInfo});
            this.lvQueue.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvQueue.ForeColor = System.Drawing.Color.White;
            this.lvQueue.FullRowSelect = true;
            this.lvQueue.GridLines = true;
            this.lvQueue.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvQueue.Location = new System.Drawing.Point(12, 31);
            this.lvQueue.Name = "lvQueue";
            this.lvQueue.Size = new System.Drawing.Size(470, 117);
            this.lvQueue.TabIndex = 7;
            this.lvQueue.UseCompatibleStateImageBehavior = false;
            this.lvQueue.View = System.Windows.Forms.View.Details;
            // 
            // columnDownloadURl
            // 
            this.columnDownloadURl.Text = "URL";
            this.columnDownloadURl.Width = 120;
            // 
            // columnDownloadOwner
            // 
            this.columnDownloadOwner.Text = "Session";
            this.columnDownloadOwner.Width = 80;
            // 
            // columnInfo
            // 
            this.columnInfo.Text = "Info";
            this.columnInfo.Width = 245;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Downloads in Queue";
            // 
            // YoutubeDownloadManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 306);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvQueue);
            this.Controls.Add(this.progressBar5);
            this.Controls.Add(this.progressBar4);
            this.Controls.Add(this.progressBar3);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvDownloads);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "YoutubeDownloadManagerForm";
            this.Text = "Audiobox Server - Youtube Downloads";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvDownloads;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnURL;
        private System.Windows.Forms.ColumnHeader columnOwner;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar3;
        private System.Windows.Forms.ProgressBar progressBar4;
        private System.Windows.Forms.ProgressBar progressBar5;
        private System.Windows.Forms.ColumnHeader columnProgress;
        private System.Windows.Forms.ListView lvQueue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader columnDownloadURl;
        private System.Windows.Forms.ColumnHeader columnDownloadOwner;
        private System.Windows.Forms.ColumnHeader columnInfo;
    }
}