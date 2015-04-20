using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Audiobox_Server.General;
using Audiobox_Server.Modules.AudioboxConsole;
using Audiobox_Server.Modules.UserManagement;
using Audiobox_Server.Modules.Youtube.YoutubeDownloader;

namespace Audiobox_Server.Modules.SessionManagement.Objects
{
    /// <summary>
    /// Represents an indiviual Session Object
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2013
    /// </summary>
    public class Session
    {
        public string Id { get; private set; }
        public Playlist Playlist { get; set; }
        public DateTime StartingTime { get; private set; }
        public DateTime EndTime { get; set; }
        public User Host { get; set; }
        public List<User> Clients { get; set; }
        public bool isActive { get; set; }
        public bool isStopped { get; set; }
        public bool isModerated { get; set; }
        public MediaServer MediaServer{ get; private set; }
        public FileManager FileManager { get; set; }
        public string DirectoryPath { get; private set; }
        private YoutubeQueue YoutubeQueue;
        public VolumeManager VolumeManager {get; set;}

        /// <summary>
        /// Standard constructor for a new Session
        /// </summary>
        public Session()
        {
            this.Id = SessionManager.GenerateUniqueSessionId();
            this.Playlist = new Playlist();
            Playlist.PlaylistEmpty += new Playlist.PlaylistEmptyHandler(Playlist_PlaylistEmpty);

            this.DirectoryPath = GeneralObjects.SESSION_FOLDERNAME + "/" + this.Id;
            Actions.CreateFolder(this.DirectoryPath);

            this.isActive = false;
            this.isStopped = false;
            //TODO: make an option @ starting session
            this.isModerated = false;
            this.StartingTime = DateTime.Now;

            this.Clients = new List<User>();

            this.FileManager = new FileManager(this.Id);
            this.MediaServer = new MediaServer(this.Id);
            this.YoutubeQueue = new YoutubeQueue(isModerated);
            this.VolumeManager = new VolumeManager();
        }

        /// <summary>
        /// Actually Starts the Session by Starting the media server
        /// </summary>
        public void Start()
        {
            this.MediaServer.Start();
        }

        void Playlist_PlaylistEmpty()
        {
            LogConsole.Break();
            LogConsole.Write("No more Tracks on Playlist: " + this.Id);
            this.Playlist.CurrentTrack = null;
            this.MediaServer.Pause();
            Thread.Sleep(5);
            this.MediaServer.ClearBuffer();
        }

        /// <summary>
        /// Adds a new Track to the playlist of this Session
        /// </summary>
        /// <param name="track"></param>
        public void SubmitNewTrack(Track track)
        {
            this.Playlist.AddTrack(track);
        }

        /// <summary>
        /// Adds a Youtube Track to YoutubeQueue
        /// </summary>
        public void AddYoutubeTrack(string userid, string url)
        {
            this.YoutubeQueue.AddDownloadToModQueue(userid, url);
        }


        /// <summary>
        /// Returns a Session objects details as a List-type collection with strings
        /// </summary>
        /// <returns></returns>
        public List<string> Details()
        {
            List<string> details = new List<string>();
            details.Add("Created new session with following credentials:");
            details.Add("----------------------------------------------------------");
            details.Add("Session-ID: " + this.Id);
            details.Add("Started on: " + this.StartingTime.ToString());
            details.Add("Session-Host: " + this.Host.UserId);
            foreach (string s in this.MediaServer.GetServerIdentification())
            {
                details.Add("URL: " + s);
            }
            details.Add("----------------------------------------------------------");

            return details;
        }

        /// <summary>
        /// Returns a Track with a given trackId
        /// </summary>
        /// <param name="trackId"></param>
        /// <returns></returns>
        public Track FindTrack(string trackId)
        {
            foreach (Track t in this.Playlist.Tracks)
            {
                if (t.Id == trackId)
                {
                    return t;
                }
            }
            return null;
        }

        /// <summary>
        /// Returns a ListViewItem representing a Session.
        /// </summary>
        /// <returns></returns>
        public ListViewItem ToListViewItem()
        {
            ListViewItem newLvi = new ListViewItem(this.Id);
            newLvi.SubItems.Add(this.MediaServer.GetPortNumber().ToString());
            newLvi.SubItems.Add(this.isActive.ToString());
            newLvi.SubItems.Add(this.Host.UserId);
            newLvi.SubItems.Add(this.Clients.Count.ToString());
            newLvi.SubItems.Add(this.StartingTime.ToString());
            return newLvi;
        }

        /// <summary>
        /// Stops a Session and deactivates it.
        /// </summary>
        public void Stop()
        {
            this.EndTime = DateTime.Now;
            this.isActive = false;
            this.MediaServer.Stop();
            this.isStopped = true;
        }

        /// <summary>
        /// Deletes the corrosponding files and removes any evidence of a Session
        /// </summary>
        public void Terminate()
        {
            Actions.DeleteFolder(this.DirectoryPath);
        }

        /// <summary>
        /// Removes a user with a given userid from the list of clients
        /// </summary>
        /// <param name="userId"></param>
        public User RemoveUser(string userId)
        {
            List<User> clone = this.Clients;

            foreach(User user in clone)
            {
                if (user.UserId == userId)
                {
                    this.Clients.Remove(user);
                    return user;
                }
            }
            return null;
        }
    }
}