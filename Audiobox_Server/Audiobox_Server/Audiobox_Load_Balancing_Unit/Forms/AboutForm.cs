using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Crowdsound_Master_Server_Application.Support;

namespace Crowdsound_Master_Server_Application.Forms
{
    /// <summary>
    /// The AboutForm, which shows valuable information from the about class on screen 
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2014
    /// </summary>
    public partial class AboutForm : Form
    {
        /// <summary>
        /// The AboutForm
        /// </summary>
        public AboutForm()
        {
            InitializeComponent();
            // pbxIcon.Image = Audiobox_Server.Properties.Resources.Audiobox_Icon.ToBitmap();
            tbxProductName.Text = About.PRODUCTNAME;
            tbxDeveloperTeam.Text = About.DEVELOPER_NAME;
            tbxVersionNumber.Text = About.VERSION_NUMBER;
            foreach (string name in About.DEVELOPERS)
            {
                rtbxTeamMembers.AppendText(name + "\n");
            }
        }
    }
}
