namespace Crowdsound_Slave_Server_Application.Forms
{
    public partial class AboutForm
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
            this.pbxIcon = new System.Windows.Forms.PictureBox();
            this.tbxProductName = new System.Windows.Forms.TextBox();
            this.tbxDeveloperTeam = new System.Windows.Forms.TextBox();
            this.tbxVersionNumber = new System.Windows.Forms.TextBox();
            this.rtbxTeamMembers = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxIcon
            // 
            this.pbxIcon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxIcon.Location = new System.Drawing.Point(12, 6);
            this.pbxIcon.Name = "pbxIcon";
            this.pbxIcon.Size = new System.Drawing.Size(64, 64);
            this.pbxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxIcon.TabIndex = 0;
            this.pbxIcon.TabStop = false;
            // 
            // tbxProductName
            // 
            this.tbxProductName.Enabled = false;
            this.tbxProductName.Location = new System.Drawing.Point(88, 6);
            this.tbxProductName.Name = "tbxProductName";
            this.tbxProductName.ReadOnly = true;
            this.tbxProductName.Size = new System.Drawing.Size(188, 20);
            this.tbxProductName.TabIndex = 2;
            // 
            // tbxDeveloperTeam
            // 
            this.tbxDeveloperTeam.Enabled = false;
            this.tbxDeveloperTeam.Location = new System.Drawing.Point(88, 32);
            this.tbxDeveloperTeam.Name = "tbxDeveloperTeam";
            this.tbxDeveloperTeam.ReadOnly = true;
            this.tbxDeveloperTeam.Size = new System.Drawing.Size(252, 20);
            this.tbxDeveloperTeam.TabIndex = 4;
            // 
            // tbxVersionNumber
            // 
            this.tbxVersionNumber.Enabled = false;
            this.tbxVersionNumber.Location = new System.Drawing.Point(282, 6);
            this.tbxVersionNumber.Name = "tbxVersionNumber";
            this.tbxVersionNumber.ReadOnly = true;
            this.tbxVersionNumber.Size = new System.Drawing.Size(58, 20);
            this.tbxVersionNumber.TabIndex = 5;
            // 
            // rtbxTeamMembers
            // 
            this.rtbxTeamMembers.Enabled = false;
            this.rtbxTeamMembers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbxTeamMembers.Location = new System.Drawing.Point(12, 75);
            this.rtbxTeamMembers.Name = "rtbxTeamMembers";
            this.rtbxTeamMembers.ReadOnly = true;
            this.rtbxTeamMembers.Size = new System.Drawing.Size(333, 152);
            this.rtbxTeamMembers.TabIndex = 6;
            this.rtbxTeamMembers.Text = "";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 231);
            this.Controls.Add(this.rtbxTeamMembers);
            this.Controls.Add(this.tbxVersionNumber);
            this.Controls.Add(this.tbxDeveloperTeam);
            this.Controls.Add(this.tbxProductName);
            this.Controls.Add(this.pbxIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AboutForm";
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxIcon;
        private System.Windows.Forms.TextBox tbxProductName;
        private System.Windows.Forms.TextBox tbxDeveloperTeam;
        private System.Windows.Forms.TextBox tbxVersionNumber;
        private System.Windows.Forms.RichTextBox rtbxTeamMembers;
    }
}