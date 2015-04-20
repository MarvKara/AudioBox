using System;
using System.IO;
using System.Net;

namespace Audiobox_Server.Modules.Youtube.YouTubeHelperClasses
{
    /// <summary>
    /// Provides a method to download a video and extract its audio track.
    /// </summary>
    public class AudioDownloader : Downloader
    {
        private bool isCanceled = false;
        private string baseUrl = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioDownloader"/> class.
        /// </summary>
        /// <param name="video">The video to convert.</param>
        /// <param name="savePath">The path to save the audio.</param>
        /// /// <param name="bytesToDownload">An optional value to limit the number of bytes to download.</param>
        /// <exception cref="ArgumentNullException"><paramref name="video"/> or <paramref name="savePath"/> is <c>null</c>.</exception>
        public AudioDownloader(VideoInfo video, string savePath, string baseUrl, int? bytesToDownload = null)
            : base(video, savePath, bytesToDownload)
        {
            this.baseUrl = baseUrl;
        }

        /// <summary>
        /// Occurs when the progress of the audio extraction has changed.
        /// </summary>
        public event EventHandler<ProgressEventArgs> AudioExtractionProgressChanged;

        /// <summary>
        /// Occurs when the download progress of the video file has changed.
        /// </summary>
        public event EventHandler<ProgressEventArgs> DownloadProgressChanged;

        /// <summary>
        /// Downloads the video from YouTube and then extracts the audio track out if it.
        /// </summary>
        /// <exception cref="IOException">
        /// The temporary video file could not be created.
        /// - or -
        /// The audio file could not be created.
        /// </exception>
        /// <exception cref="AudioExtractionException">An error occured during audio extraction.</exception>
        /// <exception cref="WebException">An error occured while downloading the video.</exception>
        public override void Execute()
        {
            string tempPath = Path.GetTempFileName();

            this.DownloadVideo(tempPath);

            if (!this.isCanceled)
            {
                this.ExtractAudio(tempPath);
            }
        }

        private void DownloadVideo(string path)
        {
            var videoDownloader = new VideoDownloader(this.Video, path, this.baseUrl, this.BytesToDownload);
            videoDownloader.DownloadProgressChanged += new EventHandler<ProgressEventArgs>(videoDownloader_DownloadProgressChanged);

            videoDownloader.Execute();
        }

        void videoDownloader_DownloadProgressChanged(object sender, ProgressEventArgs e)
        {
            this.DownloadProgressChanged(sender, e);
        }

        private void ExtractAudio(string path)
        {
            using (var flvFile = new FlvFile(path, this.SavePath))
            {
                flvFile.ConversionProgressChanged += (sender, args) =>
                {
                    if (this.AudioExtractionProgressChanged != null)
                    {
                        this.AudioExtractionProgressChanged(this, new ProgressEventArgs(args.ProgressPercentage));
                    }
                };

                flvFile.ExtractStreams();
            }
        }
    }
}