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
    public partial class AboutForm : Form
    {
        /// <summary>
        /// The AboutForm
        /// </summary>
        public AboutForm()
        {
            InitializeComponent();
            pbxIcon.Image = Audiobox_Server.Properties.Resources.Audiobox_Icon.ToBitmap();
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
