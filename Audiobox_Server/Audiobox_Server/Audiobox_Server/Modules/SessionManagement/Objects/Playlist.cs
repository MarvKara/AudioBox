using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Audiobox_Server.Modules.SessionManagement.Objects
{
    /// <summary>
    /// Represents a certain individual Playlist
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2013
    /// </summary>
    public class Playlist
    {
        public List<Track> Tracks { get; set; }
        public Track CurrentTrack { get; set; }
        public DateTime LastUpdateTime { get; set; }

        public delegate void PlaylistEmptyHandler();
        public event PlaylistEmptyHandler PlaylistEmpty;

        /// <summary>
        /// standard constructor if for new playlist object
        /// </summary>
        public Playlist()
        {
            this.Tracks = new List<Track>();
            this.CurrentTrack = null;
            this.LastUpdateTime = DateTime.Now;
        }

        public void OnPlaylistEmpty()
        {
            if (PlaylistEmpty != null)
            {
                PlaylistEmpty();
            }
        }

        /// <summary>
        /// Adds a new Track to the playlist
        /// If there is no currently active track, the added one becomes the active track
        /// </summary>
        /// <param name="track"></param>
        public void AddTrack(Track track)
        {
            if (this.CurrentTrack == null)
            {
                CurrentTrack = track;
            }
            else
            {
                this.Tracks.Add(track);
            }
        }

        /// <summary>
        /// Changes the first Track of the playlist and the currently active track
        /// </summary>
        public void NextTrack()
        {
            if (!this.IsEmpty())
            {
                this.CurrentTrack = this.Tracks[0];
                this.Tracks.RemoveAt(0);
            }
            else
            {
                OnPlaylistEmpty();
            }
        }

        /// <summary>
        /// Returns whether a Playlists Tracklist is empty or not
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            if (this.Tracks.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns true if the playlist has a current track
        /// </summary>
        /// <returns></returns>
        public bool HasCurrentTrack()
        {
            if (this.CurrentTrack == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Returns the Title of the current track of the playlist
        /// </summary>
        /// <returns>title string</returns>
        public string GetCurrentTrackTitle()
        {
            if (this.HasCurrentTrack())
            {
                return this.CurrentTrack.Title;
            }
            else
            {
                return "NONE";
            }
        }
        
        /// <summary>
        /// Returns the Playlist as a list of ListViewItem for the use on the GUI
        /// </summary>
        /// <returns></returns>
        public List<ListViewItem> ToListViewItems()
        {
            List<ListViewItem> listOfTracks = new List<ListViewItem>();

            this.Sort();

            int index = 1;
            foreach (Track track in this.Tracks)
            {
                ListViewItem lvi = new ListViewItem(index.ToString());
                lvi.SubItems.Add(track.Id);
                lvi.SubItems.Add(track.Title);
                lvi.SubItems.Add(track.Upvotes.ToString());
                lvi.SubItems.Add(track.Downvotes.ToString());
                listOfTracks.Add(lvi);
                index++;
            }

            return listOfTracks;
        }

        /// <summary>
        /// Sorts the Playlists elements by descending order of the votesaldo
        /// If that does not apply, it sorts by descending time of adding
        /// </summary>
        /// <returns></returns>
        private List<Track> Sort()
        {
            this.Tracks = this.Tracks.OrderByDescending(x => x.CalcVoteSaldo()).ThenByDescending(x => x.TimeAdded).ToList();
            return this.Tracks;
        }

        /// <summary>
        /// Returns the Playlist object as JSON-Array-String
        /// </summary>
        /// <returns></returns>
        public String ListToJson()
        {
            var json = new JavaScriptSerializer().Serialize(Tracks);
            return json;
        }

        /// <summary>
        /// Updates this Playlists LastUpdateTime
        /// </summary>
        public void UpdateUpdateTime()
        {
            this.LastUpdateTime = DateTime.Now;
        }
    }
}
