using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Audiobox_Server.Modules.SessionManagement
{
    /// <summary>
    /// Class which Manages the volume for a session.
    /// #######################################################
    /// Copyright: jans popken, Stenden Hogeschool 2013
    /// </summary>
    public class VolumeManager
    {
        private Object thisLock = new Object();
        private Dictionary<string, int> volumes;
        //private Dictionary<string, KeyValuePair<int, DateTime>> volumes;

        /// <summary>
        /// Standard Constructor for VolumeManager
        /// </summary>
        public VolumeManager()
        {
            volumes = new Dictionary<string, int>();
            //volumes = new Dictionary<string, KeyValuePair<int, DateTime>>();

        }

        /// <summary>
        /// method to add userID as a key and volume as a value to the dictionary.
        /// if the the key already exists it will be removed.
        /// the key and value will then be added to the dictionary again.
        /// </summary>
        public void AddVolume(string userID, int volume)
        {
            //volumes[userID] = volume;

            //DateTime lastTimeVoted = DateTime.Now;
            if (volumes.ContainsKey(userID))
            {
                volumes.Remove(userID);
                volumes.Add(userID, volume);
            }
            else
            {
                volumes.Add(userID, volume);
            }

        }

        /// <summary>
        /// method to remove userID key and value from the dictionary
        /// </summary>
        public void RemoveVolume(string userID)
        {
            if (volumes.ContainsKey(userID))
            {
                volumes.Remove(userID);
            }
        }

        /// <summary>
        /// method for calculating the average value of the dictionary
        /// it returns the average value from the dictionay
        /// </summary>
        public float GetVolume()
        {
            int sumOfValues = 0;
            int sumOfUsers = 0;
            //foreach (KeyValuePair<string,KeyValuePair<int, DateTime>> volume in volumes)
            lock(thisLock)
            {
                foreach (KeyValuePair<string, int> volume in volumes)
                {
                    sumOfValues += volume.Value;
                    sumOfUsers++;
                }
            }

                float vol = (float)sumOfValues / (float)sumOfUsers;

                return vol;
        }
    }
}