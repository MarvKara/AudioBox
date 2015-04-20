using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace Audiobox_Server.Modules.Youtube.YoutubeDownloader
{
    /// <summary>
    /// Represents a session-specific moderated Youtube queue.
    /// *** PREMIUM FEATURE ***
    /// ######################################################################################
    /// Copyright: Reinier Weerts, Stenden Hogeschool 2013 
    /// </summary>
    /// 
    class YoutubeQueue
    {

        private List<QueuedItem> modQueue;
        private bool isModerated;

        public YoutubeQueue(bool isModerated)
        {
            this.isModerated = isModerated;
            modQueue = new List<QueuedItem>();
        }

        /// <summary>
        /// *** PREMIUM FEATURE ***
        /// TODO: Add extra information about Youtube track.
        /// Builds a queued item.
        /// </summary>
        struct QueuedItem
        {
            public string url;
            public string userid;

            public QueuedItem(string userid, string url)
            {
                this.url = url;
                this.userid = userid;
            }
        }

        /// <summary>
        /// *** PREMIUM FEATURE ***
        /// Adds Youtube track picked by a user to moderated queue.
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="url"></param>
        public void AddDownloadToModQueue(string userid, string url)
        {
            if (isModerated)
            {
                modQueue.Add(new QueuedItem(userid, url));
            }
            else if (!isModerated)
            {
                YoutubeDownloadManager.AddDownloadToQueue(userid, url);
            }
        }


        /// TODO: Error handling
        /// <summary>
        /// *** PREMIUM FEATURE ***
        /// Remove an item from moderation Queue
        /// </summary>
        public void RemoveFromModeratedQueue(string url)
        {
            for (int i = modQueue.Count - 1; i >= 0; i--)
            {
                if (modQueue[i].url.Equals(url))
                {
                    modQueue.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// *** PREMIUM FEATURE ***
        /// Accept an item from moderation Queue and remove it.
        /// </summary>
        public void AcceptFromModeratedQueue(string url)
        {
            for (int i = modQueue.Count - 1; i >= 0; i--)
            {
                if (modQueue[i].url.Equals(url))
                {
                    YoutubeDownloadManager.AddDownloadToQueue(modQueue[i].userid, modQueue[i].url);
                    modQueue.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// *** PREMIUM FEATURE ***
        /// Get moderation Queue
        /// </summary>
        public string GetModeratedQueue()
        {
            var json = new JavaScriptSerializer().Serialize(modQueue);
            return json;
        }
    }
}
