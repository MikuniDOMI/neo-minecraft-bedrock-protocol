using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using NetCoreServer;

namespace neo_raknet.Server
{
    internal class RakServer : UdpServer
    {
        public int                     rak_version      = 0xB;
        public ulong                   guid;
        public ConcurrentBag<EndPoint> connectEndPoints = new();
        public RakServer(IPEndPoint endpoint) : base(endpoint)
        {
            guid = (ulong)new Random().NextDouble() * ulong.MaxValue;
        }

        protected override void OnStarted()
        {
            base.OnStarted();
        }

        protected override void OnStopped()
        {
            base.OnStopped();
        }

        protected override void OnReceived(EndPoint endpoint, byte[] buffer, long offset, long size)
        {
            switch ((PacketID)buffer[0])
            {
                case PacketID.OpenConnectionRequest1:
                    break;
                case PacketID.OpenConnectionRequest2:
                    break;
                default:
                    if
                    break;
            }
        }

        protected override void OnError(SocketError error)
        {
            base.OnError(error);
        }
    }
}
