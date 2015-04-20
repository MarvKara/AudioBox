using System;

namespace Crowdsound_Master_Server_Application.Modules.UserManagement
{
    /// <summary>
    /// Represents an individual User
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2013
    /// </summary>
    public class User
    {
        public string UserId { get; set; }
        public string GoogleId { get; set; }
        public bool IsAlive { get; set; }
        public DateTime LastKeepAlive { get; set; }

        /// <summary>
        /// The standard constructor for a user
        /// </summary>
        public User(string id, string googleId)
        {
            this.LastKeepAlive = DateTime.Now;
            this.IsAlive = true;
            this.UserId = id;
            this.GoogleId = googleId;
        }

        /// <summary>
        /// Updates the users Google ID
        /// </summary>
        /// <param name="googleId"></param>
        public void Update(string googleId)
        {
            this.GoogleId = googleId;
        }
    }
}