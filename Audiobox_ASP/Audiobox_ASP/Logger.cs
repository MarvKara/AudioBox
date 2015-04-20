using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using System.Web.Hosting;

namespace Audiobox_ASP
{
    /*
     * Author(s):               Johannes Elzinga
     * Version:                 1.0
     * Date last modified:      13-01-2014
     * 
     */
    public class Logger
    {
        /// <summary>
        /// used to create log files in the following format :
        /// dd/mm/yyyy hh:mm:ss AM/PM ==> Log Message
        /// </summary>
        
        public static string strPath = AppDomain.CurrentDomain.BaseDirectory;
        public static string strLogFilePath = strPath + @"log.txt";
        private string sLogFormat;
        
        public Logger()
        {  
            sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";
        }

        public void CreateEventLog(string eventMsg)
        {
            try
            {
                if (!File.Exists(strLogFilePath))
                {
                    File.Create(strLogFilePath).Close();
                }
                using (StreamWriter sw = File.AppendText(strLogFilePath))
                {
                    sw.WriteLine(sLogFormat + eventMsg);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception triggered - no log file written. - " + e.ToString());
            }
        }
    }
}