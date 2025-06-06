using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UdpClient = NetCoreServer.UdpClient;

namespace neo_raknet.Client
{
    internal class RakClient : UdpClient
    {
        
        public RakClient(IPEndPoint endpoint) : base(endpoint)
        {
           
        }

        protected override void OnReceived(EndPoint endpoint, byte[] buffer, long offset, long size)
        {
            base.OnReceived(endpoint, buffer, offset, size);
        }

        protected override void OnError(SocketError error)
        {
            base.OnError(error);
        }
    }
}
