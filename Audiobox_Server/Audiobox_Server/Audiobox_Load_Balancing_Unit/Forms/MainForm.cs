using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Crowdsound_Master_Server_Application.Support;
using Crowdsound_Master_Server_Application.General;
using Crowdsound_Master_Server_Application.Modules.ServerManagement;

namespace Crowdsound_Master_Server_Application.Forms
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
        }

        public void UpdateServerList(List<SlaveServer> servers)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => RefreshServerView(servers)));
                return;
            }
        }

        private void RefreshServerView(List<SlaveServer> servers)
        {
            List<ListViewItem> serverItems = new List<ListViewItem>();
            foreach (SlaveServer server in servers)
            {
                serverItems.Add(server.ConvertToListViewItem());
            }

            lvServers.Items.Clear();
            foreach (ListViewItem lvi in serverItems)
            {
                lvServers.Items.Add(lvi);
            }
            lvServers.Refresh();
        }

        #region MENU_TOOL_STRIP

        private void terminateServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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