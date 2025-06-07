using NetCoreServer;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;

namespace neo_raknet.Server
{
	internal class RakServer : UdpServer
	{
		public int rak_version = 0xB;
		public ulong guid;
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
				//d//efault:
					//if

				//	break;
			}
		}

		protected override void OnError(SocketError error)
		{
			base.OnError(error);
		}
	}
}
