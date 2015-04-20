using System.Collections.Generic;
using Crowdsound_Centralized_Server_Application.Modules.ClientSocketInterface;
using Crowdsound_Centralized_Server_Application.Modules.Reporting;
using GeneralSupportLibrary;

namespace Crowdsound_Centralized_Server_Application.Modules.DeviceManagement
{
    /// <summary>
    /// Static DeviceManagement Class, which handles all Device 
    /// and authorization related actions
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2014
    /// </summary>
    public static class MobileDeviceManagement
    {
        #region /// <VAR>

        public static List<MobileDevice> BoundDevices { get; set; }
        private static List<ClientConnection> PendingConnections { get; set; }

        #endregion

        /// <summary>
        /// Initializes all needed classvariables 
        /// and prepares structures for use
        /// </summary>
        internal static void Initialize()
        {
            RandomOperations.Initialize();
            BoundDevices = new List<MobileDevice>();
            PendingConnections = new List<ClientConnection>();
        }
        internal static string AddDevice(ClientConnection connection, string imei, string secret)
        {
            var newDevice = new MobileDevice(imei, secret);
            var deviceId = newDevice.DeviceInstance.DeviceId;
            connection.Bind(deviceId);
            BoundDevices.Add(newDevice);
            ConsoleHelper.PrintNewDeviceBound(newDevice.DeviceInstance.Imei, deviceId);
            return deviceId;
        }

        public static string QueueConnectionForAuthentification(ClientConnection connection, string authentificationId)
        {
            var temporaryId = authentificationId;
            PendingConnections.Add(connection);
            ConsoleHelper.PrintServerListedForAuthentification(temporaryId, connection.GetIpAddress());
            return temporaryId;
        }

        public static string AuthentificateDevice(string imei, string temporyId, string supposedId, string secret)
        {
            ClientConnection clientConnection;
            if (supposedId == "NONE")
            {
                clientConnection = PendingConnections.Find(delegate(ClientConnection connection) { return connection.CoherentDeviceId == temporyId; });
                string newSecret = GenerateNewSecret();
                string serverId = AddDevice(clientConnection, imei, newSecret);
                return serverId + "$" + newSecret;
            }
            else
            {
                foreach (MobileDevice device in BoundDevices)
                {
                    if (device.GetDeviceInstanceId() == supposedId)
                    {
                        clientConnection = PendingConnections.Find(delegate(ClientConnection connection) { return connection.CoherentDeviceId == supposedId; });

                        if (clientConnection == null)
                        {
                            clientConnection = PendingConnections.Find(connection => connection.CoherentDeviceId == temporyId);
                            clientConnection.Bind(supposedId);
                        }
                        if (device.SecretMatches(secret))
                        {
                            device.SetOnline(clientConnection);
                            clientConnection.Mute();
                            PendingConnections.Remove(PendingConnections.Find(delegate(ClientConnection connection) { return connection.CoherentDeviceId == supposedId; }));
                            ConsoleHelper.PrintClientConEstablished(clientConnection.GetIpAddress(), device.GetDeviceInstanceId());
                            return "CONNECTION ESTABLISHED";
                        }
                        else
                        {
                            return "WRONG CREDENTIALS PROVIDED";
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                return "CRITICAL ERROR. REPORT TO ADMINISTRATOR";
            }
        }

        private static string GenerateNewSecret()
        {
            var secret = RandomOperations.GenerateRandomString(40);
            return secret;
        }

        /// <summary>
        /// Generates a new 10-Digit internal deviceId consisting of 10-digit-strings
        /// made up out of small or capital letters
        /// </summary>
        /// <returns>a unique device id</returns>
        internal static string GenerateInternalDeviceId()
        {
            var deviceId = RandomOperations.GenerateRandomString(10);
            while(InternalDeviceIdExists(deviceId))
            {
                deviceId = RandomOperations.GenerateRandomString(10);
            }
            return deviceId;
        }

        /// <summary>
        /// Returns true if a deviceId is already in use
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        private static bool InternalDeviceIdExists(string deviceId)
        {
            foreach (var device in BoundDevices)
            {
                if (deviceId.Equals(device.DeviceInstance.DeviceId))
                {
                    return true;
                }
            }
            return false;
        }
    }
}