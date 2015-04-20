using System;
using Crowdsound_Centralized_Server_Application.Modules.ClientSocketInterface;

namespace Crowdsound_Centralized_Server_Application.Modules.DeviceManagement
{
    public class MobileDevice
    {
        public DeviceInstance DeviceInstance { get; set; }
        public ClientConnection ClientConnection { get; set; }

        public MobileDevice(string imei, string secret)
        {
            this.DeviceInstance = new DeviceInstance(imei);
            this.DeviceInstance.Secret = secret;
        }

        internal string GetDeviceInstanceId()
        {
            return this.DeviceInstance.DeviceId;
        }

        internal bool SecretMatches(string secret)
        {
            if (String.Equals(this.DeviceInstance.Secret, secret, StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }
            return false;
        }

        internal void SetOnline(ClientConnection clientConnection)
        {
            DeviceInstance.SetStatusOnline();
            ClientConnection = clientConnection;
        }
        internal void SetOffline()
        {
            DeviceInstance.SetStatusOffline();
            ClientConnection = null;
        }
    }
}
