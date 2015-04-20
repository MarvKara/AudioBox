using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Audiobox_Server.Modules.AudioboxConsole;
using Audiobox_Server.Modules.SessionManagement;
using Audiobox_Server.Modules.Youtube.YouTubeHelperClasses;

namespace Audiobox_Server.Modules.Youtube.YoutubeDownloader
{
    /// <summary>
    /// YoutubeDownload Class which represents one individual download
    /// {IS DESTROYED WHEN DOWNLOAD IS COMPLETE}
    /// #######################################################
    /// Copyright: Reinier Weerts & Marvin Karaschewski, Stenden Hogeschool 2013 
    /// </summary>
    public class YoutubeDownload
    {
        private Thread downloadThread;
        private DateTime lastUpdate;

        public bool IsComplete { get; private set;}
        public VideoInfo VideoInfo { get; set; }
        public string Url { get; set; }
        public string SessionID { get; set; }
        public string Userid { get; set; }
        public double DownloadProgress { get; set; }
        public double ExtractionProgress { get; set; }

        /// <summary>
        /// The Constructor of 
        /// </summary>
        /// <param name="url">The Url of the Video</param>
        /// <param name="sessionId"></param>
        /// <param name="videoInfos"></param>
        public YoutubeDownload(string userid, string url, IEnumerable<VideoInfo> videoInfos)
        {
            this.Url = url;
            this.Userid = userid;
            this.SessionID = SessionManager.FindSessionByUserId(userid).Id;
            this.VideoInfo = InitializeVideoInfo(videoInfos);
        }

        /// <summary>
        /// Starts the actual download
        /// </summary>
        public void Start()
        {
            this.IsComplete = false;
            lastUpdate = DateTime.Now;
            downloadThread = new Thread(DownloadThreadMethod);
            downloadThread.IsBackground = true;
            downloadThread.Start();
        }

        /// <summary>
        /// The thread's method which in place executes the audiodownloader
        /// </summary>
        private void DownloadThreadMethod()
        {
            AudioDownloader audioDownloader = new AudioDownloader(this.VideoInfo, Application.StartupPath + "/_SESSIONS/"+this.SessionID+"/" + VideoInfo.Title + VideoInfo.AudioExtension, this.Url);
            audioDownloader.DownloadProgressChanged += new EventHandler<ProgressEventArgs>(audioDownloader_DownloadProgressChanged);
            audioDownloader.AudioExtractionProgressChanged += new EventHandler<ProgressEventArgs>(audioDownloader_AudioExtractionProgressChanged);
            audioDownloader.Execute();

            while (!this.IsComplete)
            {
                ///
            }
        }

        /// <summary>
        /// Listens to the progress the audiodownloader makes with the download of the videofile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void audioDownloader_DownloadProgressChanged(object sender, ProgressEventArgs e)
        {
            this.DownloadProgress = e.ProgressPercentage;
            if (this.ExtractionProgress <= 100.0)
            {
                TimeSpan sinceLastUpdate = (DateTime.Now - lastUpdate);
                if (sinceLastUpdate.TotalMilliseconds > 1000)
                {
                    lastUpdate = DateTime.Now;
                }
            }
            if (this.DownloadProgress == 100.0)
            {

            }
        }

        /// <summary>
        /// Listens to the progess the audiodownloader makes with the audio extraction of the file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void audioDownloader_AudioExtractionProgressChanged(object sender, ProgressEventArgs e)
        {
            this.ExtractionProgress = e.ProgressPercentage;

            if (this.ExtractionProgress <= 100.0)
            {
                TimeSpan sinceLastUpdate = (DateTime.Now - lastUpdate);
                if (sinceLastUpdate.TotalMilliseconds > 1000)
                {
                    lastUpdate = DateTime.Now;
                }
            }
            if (this.ExtractionProgress == 100.0)
            {
                this.IsComplete = true;
            }
        }

        /// <summary>
        /// Gets the videoinfo from the interface
        /// </summary>
        /// <param name="videoInfos"></param>
        /// <returns></returns>
        private VideoInfo InitializeVideoInfo(IEnumerable<VideoInfo> videoInfos)
        {
            return videoInfos.Where(info => info.CanExtractAudio).OrderByDescending(info => info.AudioBitrate).First();
        }
    }
}