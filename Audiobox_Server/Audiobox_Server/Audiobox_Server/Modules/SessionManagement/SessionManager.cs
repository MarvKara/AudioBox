using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Audiobox_Server.Forms;
using Audiobox_Server.General;
using Audiobox_Server.Modules.AudioboxConsole;
using Audiobox_Server.Modules.SessionManagement.Objects;
using Audiobox_Server.Modules.UserManagement;
using Audiobox_Server.Modules.Youtube.YoutubeDownloader;
using Audiobox_Server.Modules.Support;

namespace Audiobox_Server.Modules.SessionManagement
{
    /// <summary>
    /// Manages all Sessions currently known to the Server
    /// :: TO FIX POSSIBLE PROBLEMS FORWARD THE PORTS FROM SETTINGS TO HOSTMACHINE ::
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2013
    /// </summary>
    public class SessionManager
    {
        public delegate void NewSessionHandler(List<Session> sessions);
        public static event NewSessionHandler NewSession;

        public delegate void NewTrackHandler(string sessionID);
        public static event NewTrackHandler NewTrack;

        public delegate void SessionStatusChangedHandler(List<Session> sessions);
        public static event SessionStatusChangedHandler SessionStatusChanged;

        public delegate void PlaylistUpdateHandler(Session currentSession);
        public static event PlaylistUpdateHandler PlaylistUpdate;

        public static List<Session> Sessions { get; set; }
        private static List<int> FreePorts { get; set; }
        private DateTime LastCleanUp;
        private DateTime LastInactiveUserCheck;

        private Thread sessionManagerThread;

        #region EVENT_HANDLING_METHODS

        public static void OnPlaylistUpdate(Session currentSession)
        {
            if (PlaylistUpdate != null)
            {
                FindSessionBySessionId(currentSession.Id).Playlist.UpdateUpdateTime();
                PlaylistUpdate(currentSession);
            }
        }

        public static void OnSessionStatusChanged()
        {
            if (SessionStatusChanged != null)
            {
                SessionStatusChanged(Sessions);
            }
        }

        /// <summary>
        /// Handling method for new Sessions
        /// </summary>
        public static void OnNewSession()
        {
            if (NewSession != null)
            {
                NewSession(Sessions);
            }
        }

        /// <summary>
        /// Handling method for new Tracks
        /// </summary>
        public static void OnNewTrack(string sessionID)
        {
            if (NewTrack != null)
            {
                NewTrack(sessionID);
            }
        }

        #endregion

        /// <summary>
        /// Default constructor for the SessionManager
        /// </summary>
        public SessionManager()
        {
            SettingsForm.SettingsChanged += new SettingsForm.SettingsChangedHandler(SettingsForm_SettingsChanged);

            Sessions = new List<Session>();
            FreePorts = new List<int>();
            YoutubeDownloadManager.Initialize();

            this.LastCleanUp = DateTime.Now;
            this.LastInactiveUserCheck = DateTime.Now;

            int[] ports = Actions.TranslatePortRange(Settings.STREAM_PORTRANGE);
            FreePorts.AddRange(ports);
            InititializeThread();
        }

        /// <summary>
        /// Initializes the SessionManagers Thread
        /// </summary>
        private void InititializeThread()
        {
            sessionManagerThread = new Thread(Listen);
            sessionManagerThread.IsBackground = true;
            sessionManagerThread.Start(); 
        }

        /// <summary>
        /// Event code for the case that the settings have changed
        /// </summary>
        void SettingsForm_SettingsChanged()
        {
            this.Reset();
        }

        /// <summary>
        /// Resets the SessionManager and starts again with refreshed data from settings
        /// </summary>
        public void Reset()
        {
            if (Sessions.Count > 0)
            {
                MessageBox.Show("Cannot reset Sessionmanager while there are Sessions active! Your Changes will be applied at the next program restart");
                return;
            }
            sessionManagerThread.Abort();
            Sessions = new List<Session>();
            FreePorts = new List<int>();

            int[] ports = Actions.TranslatePortRange(Settings.STREAM_PORTRANGE);
            FreePorts.AddRange(ports);

            InititializeThread();
        }

        /// <summary>
        /// Method to force all Sessions offline
        /// </summary>
        public static void AbortAllSessions()
        {
            foreach (Session s in Sessions)
            {
                if (!s.isStopped)
                {
                    s.Stop();
                }
            }
        }

