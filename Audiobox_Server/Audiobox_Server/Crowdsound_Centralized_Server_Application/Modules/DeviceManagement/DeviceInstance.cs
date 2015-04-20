using System.Collections.Generic;
using Crowdsound_Centralized_Server_Application.Modules.ClientSocketInterface;

namespace Crowdsound_Centralized_Server_Application.Modules.DeviceManagement
{
    /// <summary>
    /// Represents an individual Device
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2014
    /// </summary>
    public class DeviceInstance
    {
        public string DeviceId { get; set; }
        public string Imei { get; set; }
        public string Secret { get; set; }
        public DeviceStatus Status { get; set; }

        /// <summary>
        /// The standard constructor for a DeviceInstance
        /// </summary>
        public DeviceInstance(string imei)
        {
            this.DeviceId = MobileDeviceManagement.GenerateInternalDeviceId();
            this.Imei = imei;
            this.Status = DeviceStatus.Offline;
            this.Secret = string.Empty;
        }

        public void SetStatusOnline()
        {
            this.Status = DeviceStatus.Online;
        }

        public void SetStatusOffline()
        {
            this.Status = DeviceStatus.Offline;
        }
    }
}