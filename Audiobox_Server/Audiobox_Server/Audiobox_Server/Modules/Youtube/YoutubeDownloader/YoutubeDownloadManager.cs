using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Audiobox_Server.Modules.Youtube.YouTubeHelperClasses;

namespace Audiobox_Server.Modules.Youtube.YoutubeDownloader
{
    /// <summary>
    /// YoutubeDownloadManagerClass which handles all incoming Youtube Downloads via a Queue. 
    /// ######################################################################################
    /// Copyright: Reinier Weerts & Marvin Karaschewski, Stenden Hogeschool 2013 
    /// </summary>
    public static class YoutubeDownloadManager
    {
        private static Thread downloadManagerThread;
        private static bool isReady;
        private static Queue<YoutubeDownload> downloadQueue;
        private static List<YoutubeDownload> activeDownloads;

        /// <summary>
        /// Initializes the DownloadManagerThread-Class
        /// </summary>
        public static void Initialize()
        {
            isReady = true;

            activeDownloads = new List<YoutubeDownload>();
            downloadQueue = new Queue<YoutubeDownload>();
            downloadManagerThread = new Thread(DownloadManagerThreadMethod);
            downloadManagerThread.IsBackground = true;
            downloadManagerThread.Start();
        }

        ///// <summary>
        ///// The Thread method. 
        ///// </summary>
        //private static void DownloadManagerThreadMethod()
        //{
        //    while (true)
        //    {
        //        Thread.Sleep(1);
        //        if (isReady)
        //        {
        //            YoutubeDownload currentDownload = null;
        //            if (downloadQueue.Count > 0)
        //            {
        //                isReady = false;
        //                currentDownload = downloadQueue.Dequeue();
        //                activeDownloads.Add(currentDownload);
        //                currentDownload.Start();
        //            }
        //            if (currentDownload != null)
        //            {
        //                while (!currentDownload.IsComplete)
        //                {
        //                    Thread.Sleep(1); /// WAIT ///
        //                }
        //                activeDownloads.Remove(currentDownload);
        //            }
        //            isReady = true;
        //        }
        //    }
        //}

        /// <summary>
        /// The Thread method. 
        /// </summary>
        private static void DownloadManagerThreadMethod()
        {
            while (true)
            {
                Thread.Sleep(1);
                if (isReady)
                {
                    if (downloadQueue.Count > 0 && activeDownloads.Count < 5)
                    {
                        YoutubeDownload newDownload = downloadQueue.Dequeue();
                        activeDownloads.Add(newDownload);
                        newDownload.Start();
                    }

                    YoutubeDownload[] clonedList = (YoutubeDownload[])activeDownloads.ToArray().Clone();
                    foreach (YoutubeDownload download in clonedList)
                    {
                        if (download.IsComplete)
                        {
                            activeDownloads.Remove(download);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Method to add a new Download to the Queue
        /// </summary>
        /// <param name="url"></param>
        /// <param name="sessionId"></param>
        public static void AddDownloadToQueue(string userid, string url)
        {          
            downloadQueue.Enqueue(new YoutubeDownload(userid, url, DownloadUrlResolver.GetDownloadUrls(url)));
        }

        public static List<YoutubeDownload> GetCurrentlyActiveDownloads()
        {
            return activeDownloads;
        }

        public static Queue<YoutubeDownload> GetCurrentlyQueuedDownloads()
        {
            return downloadQueue;
        }  
    }
}