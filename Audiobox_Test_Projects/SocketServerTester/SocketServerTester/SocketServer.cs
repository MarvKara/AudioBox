using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace SocketServerTester
{
    public static class SocketServer
    {
        private static Socket sListener;
        private static Thread serverThread;

        public static void Initialize()
        {
            /// Socket Creation

            IPHostEntry ipHost = Dns.GetHostEntry("");
            IPAddress ipAdress = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAdress, 9999);

            sListener = new Socket(ipAdress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sListener.Bind(ipEndPoint);
            sListener.Listen(256);

            SocketPermission permission = new SocketPermission(NetworkAccess.Accept, TransportType.Tcp, "", SocketPermission.AllPorts);
            AsyncCallback aCallback = new AsyncCallback(AcceptCallback);
            sListener.BeginAccept(aCallback, sListener);
            // End Socket Creation
            
            serverThread = new Thread(ServerMethod);
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        private static void AcceptCallback(IAsyncResult result)
        {
            ///
        }

        public static void ServerMethod()
        {
 
        }
    }
}
