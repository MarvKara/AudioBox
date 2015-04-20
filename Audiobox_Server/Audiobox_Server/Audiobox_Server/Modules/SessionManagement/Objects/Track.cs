using System;
using Audiobox_Server.General;

namespace Audiobox_Server.Modules.SessionManagement.Objects
{
    /// <summary>
    /// Abstract class representing a Track object
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2013
    /// </summary>
    public abstract class Track
    {
        public string Title { get; set; }
        public string Id { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
        public DateTime TimeAdded { get; set; }

        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="title"></param>
        /// <param name="id"></param>
        public Track(string title, string id)
        {
            this.Title = title;
            this.Id = id;
            this.Upvotes = 0;
            this.Downvotes = 0;
            this.TimeAdded = DateTime.Now;
        }

        /// <summary>
        /// An empty constructor for certain purposes
        /// </summary>
        public Track()
        {
 
        }

        /// <summary>
        /// Votes up a track by one
        /// </summary>
        public void VoteUp()
        {
            this.Upvotes++;
        }

        /// <summary>
        /// Votes down a track by one
        /// </summary>
        public void VoteDown()
        {
            this.Downvotes++;
        }

        /// <summary>
        /// Calculates the votes balance
        /// </summary>
        /// <returns></returns>
        public int CalcVoteSaldo()
        {
            return (this.Upvotes - this.Downvotes);
        }


        /// <summary>
        /// Generates a unique TrackID
        /// </summary>
        /// <returns></returns>
        public static string GenerateUniqueId()
        {
            char[] raw = new char[9];

            raw[0] = Actions.GenerateRandomChar();
            raw[1] = Actions.GenerateRandomChar();
            raw[2] = Actions.GenerateRandomChar();
            raw[3] = Actions.GenerateRandomChar();
            raw[4] = '-';
            raw[5] = Actions.GenerateRandomNumber();
            raw[6] = Actions.GenerateRandomNumber();
            raw[7] = Actions.GenerateRandomNumber();
            raw[8] = Actions.GenerateRandomNumber();

            string id = new string(raw);

            return id;
        }
    }
}
