using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace CommandInterpreterTestTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string command = tbxGetForm.Text;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:9999/" + command);

            HttpWebResponse resp;
            string statuscode = string.Empty;
            int statusnumber = 0;
            try
            {
                resp = (HttpWebResponse)req.GetResponse();
                statuscode = resp.StatusCode.ToString();
                statusnumber = (int)resp.StatusCode;
                StreamReader sr = new StreamReader(resp.GetResponseStream());
                rtbxOutput.AppendText(sr.ReadToEnd() + "\n");
            }
            catch(WebException we)
            {
                statuscode = we.Status.ToString();
                if (we.Message.Contains("401"))
                {
                    statusnumber = 401;
                }
                else if (we.Message.Contains("403"))
                {
                    statusnumber = 403;
                }
                else if (we.Message.Contains("422"))
                {
                    statusnumber = 422;
                }
                else if (we.Message.Contains("501"))
                {
                    statusnumber = 501;
                }
                else
                {
                    statusnumber = 400;
                }
                rtbxOutput.AppendText("ERROR" + "\n");
            }

            tbxHttpCode.Text = statusnumber.ToString();
        }

        private void btnMakeGet_Click(object sender, EventArgs e)
        {
            string[] raw = tbxCommand.Text.Split(' ');

            string output = '?' + raw[0];

            for (int i = 1; i < raw.Length; i++)
            {
                output += '&' + raw[i];
            }

            tbxGetForm.Text = output;
        }

        private static string GenerateRandomGoogleId()
        {
            char[] raw = new char[8];
            for (int i = 0; i < 8; i++)
            {
                raw[i] = GenerateRandomNumber();
            }
            string id = new string(raw);
            return id;
        }

        /// <summary>
        /// Generates a random char containing a number between 0 and 9
        /// </summary>
        /// <returns></returns>
        public static char GenerateRandomNumber()
        {
            char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            return numbers[GeneralObjects.random.Next(0, numbers.Length)];
        }

        private void btnRegUser_Click(object sender, EventArgs e)
        {
            tbxGetForm.Text = "?COMMAND=REGUSER&GOOGLEID=" + GenerateRandomGoogleId();
        }

        private void btnRegHost_Click(object sender, EventArgs e)
        {
            tbxGetForm.Text = "?COMMAND=REGHOST&USERID=0";
        }

        private void btnRefreshGid_Click(object sender, EventArgs e)
        {
            tbxGetForm.Text = "?COMMAND=REFRESHGID&USERID=0&GOOGLEID=00001111";
        }

        private void btnRegClient_Click(object sender, EventArgs e)
        {
            tbxGetForm.Text = "?COMMAND=REGCLIENT&USERID=1&SESSIONID=0000";
        }

        private void btnVoteTrack_Click(object sender, EventArgs e)
        {
            tbxGetForm.Text = "?COMMAND=VOTETRACK&USERID=1&TRACKID=0000-0000&VOTE=UP";
        }

        private void btnGetPlaylist_Click(object sender, EventArgs e)
        {
            tbxGetForm.Text = "?COMMAND=GETPLAYLIST&USERID=1";
        }

        private void btnGetPlaylistUpdate_Click(object sender, EventArgs e)
        {
            tbxGetForm.Text = "?COMMAND=GETPLAYLISTUPDATETIME&USERID=1";
        }

        private void btnYoutubeSearch_Click(object sender, EventArgs e)
        {
            tbxGetForm.Text = "?COMMAND=YOUTUBESEARCH&USERID=1&QUERY=Gangnamstyle&PAGE=0";
        }

        private void btnAddYoutubeTrack_Click(object sender, EventArgs e)
        {
            tbxGetForm.Text = "?COMMAND=ADDYOUTUBETRACK&USERID=1&URL=HM8b8d8kSNQ";
        }

        private void btnLogoutUser_Click(object sender, EventArgs e)
        {
            tbxGetForm.Text = "?COMMAND=LOGOUTUSER&USERID=1";
        }

        private void btnDestroySession_Click(object sender, EventArgs e)
        {
            tbxGetForm.Text = "?COMMAND=DESTROYSESSION&USERID=0";
        }

        private void btnAddVolume_Click(object sender, EventArgs e)
        {
            tbxGetForm.Text = "?COMMAND=ADDVOLUME&USERID=1&VOLUME=2";
        }

        private void btnGetVolume_Click(object sender, EventArgs e)
        {
            tbxGetForm.Text = "?COMMAND=GETVOLUME&USERID=0";
        }
    }
}
