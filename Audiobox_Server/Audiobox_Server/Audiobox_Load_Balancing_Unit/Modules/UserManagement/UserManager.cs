using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Crowdsound_Master_Server_Application.Modules.UserManagement
{
    /// <summary>
    /// Static UserManagement Class, which handles all User-Related Actions
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2014
    /// </summary>
    public static class UserManager
    {
        private static List<int> usedUserIds;
        private static List<User> unassignedUsers;
        private static List<ListViewItem> preUpdateUserList;
        private static Thread userDisplayRefreshThread;
        private static bool changeOccured;

        public delegate void UpdateUserDataHandler(List<ListViewItem> userList, int assigned, int unassigned);
        public static event UpdateUserDataHandler UpdateUserData;

        /// <summary>
        /// Initialization Method
        /// </summary>
        public static void Initialize()
        {
            changeOccured = false;
            usedUserIds = new List<int>();
            unassignedUsers = new List<User>();
            preUpdateUserList = new List<ListViewItem>();
            userDisplayRefreshThread = new Thread(RefreshDisplayTrigger);
            userDisplayRefreshThread.IsBackground = true;
            userDisplayRefreshThread.Start();
        }

        public static void OnUpdateUserData(List<ListViewItem> userList, int assigned, int unassigned)
        {
            if (UpdateUserData != null)
            {
                UpdateUserData(userList, assigned, unassigned);
            }
        }

        /// <summary>
        /// Thread method which triggers an update per second
        /// </summary>
        private static void RefreshDisplayTrigger()
        {
            int updateCycleCounter = 10;
            while (true)
            {
                Thread.Sleep(1000);

                updateCycleCounter--;

                List<ListViewItem> userList = EnlistAllUsers();

                if (userList.Count != preUpdateUserList.Count || changeOccured || updateCycleCounter == 0)
                {
                    preUpdateUserList = userList;
                    changeOccured = false;
                    updateCycleCounter = 10;
                }
                else
                {
                    preUpdateUserList = userList;
                }
            }
        }

        /// <summary>
        /// Returns the next Available User ID
        /// </summary>
        /// <returns></returns>
        private static string GetNextFreeUserId()
        {
            if (usedUserIds.Count == 0)
            {
                OccupyId(0);
                return "0";
            }
            else
            {
                int value = 0;
                while(usedUserIds.Contains(value))
                {
                    value++;
                }
                OccupyId(value);
                return value.ToString();
            }
        }

        /// <summary>
        /// Occupies a user ID
        /// </summary>
        /// <param name="id"></param>
        private static void OccupyId(int id)
        {
            usedUserIds.Add(id);
        }

        /// <summary>
        /// Re-Releases a user ID
        /// </summary>
        /// <param name="id"></param>
        private static void ReleaseId(int id)
        {
            usedUserIds.Remove(id);
        }

        /// <summary>
        /// Creates a new User with the given googleId and the next available User Id
        /// </summary>
        /// <param name="googleId"></param>
        /// <returns></returns>
        public static User CreateUser(string googleId)
        {
            User newUser = new User(GetNextFreeUserId(), googleId);
            unassignedUsers.Add(newUser);
            return newUser;
        }

        /// <summary>
        /// Updates a user corrosponding to the given parameters
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="googleId"></param>
        /// <returns></returns>
        public static string UpdateUser(string userId, string googleId)
        {
            User user = FindUser(userId, false);
            user.LastKeepAlive = DateTime.Now;
            user.IsAlive = true;
            string oldGid = user.GoogleId;
            user.Update(googleId);
            UpdateList();
            return oldGid;
        }

        /// <summary>
        /// Triggers the bool to indicate that a change occured
        /// </summary>
        private static void UpdateList()
        {
            changeOccured = true;
        }

        /// <summary>
        /// Returns any User with the given userId
        /// // isAssigned tells the method where to search for the User
        /// // true = any Sessions User // false = only unassigned users
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isAssigned"></param>
        /// <returns></returns>
        private static User FindUser(string id, bool isAssigned)
        {
            /// TODO
            return new User("", "");
        }

        /// <summary>
        /// Assigns a User to a certain session
        /// </summary>
        /// <param name="sessionId">The session the user should be assigned to</param>
        /// <param name="userId">The user in question</param>
        /// <param name="userIsHost">true if the user should be host of the session :: false if Client</param>
        public static void AssignUser(string sessionId, string userId, bool userIsHost)
        {
            /// TODO
        }

        /// <summary>
        /// Removes a user from a his session
        /// </summary>
        /// <param name="userID"></param>
        public static void RemoveUserFromSession(string userId, bool isHost)
        {
            /// TODO
        }

        /// <summary>
        /// Checks if a user is unassigned and returns true if applicable
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool UserIsUnassigned(string userId)
        {
            foreach (User user in unassignedUsers)
            {
                if (user.UserId == userId)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool UserIsAssigned(string userId)
        {
            return false;
        }


        /// <summary>
        /// Creates a List of all users known to the system and returns it in form of a Collection
        /// of ListViewItems, ready to be placed into a ListView
        /// </summary>
        /// <param name="assigned"></param>
        /// <param name="unassigned"></param>
        /// <returns></returns>
        public static List<ListViewItem> EnlistAllUsers()
        {
            /// TODO
            return new List<ListViewItem>();
        }

        /// <summary>
        /// Method which returns true if a user is known to the system
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        private static bool UserExists(string userid)
        {
            if (usedUserIds.Contains(int.Parse(userid)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the authorization state of a user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static UserAuthorization GetUserAuthorization(string userId)
        {
            if (!UserExists(userId))
            {
                return UserAuthorization.Unregistered;
            }
            else
            {
                if (UserIsAssigned(userId))
                {
                    return UserAuthorization.Assigned;
                }
                else
                {
                    return UserAuthorization.Unassingned;
                }
            }
        }

        /// <summary>
        /// Returns the according Error message to a user authorization error
        /// </summary>
        /// <param name="required"></param>
        /// <param name="given"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string GetUserAuthorizationErrorMessage(UserAuthorization required, UserAuthorization given, string userId)
        {
            string message = string.Empty;
            if (required == UserAuthorization.Unassingned)
            {
                message = "AUTHORIZATION ERROR: USERID-> " + userId + " ::: USER ALREADY ASSIGNED";
            }
            if (required == UserAuthorization.Assigned)
            {
                message = "AUTHORIZATION ERROR: USERID-> " + userId + " ::: USER NOT ASSIGNED";
            }
            if (required == UserAuthorization.Registered)
            {
                message = "AUTHORIZATION ERROR: USERID-> " + userId + " ::: USER DOES NOT EXIST";
            }
            if ((required == UserAuthorization.Unassingned || required == UserAuthorization.Assigned) && given == UserAuthorization.Unregistered)
            {
                message = "AUTHORIZATION ERROR: USERID-> " + userId + " ::: USER DOES NOT EXIST";
            }
            return message; 
        }

        /// <summary>
        /// Updates a users Keepalive status
        /// </summary>
        /// <param name="userId"></param>
        public static void UpdateUserAliveStatus(string userId)
        {
            if(FindUser(userId, true) != null)
            {
                FindUser(userId, true).IsAlive = true;
                FindUser(userId, true).LastKeepAlive = DateTime.Now;
            }
        }

        /// <summary>
        /// Returns a string giving information about how much time has passed since the last keepalive signal was send.
        /// </summary>
        /// <param name="lastKeepAliveTime"></param>
        /// <returns></returns>
        private static string GetTimeSinceLastKeepAliveTime(DateTime lastKeepAliveTime)
        {
            TimeSpan difference = DateTime.Now - lastKeepAliveTime;
            if (difference.Days < 1)
            {
                DateTime d = new DateTime().Add(difference);
                return d.ToLongTimeString();
            }
            if (difference.Days > 1 && difference.Days < 8)
            {
                return difference.Days.ToString() + " days ago";
            }
            if (difference.Days > 7)
            {
                return " > 1 week";
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Returns true if the user with the given userid is registerd as a host on any session, false if not.
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static bool UserIsHost(string userid)
        {
            return false;
        }
    }
}