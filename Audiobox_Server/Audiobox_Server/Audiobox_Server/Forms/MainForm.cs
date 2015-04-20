using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Audiobox_Server.General;
using Audiobox_Server.Modules.AudioboxConsole;
using Audiobox_Server.Modules.CommandInterface;
using Audiobox_Server.Modules.SessionManagement.Objects;
using Audiobox_Server.Modules.SessionManagement;
using Audiobox_Server.Modules.UserManagement;
using Audiobox_Server.Modules.Support;

namespace Audiobox_Server.Forms
{
    /// <summary>
    /// The MainForm
    /// </summary>
    public partial class MainForm : Form
    {
        SessionManager sessionManager;
        CommandInterpreter commandInterpreter;

        public MainForm()
        {
            this.Icon = Audiobox_Server.Properties.Resources.Audiobox_Icon;

            InitializeComponent();

            this.Text = About.PRODUCTNAME + " " + About.VERSION_NUMBER;
            this.DoubleBuffered = true;

            HookupEventListeners();

            UserManager.Initialize();
            Settings.Initialize();
            ConsoleCommandWords.Initialize();
            Actions.CreateFolderStructures();

            commandInterpreter = new CommandInterpreter();
            sessionManager = new SessionManager();
        }

        #region EVENT_HANDLING_METHODS

        void UserManagement_UpdateUserData(List<ListViewItem> userList, int assigned, int unassigned)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => RefreshUserView(userList, assigned, unassigned)));
            }
            else
            {
                RefreshUserView(userList, assigned, unassigned);
            }
        }

        void SessionManager_SessionStatusChanged(List<Session> sessions)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => RefreshSessionView(sessions)));
            }
            else
            {
                RefreshSessionView(sessions);
            }
        }

        void SessionManager_NewSession(List<Session> sessions)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => RefreshSessionView(sessions)));
            }
            else
            {
                RefreshSessionView(sessions);
            }
        }

        void LogConsole_NewEntry(List<string> log)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => WriteToLogConsole(log)));
            }
            else
            {
                WriteToLogConsole(log);
            }
        }

        #endregion

        private void HookupEventListeners()
        {
            LogConsole.NewEntry += new LogConsole.NewLogConsoleEntryHandler(LogConsole_NewEntry);
            SessionManager.NewSession += new SessionManager.NewSessionHandler(SessionManager_NewSession);
            SessionManager.SessionStatusChanged += new SessionManager.SessionStatusChangedHandler(SessionManager_SessionStatusChanged);
            UserManager.UpdateUserData += new UserManager.UpdateUserDataHandler(UserManagement_UpdateUserData);
        }

        /// <summary>
        /// Refreshes the UserView which contains all known Users
        /// </summary>
        /// <param name="userList"></param>
        /// <param name="assigned"></param>
        /// <param name="unassigned"></param>
        private void RefreshUserView(List<ListViewItem> userList, int assigned, int unassigned)
        {
            lvwUsers.Items.Clear();
            foreach (ListViewItem lvi in userList)
            {
                lvwUsers.Items.Add(lvi);
            }
            lvwUsers.Refresh();

            lblAssignedUnassigned.Text = "(Un)-/Assigned: " + unassigned.ToString() + " / " + assigned.ToString();
        }

        /// <summary>
        /// Refreshes the ListView containing the sessions
        /// </summary>
        private void RefreshSessionView(List<Session> sessions)
        {
            lvwSessions.Items.Clear();
            foreach (Session session in sessions)
            {
                lvwSessions.Items.Add(session.ToListViewItem());
            }
            lvwSessions.Refresh();
        }

        /// <summary>
        /// Writes output to LogConsole window
        /// </summary>
        /// <param name="log"></param>
        public void WriteToLogConsole(List<string> log)
        {
            rtbxLogConsole.Clear();
            foreach (string line in log)
            {
                rtbxLogConsole.AppendText(line);
            }
            rtbxLogConsole.ScrollToCaret();
        }

        /// <summary>
        /// Called when the mainform is ready
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Shown(object sender, EventArgs e)
        {
            LogConsole.Initialize();
            this.FocusInputField();
        } 

        /// <summary>
        /// Triggers what happens when the enter key is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSubmitCommand.PerformClick();
            }
        }

        #region BUTTONS

        /// <summary>
        /// Actions taken when the LogConsoles submit button is hit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmitCommand_Click(object sender, EventArgs e)
        {
            LogConsole.AttemptParsing(tbxCommand.Text.ToLower());
            this.ClearInputField();
            this.FocusInputField();
        }  

        #endregion

        #region DIRECT LOGCONSOLE INTERACTIONS

        private void rtbxLogConsole_Enter(object sender, EventArgs e)
        {
            label1.Focus();
        }

        private void rtbxLogConsole_Leave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void LogConsoleEnlargeFont()
        {
            rtbxLogConsole.Font = new Font(rtbxLogConsole.Font.FontFamily, rtbxLogConsole.Font.Size + 1.0f);
        }

        private void LogConsoleShrinkFont()
        {
            rtbxLogConsole.Font = new Font(rtbxLogConsole.Font.FontFamily, rtbxLogConsole.Font.Size - 1.0f);
        }

        /// <summary>
        /// Clears the inputfield
        /// </summary>
        private void ClearInputField()
        {
            tbxCommand.Text = string.Empty;
        }

        /// <summary>
        /// Focuses the Input Field of the LogConsole
        /// </summary>
        private void FocusInputField()
        {
            tbxCommand.Focus();
        }

        #endregion

        #region MENU_TOOLSTRIP_EVENTS

        /// <summary>
        /// Opens the Settingsform
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        /// <summary>
        /// Opens the AboutForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        /// <summary>
        /// Triggers the TerminateServer method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void terminateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actions.TerminateServer();
        }

        #endregion

        private void lvwSessions_DoubleClick(object sender, EventArgs e)
        {
            if (lvwSessions.SelectedIndices.Count > 0)
            {
                OpenNewPlayListDetailForm(lvwSessions.SelectedItems[0].Text);
            }
        }

        private void OpenNewPlayListDetailForm(string sessionID)
        {
            PlaylistDetailForm pdf = new PlaylistDetailForm(lvwSessions.SelectedItems[0].Text);
            pdf.Show();
        }

        private void youtubeDownloadmanagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YoutubeDownloadManagerForm ydmf = new YoutubeDownloadManagerForm();
            ydmf.Show();
        }
    }
}