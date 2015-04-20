using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using Audiobox_Server.Modules.Youtube.YoutubeDownloader;

namespace Audiobox_Server.Forms
{
    public partial class YoutubeDownloadManagerForm : Form
    {
        Thread dataReader;

        public YoutubeDownloadManagerForm()
        {
            this.Icon = Audiobox_Server.Properties.Resources.Audiobox_Icon;
            InitializeComponent();
            dataReader = new Thread(DataReaderMethod);
            dataReader.IsBackground = true;
            dataReader.Start();
        }

        public void DataReaderMethod()
        {
            RefreshDownloadsView();
            RefreshDownloadQueueView();
            while (true)
            {
                Thread.Sleep(1000);
                RefreshDownloadsView();
                RefreshDownloadQueueView();
            }
        }

        /// <summary>
        /// Refreshes the ListView containing the all currently active downloads
        /// </summary>
        /// <param name="session"></param>
        private void RefreshDownloadsView()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => RefreshDownloadsView()));
                return;
            }

            List<YoutubeDownload> activeDownloads = YoutubeDownloadManager.GetCurrentlyActiveDownloads();

            lvDownloads.Items.Clear();

            if (activeDownloads.Count != 0)
            {
                for (int c = 0; c < 5; c++)
                {
                    try
                    {
                        ListViewItem newLvi = new ListViewItem(activeDownloads[c].Url);
                        newLvi.SubItems.Add(activeDownloads[c].SessionID);
                        lvDownloads.Items.Add(newLvi);
                        AssignValueToProgressBar(c, (int)activeDownloads[c].DownloadProgress);
                    }
                    catch
                    {
                        AssignValueToProgressBar(c, 0);
                    }
                }
            }

            lvDownloads.Refresh();
        }

        /// <summary>
        /// Refreshes the ListView containing the all currently active downloads
        /// </summary>
        /// <param name="session"></param>
        private void RefreshDownloadQueueView()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => RefreshDownloadQueueView()));
                return;
            }

            Queue<YoutubeDownload> downloadQueue = YoutubeDownloadManager.GetCurrentlyQueuedDownloads();

            lvQueue.Items.Clear();

            foreach (YoutubeDownload download in downloadQueue)
            {
                ListViewItem newLvi = new ListViewItem(download.Url);
                newLvi.SubItems.Add(download.SessionID);
                newLvi.SubItems.Add(download.VideoInfo.Title);
                lvQueue.Items.Add(newLvi);
            }

            lvQueue.Refresh();
        }

        private void AssignValueToProgressBar(int index, int value)
        {
            switch(index)
            {
                case 0:
                    {
                        progressBar1.Value = value;
                        break;
                    }
                case 1:
                    {
                        progressBar2.Value = value;
                        break;
                    }
                case 2:
                    {
                        progressBar3.Value = value;
                        break;
                    }
                case 3:
                    {
                        progressBar4.Value = value;
                        break;
                    }
                case 4:
                    {
                        progressBar5.Value = value;
                        break;
                    }
            }

        }
    }
}
