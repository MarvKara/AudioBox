using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Crowdsound_Slave_Server_Application.Modules.ConnectionInterface
{
    public class TCPConnection
    {
        private Socket socket = null;
        private IPHostEntry hostInformation = null;
        private IPEndPoint endPoint = null;

        public TCPConnection(string address, int port)
        {
            hostInformation = Dns.Resolve(address);
            endPoint = new IPEndPoint(hostInformation.AddressList[0], port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public bool Connect()
        {
            try
            {
                socket.Connect(endPoint);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Disconnect()
        {
            socket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
            socket.Disconnect(false);
        }

        public bool IsAlive()
        {
            return this.socket.Poll(100000, SelectMode.SelectWrite);
        }

        public bool IsReceiving(out byte[] buffer)
        {
            buffer = new byte[256];
            return (this.socket.Receive(buffer) > 0);
        }

        public void Send(byte[] data)
        {
            this.socket.Send(data);
        }
    }
}
