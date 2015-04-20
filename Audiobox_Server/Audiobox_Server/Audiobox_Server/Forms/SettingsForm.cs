using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Audiobox_Server.Modules.Support;

namespace Audiobox_Server.Forms
{
    public partial class SettingsForm : Form
    {
        public delegate void SettingsChangedHandler();
        public static event SettingsChangedHandler SettingsChanged;

        #region EVENT_HANDLING_METHODS

        public static void OnSettingsChanged()
        {
            if (SettingsChanged != null)
            {
                SettingsChanged();
            }
        }

        #endregion

        /// <summary>
        /// Constructor of the Form
        /// </summary>
        public SettingsForm()
        {
            this.Icon = Audiobox_Server.Properties.Resources.Audiobox_Icon;
            InitializeComponent();
            tbxServerUrl.Text = Settings.APPLICATION_URL;
            tbxPortRange.Text = Settings.STREAM_PORTRANGE[0] + ":" + Settings.STREAM_PORTRANGE[1];
        }

        /// <summary>
        /// Click event code for the apply button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApplySettings_Click(object sender, EventArgs e)
        {
            string serverUrl = (string)Settings.ParseSetting("APPLICATION_URL", tbxServerUrl.Text);
            int[] streamPortRange = (int[])Settings.ParseSetting("STREAM_PORTRANGE", tbxPortRange.Text);

            List<object> settings = new List<object>();
            settings.Add(serverUrl);
            settings.Add(streamPortRange);

            foreach(object setting in settings)
            {
                if (setting == null)
                {
                    MessageBox.Show("Error! Invalid value entered for setting. Please check your input!");
                    return;
                }
            }

            Settings.Save(settings);

            OnSettingsChanged();
            this.Close();
        }

        /// <summary>
        /// Click event code for the cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
