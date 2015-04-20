using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Google.GData.YouTube;
using Google.YouTube;
using Google.GData.Client;
using Google.GData.Extensions.MediaRss;
using YoutubeExtractor;

namespace YouTubeAPI
{
    public partial class Form1 : Form
    {
        string myDeveloperKey;
        string youtubeUrl;

        public Form1()
        {
            InitializeComponent();
            
            myDeveloperKey = "AIzaSyDi0I18MfujgHEmz30OOK3Vxc4SKfLwTMQ";
            listView1.Columns.Add("key", 200);
            
            listView1.Columns.Add("Video Title");
            listView1.Columns.Add("Uploaded By");
            listView1.Columns.Add("Uploaded Date");

            ;

        }

        private void setYoutubeId(String Id)
        {
            youtubeUrl = "http://www.youtube.com/watch?v=" + Id;
            MessageBox.Show(youtubeUrl);
        }

        private string getYoutubeUrl()
        {
            
            return youtubeUrl;
            
        }

        private void extractAudio(IEnumerable<VideoInfo> videoInfos)
        {

            /*
             * We want the first extractable video with the highest audio quality.
             */
            VideoInfo video = videoInfos
                .Where(info => info.CanExtractAudio)
                .OrderByDescending(info => info.AudioBitrate)
                .First();


            /*
             * Create the audio downloader.
             * The first argument is the video where the audio should be extracted from.
             * The second argument is the path to save the audio file.
             */
            var audioDownloader = new AudioDownloader(video,
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), video.Title + "YES" + video.AudioExtension));
            MessageBox.Show(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), video.Title + "YES" + video.AudioExtension));
            MessageBox.Show(video.ToString());
            audioDownloader.Execute();
            // Register the progress events. We treat the download progress as 85% of the progress and the extraction progress only as 15% of the progress,
            // because the download will take much longer than the audio extraction.
            audioDownloader.DownloadProgressChanged += (sender, args) => System.Diagnostics.Debug.WriteLine((args.ProgressPercentage * 0.85).ToString());
            audioDownloader.AudioExtractionProgressChanged += (sender, args) => System.Diagnostics.Debug.WriteLine((85 + args.ProgressPercentage * 0.15).ToString());

            /*
             * Execute the audio downloader.
             * For GUI applications note, that this method runs synchronously.
             */
            

        }


        private void test(object sender, MouseEventArgs e)
        {
            
            listView1.BackColor = Color.Aqua;
            

            listView1.FullRowSelect = true;

            string youTubeSearchTerm;

            youTubeSearchTerm = textBox1.Text;

            YouTubeService myservice = new YouTubeService("aa", myDeveloperKey);

            Uri videoEntryUrl = new Uri("http://gdata.youtube.com/feeds/api/videos?q=" + youTubeSearchTerm + "&safeSearch=none&orderby=viewCount");


            FeedQuery fq = new FeedQuery();
            fq.Uri = videoEntryUrl;

            Feed<Video> videoFeed = new Feed<Video>(myservice, fq);
            foreach (Video entry in videoFeed.Entries)
            {
                listView1.Items.Add((new ListViewItem(new string[] { entry.VideoId.ToString() })));
            }
        }
        private static void DownloadAudio(IEnumerable<VideoInfo> videoInfos)
        {
            /*
             * We want the first extractable video with the highest audio quality.
             */
            VideoInfo video = videoInfos
                .Where(info => info.CanExtractAudio)
                .OrderByDescending(info => info.AudioBitrate)
                .First();

            /*
             * Create the audio downloader.
             * The first argument is the video where the audio should be extracted from.
             * The second argument is the path to save the audio file.
             */

            var audioDownloader = new AudioDownloader(video,
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), video.Title + video.AudioExtension));

            // Register the progress events. We treat the download progress as 85% of the progress and the extraction progress only as 15% of the progress,
            // because the download will take much longer than the audio extraction.
            audioDownloader.DownloadProgressChanged += (sender, args) => Console.WriteLine(args.ProgressPercentage * 0.85);
            audioDownloader.AudioExtractionProgressChanged += (sender, args) => Console.WriteLine(85 + args.ProgressPercentage * 0.15);

            /*
             * Execute the audio downloader.
             * For GUI applications note, that this method runs synchronously.
             */
            audioDownloader.Execute();
        }

        private static void DownloadVideo(IEnumerable<VideoInfo> videoInfos)
        {
            /*
             * Select the first .mp4 video with 360p resolution
             */
            VideoInfo video = videoInfos
                .First(info => info.VideoType == VideoType.Mp4 && info.Resolution == 360);

            /*
             * Create the video downloader.
             * The first argument is the video to download.
             * The second argument is the path to save the video file.
             */
            var videoDownloader = new VideoDownloader(video,
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), video.Title + video.VideoExtension));

            // Register the ProgressChanged event and print the current progress
            videoDownloader.DownloadProgressChanged += (sender, args) => Console.WriteLine(args.ProgressPercentage);

            /*
             * Execute the video downloader.
             * For GUI applications note, that this method runs synchronously.
             */
            videoDownloader.Execute();
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {

            MessageBox.Show("Nummer: " + listView1.SelectedItems[0].Text + " wordt geconverteerd...");
            setYoutubeId(listView1.SelectedItems[0].Text);
            //const string link = "http://www.youtube.com/watch?v=6bMmhKz6KXg";
            IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(getYoutubeUrl());
            extractAudio(videoInfos);
            //DownloadAudio(videoInfos);
            //DownloadVideo(videoInfos);
            
        }

    }
}
