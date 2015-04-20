using System;
using System.IO;

namespace Audiobox_Server.General
{
    /// <summary>
    /// ErrorHandler Class which catches exceptions and writes the protocol 
    /// to an individual text file
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2013
    /// </summary>
    public static class ErrorHandler
    {
        public static void Initialize()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;
            if (exception == null)
            {
                return;
            }
            TextWriter tw = File.CreateText(DateTime.Now.ToString().Replace(':', '#') + "log.txt");
            tw.WriteLine("Source: {0}", exception.Source);
            tw.WriteLine("Message:\n{0}",exception.Message);
            tw.Close();
        }
    }
}