        /// <summary>
        /// Method to be run while SessionManager is active
        /// </summary>
        private void Listen()
        {
            int previousSessionCount = 0;
            Dictionary<string, bool> previousSessionStatuses = new Dictionary<string, bool>();

            while (true)
            {
                #region NEW_SESSION_LISTENER

                int sessionCount = Sessions.Count;
                if (sessionCount != previousSessionCount)
                {
                    OnNewSession();
                    previousSessionCount = sessionCount;
                }

                #endregion

                #region SESSION_STATUS_CHANGED_LISTENER

                Dictionary<string, bool> SessionStatuses = new Dictionary<string, bool>();
                foreach (Session s in Sessions)
                {
                    SessionStatuses.Add(s.Id, s.isActive);
                }
                Thread.Sleep(1500);
                if (SessionStatuses != previousSessionStatuses)
                {
                    OnSessionStatusChanged();
                    previousSessionStatuses = SessionStatuses;
                }

                #endregion

                #region REMOVE_INACTIVE_USER_LISTENER

                if ((DateTime.Now - LastInactiveUserCheck).Minutes >= 1)
                {
                    LastInactiveUserCheck = DateTime.Now;
                    foreach (Session session in Sessions)
                    {
                        List<string> inactiveUsers = new List<string>();
                        foreach (User user in session.Clients)
                        {
                            if ((DateTime.Now - user.LastKeepAlive).Minutes >= 15)
                            {
                                inactiveUsers.Add(user.UserId);
                            }
                        }
                        foreach (string userid in inactiveUsers)
                        {
                            UserManager.RemoveUserFromSession(userid, false);
                        }
                        session.Host.LastKeepAlive = DateTime.Now;
                    }
                }

                #endregion

                if ((DateTime.Now - LastCleanUp).TotalMinutes >= 2)
                {
                    LastCleanUp = DateTime.Now;
                    GC.Collect();
                }
            }
        }

        /// <summary>
        /// Generates a unique SessionID
        /// </summary>
        /// <returns></returns>
        public static string GenerateUniqueSessionId()
        {
            char[] raw = new char[4];

            raw[0] = Actions.GenerateRandomNumber();
            raw[1] = Actions.GenerateRandomNumber();
            raw[2] = Actions.GenerateRandomNumber();
            raw[3] = Actions.GenerateRandomNumber();

            string id = new string(raw);

            if (!SessionIdExists(id))
            {
                return id;
            }
            else
            {
                return GenerateUniqueSessionId();
            }
        }

        /// <summary>
        /// Returns if a TrackId exists
        /// </summary>
        /// <returns></returns>
        private static bool TrackIdExits(string id)
        {
            bool exists = false;

            foreach (Session s in Sessions)
            {
                foreach (Track track in s.Playlist.Tracks)
                {
                    if (track.Id == id)
                    {
                        exists = true;
                    }
                    else
                    {
                        exists = false;
                    }
                }
            }
            return exists;
        }

        /// <summary>
        /// Votes a Track on a given session with a given id up or down
        /// </summary>
        /// <param name="trackId"></param>
        /// <param name="sessionId"></param>
        /// <param name="direction"></param>
        public static void VoteTrack(string trackId, string sessionId, string direction)
        {
            if (direction == "UP")
            {
                FindTrack(trackId, sessionId).VoteUp();
            }
            else
            {
                FindTrack(trackId, sessionId).VoteDown();
            }
            OnPlaylistUpdate(FindSessionBySessionId(sessionId));
        }

        /// <summary>
        /// Returns a track with a given id on a certain session
        /// </summary>
        /// <param name="trackId"></param>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public static Track FindTrack(string trackId, string sessionId)
        {
            return FindSessionBySessionId(sessionId).FindTrack(trackId);
        }

