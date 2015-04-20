using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Audiobox_Server.Forms;
using Audiobox_Server.General;

namespace Audiobox_Server
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ErrorHandler.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
