using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace Audiobox_Server.Modules.Youtube.YouTubeHelperClasses
{
    /// Better Version of the rudimentary VideoDownloader
    /// Works around the download-block for licensed content on YouTube
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2014 
    /// </summary>
    public class VideoDownloader : Downloader
    {
        private string baseURL = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoDownloader"/> class.
        /// </summary>
        /// <param name="video">The video to download.</param>
        /// <param name="savePath">The path to save the video.</param>
        /// <param name="bytesToDownload">An optional value to limit the number of bytes to download.</param>
        /// <exception cref="ArgumentNullException"><paramref name="video"/> or <paramref name="savePath"/> is <c>null</c>.</exception>
        public VideoDownloader(VideoInfo video, string savePath, string baseUrl, int? bytesToDownload = null)
            : base(video, savePath, bytesToDownload)
        {
            this.baseURL = baseUrl;
        }

        /// <summary>
        /// Occurs when the downlaod progress of the video file has changed.
        /// </summary>
        public event EventHandler<ProgressEventArgs> DownloadProgressChanged;

        /// <summary>
        /// Executes the Download
        /// </summary>
        public override void Execute()
        {
            this.OnDownloadStarted(EventArgs.Empty);

            WebResponse response = null;

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(this.Video.DownloadUrl);
                response = request.GetResponse();
            }
            catch
            {
                string crookedUrl = this.GenerateCrookedDownloadUrl(this.baseURL);
                var request = (HttpWebRequest)WebRequest.Create(crookedUrl);
                response = request.GetResponse();
            }

            using (Stream source = response.GetResponseStream())
            {
                using (FileStream target = File.Open(this.SavePath, FileMode.Create, FileAccess.Write))
                {
                    var buffer = new byte[1024];
                    bool cancel = false;
                    int bytes;
                    int copiedBytes = 0;

                    while (!cancel && (bytes = source.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        target.Write(buffer, 0, bytes);

                        copiedBytes += bytes;

                        var eventArgs = new ProgressEventArgs((copiedBytes * 1.0 / response.ContentLength) * 100);

                        if (this.DownloadProgressChanged != null)
                        {
                            this.DownloadProgressChanged(this, eventArgs);

                            if (eventArgs.Cancel)
                            {
                                cancel = true;
                            }
                        }
                    }
                }
            }
            
        }

        /// <summary>
        /// Generates a crooked Download URL for blocked content on Youtube
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        private string GenerateCrookedDownloadUrl(string baseUrl)
        {
            WebClient wc = new WebClient();
            string sourceCode = wc.DownloadString("http://keepvid.com/?url=http%3A%2F%2Fwww.youtube.com%2Fwatch%3Fv%3D" + baseUrl);
            wc.Dispose();

            List<string> raw = new List<string>();
            Regex regx = new Regex("Download 3GP &laquo;</a> - <b>240p</b><br /><a href=");
            raw = regx.Split(sourceCode).ToList();
            raw.RemoveAt(0);

            List<string> raw2 = new List<string>();
            Regex regx2 = new Regex("class=");
            raw2 = regx2.Split(raw[0]).ToList();
            string substringA = raw2[0].Substring(1);

            string crookedUrl = substringA.Substring(0, substringA.Length - 2);            

            return crookedUrl;
        }
    }
}