        /// <summary>
        /// Method which returns true if a track exists on a certain session
        /// and false if not
        /// </summary>
        /// <param name="session"></param>
        /// <param name="trackId"></param>
        /// <returns></returns>
        public static bool TrackExists(Session session, string trackId)
        {
            if (session != null)
            {
                foreach (Track t in session.Playlist.Tracks)
                {
                    if (t.Id.ToLower() == trackId.ToLower())
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Adds a Track to a certain Sessions playlist
        /// </summary>
        /// <param name="session"></param>
        /// <param name="track"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool CanAddTrack(ref Session session, Track track, out string msg)
        {
            if (session != null)
            {
                session.SubmitNewTrack(track);
                OnNewTrack(session.Id);
                msg = "";
                return true;
            }
            else
            {
                msg = "No session selected. Type \"select <session_name>\" to select a session first";
                return false;
            }
        }

        /// <summary>
        /// Creates a Session given via parameter
        /// </summary>
        /// <param name="session"></param>
        private static void CreateSession(Session session)
        {
            try
            {
                Sessions.Add(session);
            }
            catch
            {
                CreateSession(session);
            }
        }

        /// <summary>
        /// Adds a specific session to the sessionmanagers internal list and hooks up with the event handler.
        /// Returns true if successful and false if not.
        /// </summary>
        /// <param name="session"></param>
        /// <param name="userId"></param>
        /// <param name="isAndroidUser"></param>
        /// <returns></returns>
        public static bool AddSession(Session session, string userId, bool isAndroidUser)
        {
            if (UserManager.UserIsUnassigned(userId) || userId == string.Empty)
            {
                session.Start();
                CreateSession(session);

                if (isAndroidUser)
                {
                    UserManager.AssignUser(session.Id, userId, true);
                }
                else
                {
                    UserManager.AssignUser(session.Id, UserManager.CreateUser("DEBUG").UserId, true);
                }

                session.MediaServer.NextTrack += new MediaServer.NextTrackHandler(MediaServer_NextTrack);
                session.FileManager.NewTrack += new FileManager.NewTrackHandler(FileManager_NewTrack);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Event-Handling-Method for the case of new Tracks
        /// </summary>
        /// <param name="sessionID"></param>
        /// <param name="track"></param>
        static void FileManager_NewTrack(string sessionID, Track track)
        {
            OnPlaylistUpdate(FindSessionBySessionId(sessionID));
            AddTrackToSession(sessionID, track);
        }

        /// <summary>
        /// Adds a track object to a Playlist with a given playlist
        /// </summary>
        /// <param name="sessionID"></param>
        /// <param name="track"></param>
        public static void AddTrackToSession(string sessionID, Track track)
        {
            FindSessionBySessionId(sessionID).SubmitNewTrack(track);
            OnNewTrack(sessionID);
        }

        /// <summary>
        /// test method
        /// </summary>
        public static void AddYoutubeTrackToQueue(string userid, string url)
        {
            FindSessionByUserId(userid).AddYoutubeTrack(userid, url);
        }

        /// <summary>
        /// Method to handle a NextTrack Event
        /// </summary>
        static void MediaServer_NextTrack(string sid)
        {
            OnPlaylistUpdate(FindSessionBySessionId(sid));
            NextTrack(sid);
            SessionManager.OnNewTrack(sid);
        }

        /// <summary>
        /// Changes the first Track of the given sessions playlist
        /// </summary>
        /// <param name="sessionId"></param>
        private static void NextTrack(string sessionId)
        {
            foreach (Session session in Sessions)
            {
                if (session.Id == sessionId)
                {
                    session.Playlist.NextTrack();
                    Thread.Sleep(200);
                }
            }
        }

        /// <summary>
        /// Stops a Session with a given id
        /// </summary>
        /// <param name="id"></param>
        public static void StopSession(string id)
        {
            foreach(Session s in Sessions)
            {
                if (s.Id.ToLower() == id.ToLower())
                {
                    s.Stop();
                }
            }
        }

        /// <summary>
        /// Deletes the session with a given Session ID
        /// </summary>
        /// <param name="sessionid"></param>
        public static void DeleteSession(string sessionid)
        {
            List<Session> temp = Sessions;

            int index = 0;
            foreach (Session session in temp)
            {
                if (session.Id.ToLower() == sessionid.ToLower())
                {
                    if (session.isActive == false)
                    {
                        UserManager.RemoveUserFromSession(Sessions[index].Host.UserId, true);

                        User[] clone = new User[Sessions[index].Clients.Count];
                        Sessions[index].Clients.CopyTo(clone);

                        foreach(User user in clone)
                        {
                            UserManager.RemoveUserFromSession(user.UserId, false);
                        }

                        Sessions[index].Terminate();
                        Sessions.RemoveAt(index);

                        break;
                    }
                    else
                    {
                        LogConsole.ThrowException(session.Id, "Session cannot be deleted while not being stopped");
                        break;
                    }
                }
                else
                {
                    index++;
                }
            }
        }

        /// <summary>
        /// Returns the next free port for a new MediaServer instance
        /// </summary>
        /// <returns></returns>
        public static int GetNextFreePort()
        {
            int port = FreePorts[0];

            FreePorts.RemoveAt(0);

            return port;
        }

        /// <summary>
        /// Releases a previously occupied port back to the system to be used again for another purpose
        /// </summary>
        /// <param name="port"></param>
        public static void ReleasePort(int port)
        {
            FreePorts.Add(port);
        }

        /// <summary>
        /// Returns the Session with the given identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Session FindSessionBySessionId(string sessionId)
        {
            Session result = null;

            List<Session> tempList = Sessions;

            try
            {
                foreach (Session s in tempList)
                {
                    if (sessionId.ToLower() == s.Id.ToLower())
                    {
                        result = s;
                    }
                }
            }
            catch
            {
                result = FindSessionBySessionId(sessionId);
            }
            return result;
        }

        /// <summary>
        /// Returns a Session object if the user specified by the given userId parameter is assigned to this session
        /// OR null if the user is unassigned or not existing
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static Session FindSessionByUserId(string userId)
        {
            Session result = null;

            List<Session> tempList = Sessions;

            try
            {
                foreach (Session s in tempList)
                {
                    foreach (User user in s.Clients)
                    {
                        if (user.UserId == userId)
                        {
                            result = s;
                        }
                    }
                    if (s.Host.UserId == userId)
                    {
                        result = s;
                    }
                }
            }
            catch
            {
                result = FindSessionBySessionId(userId);
            }
            return result;
        }

        /// <summary>
        /// Returns true if a Session with a given id exists and false if not
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool SessionExists(string id)
        {
            Session[] clone = (Session[])Sessions.ToArray().Clone();
            foreach (Session s in clone)
            {
                if (s.Id.ToLower() == id.ToLower())
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Returns if a SessionID is available
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static bool SessionIdExists(string id)
        {
            bool exists = false;

            foreach (Session s in Sessions)
            {
                if (s.Id == id)
                {
                    exists = true;
                }
                else
                {
                    exists = false;
                }
            }
            return exists;
        }
    }
}