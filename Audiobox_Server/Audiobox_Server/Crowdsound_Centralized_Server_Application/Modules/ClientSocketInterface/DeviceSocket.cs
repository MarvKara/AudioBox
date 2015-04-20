using System.Net;
using System.Net.Sockets;

namespace Crowdsound_Centralized_Server_Application.Modules.ClientSocketInterface
{
    public class DeviceSocket
    {
        private Socket Socket { get; set; }

        public DeviceSocket(Socket socket)
        {
            this.Socket = socket;
        }

        public string GetIpAddress()
        {
            return this.Socket.RemoteEndPoint.ToString().Split(':')[0];
        }

        public string GetCallbackPort()
        {
            return this.Socket.RemoteEndPoint.ToString().Split(':')[1];
        }

        public string GetLocalPort()
        {
            return ((IPEndPoint)this.Socket.LocalEndPoint).Port.ToString();
        }

        public bool IsAlive()
        {
            try
            {
                return this.IsConnected();
            }
            catch
            {
                return false;
            }
        }

        public bool IsConnected()
        {
            return this.Socket.Connected;
        }

        public bool IsReceiving(out byte[] buffer)
        {
            buffer = new byte[256];
            return (this.Socket.Receive(buffer) > 0);
        }

        public void Send(byte[] data)
        {
            this.Socket.Send(data);
        }

        public void Disconnect()
        {
            this.Socket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
            this.Socket.Disconnect(false);
        }
    }
}
