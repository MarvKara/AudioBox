using System.Windows.Forms;
using System.Threading;
using Audiobox_Server.Modules.SessionManagement;
using System.Collections.Generic;

namespace Audiobox_Server.Forms
{
    public partial class PlaylistDetailForm : Form
    {
        private Thread dataReader;
        string sid;

        public PlaylistDetailForm(string sessionID)
        {
            this.Icon = Audiobox_Server.Properties.Resources.Audiobox_Icon;
            InitializeComponent();
            sid = sessionID;
            dataReader = new Thread(ReaderMethod);
            dataReader.IsBackground = true;
            dataReader.Start();
        }

        private void ReaderMethod()
        {
            RefreshPlaylistView(sid);
            while(true)
            {
                Thread.Sleep(1000);
                RefreshPlaylistView(sid);
            }
        }

        /// <summary>
        /// Refreshes the ListView containing the playlist of the current session
        /// </summary>
        /// <param name="session"></param>
        private void RefreshPlaylistView(string sessionID)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => RefreshPlaylistView(sessionID)));
                return;
            }

            lblCurrentTrack.Text = "Now: " + SessionManager.FindSessionBySessionId(sessionID).Playlist.GetCurrentTrackTitle();
            lblPlaylist.Text = "Playlist: " + SessionManager.FindSessionBySessionId(sessionID).Id;
            lvwPlaylist.Items.Clear();
            lvwPlaylist.Items.AddRange(SessionManager.FindSessionBySessionId(sessionID).Playlist.ToListViewItems().ToArray());
            lvwPlaylist.Refresh();
        }
    }
}
