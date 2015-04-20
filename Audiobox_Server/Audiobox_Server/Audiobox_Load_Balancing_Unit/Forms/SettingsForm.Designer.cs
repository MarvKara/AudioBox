namespace Crowdsound_Master_Server_Application.Forms
{
    partial class SettingsForm
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
            this.lblServerUrl = new System.Windows.Forms.Label();
            this.tbxServerUrl = new System.Windows.Forms.TextBox();
            this.tbxPortRange = new System.Windows.Forms.TextBox();
            this.lblPortRange = new System.Windows.Forms.Label();
            this.btnApplySettings = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblServerUrl
            // 
            this.lblServerUrl.AutoSize = true;
            this.lblServerUrl.Location = new System.Drawing.Point(8, 9);
            this.lblServerUrl.Name = "lblServerUrl";
            this.lblServerUrl.Size = new System.Drawing.Size(66, 13);
            this.lblServerUrl.TabIndex = 0;
            this.lblServerUrl.Text = "Server URL:";
            // 
            // tbxServerUrl
            // 
            this.tbxServerUrl.Location = new System.Drawing.Point(80, 6);
            this.tbxServerUrl.Name = "tbxServerUrl";
            this.tbxServerUrl.Size = new System.Drawing.Size(189, 20);
            this.tbxServerUrl.TabIndex = 1;
            // 
            // tbxPortRange
            // 
            this.tbxPortRange.Location = new System.Drawing.Point(80, 29);
            this.tbxPortRange.Name = "tbxPortRange";
            this.tbxPortRange.Size = new System.Drawing.Size(189, 20);
            this.tbxPortRange.TabIndex = 3;
            // 
            // lblPortRange
            // 
            this.lblPortRange.AutoSize = true;
            this.lblPortRange.Location = new System.Drawing.Point(8, 32);
            this.lblPortRange.Name = "lblPortRange";
            this.lblPortRange.Size = new System.Drawing.Size(64, 13);
            this.lblPortRange.TabIndex = 2;
            this.lblPortRange.Text = "Port Range:";
            // 
            // btnApplySettings
            // 
            this.btnApplySettings.Location = new System.Drawing.Point(194, 55);
            this.btnApplySettings.Name = "btnApplySettings";
            this.btnApplySettings.Size = new System.Drawing.Size(75, 23);
            this.btnApplySettings.TabIndex = 4;
            this.btnApplySettings.Text = "Apply";
            this.btnApplySettings.UseVisualStyleBackColor = true;
            this.btnApplySettings.Click += new System.EventHandler(this.btnApplySettings_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(113, 55);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 82);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApplySettings);
            this.Controls.Add(this.tbxPortRange);
            this.Controls.Add(this.lblPortRange);
            this.Controls.Add(this.tbxServerUrl);
            this.Controls.Add(this.lblServerUrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblServerUrl;
        private System.Windows.Forms.TextBox tbxServerUrl;
        private System.Windows.Forms.TextBox tbxPortRange;
        private System.Windows.Forms.Label lblPortRange;
        private System.Windows.Forms.Button btnApplySettings;
        private System.Windows.Forms.Button btnCancel;
    }
}