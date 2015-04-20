using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Crowdsound_Slave_Server_Application.Support;
using Crowdsound_Slave_Server_Application.General;

namespace Crowdsound_Slave_Server_Application.Forms
{
    /// <summary>
    /// The MainForm, which represents the Main GUI Window, which is shown on program launch
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2014
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Text = About.PRODUCTNAME + " " + About.VERSION_NUMBER;
            Settings.Initialize();
        }

        #region MENU_TOOL_STRIP

        private void terminateServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actions.TerminateServer();
        }

        private void settingsToolStripSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        #endregion
    }
}