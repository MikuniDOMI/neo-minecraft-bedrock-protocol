using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using neo_raknet.Packet.MinecraftPacket;
using NetCoreServer;

namespace neo_raknet.Server;

public class RakServer : UdpServer
{
    public ConcurrentDictionary<IPEndPoint, RakServerSession> connections = new();
    public long guid;
    public int rak_version = 0xB;

    public RakServer(IPEndPoint endpoint) : base(endpoint)
    {
        guid = (long)(new Random().NextDouble() * long.MaxValue);
    }

    protected override Socket CreateSocket()
    {
        var listener = base.CreateSocket();
        if (Environment.OSVersion.Platform != PlatformID.MacOSX)
        {
            //_listener.Client.ReceiveBufferSize = 1600*40000;
            listener.ReceiveBufferSize = int.MaxValue;
            //_listener.Client.SendBufferSize = 1600*40000;
            listener.SendBufferSize = int.MaxValue;
        }

        listener.DontFragment = false;
        listener.EnableBroadcast = true;

        if (Environment.OSVersion.Platform != PlatformID.Unix && Environment.OSVersion.Platform != PlatformID.MacOSX)
        {
            // SIO_UDP_CONNRESET (opcode setting: I, T==3)
            // Windows:  Controls whether UDP PORT_UNREACHABLE messages are reported.
            // - Set to TRUE to enable reporting.
            // - Set to FALSE to disable reporting.

            var IOC_IN = 0x80000000;
            uint IOC_VENDOR = 0x18000000;
            var SIO_UDP_CONNRESET = IOC_IN | IOC_VENDOR | 12;
            listener.IOControl((int)SIO_UDP_CONNRESET, new[] { Convert.ToByte(false) }, null);

            //
            //WARNING: We need to catch errors here to remove the code above.
            //
        }

        return listener;
    }

    protected override void OnStarted()
    {
        ReceiveAsync();
    }

    protected override void OnStopped()
    {
        base.OnStopped();
    }

    protected override void OnReceived(EndPoint endpoint, byte[] buffer, long offset, long size)
    {
        ReceiveAsync();
        switch ((PacketID)buffer[0])
        {
            case PacketID.OpenConnectionRequest1:
                HandleOpenConnectRequest1(endpoint, buffer);
                break;
            case PacketID.OpenConnectionRequest2:
                HandleOpenConnectRequest2(endpoint, buffer);
                break;
            case PacketID.ConnectionRequest:
                HandleConnectionRequest(endpoint, buffer);
                break;
            case PacketID.NewIncomingConnection:
                break;
            case PacketID.UnconnectedPing1:
                HandleUnconnectPing(endpoint, buffer);
                break;
            case PacketID.UnconnectedPing2:
                HandleUnconnectPing(endpoint, buffer);
                break;
            default:
                Packet.Packet.HexDump(buffer);
                break;
        }
    }

    protected void HandleConnectionRequest(EndPoint endPoint, ReadOnlyMemory<byte> bytes)
    {
        ConnectionRequest request = new();
        request.Decode(bytes);
        ConnectionRequestAccepted accepted = new();
        accepted.incomingTimestamp = request.timestamp;
        accepted.serverTimestamp = Utils.Utils.GetTimeStampLong();
        accepted.systemAddress = (IPEndPoint)endPoint;
        accepted.systemAddresses = new[]
            { IPEndPoint.Parse("255.255.255.255:19132"), IPEndPoint.Parse("255.255.255.255:19132") };
        accepted.systemIndex = 0;
        SendAsync(endPoint, accepted.Encode());
    }

    protected void HandleUnconnectPing(EndPoint endPoint, ReadOnlyMemory<byte> bytes)
    {
        UnconnectedPing ping = new();
        ping.Decode(bytes);
        UnconnectedPong pong = new();
        pong.serverId = guid;
        pong.pingId = ping.pingId;
        pong.serverName =
            "MCPE;Dedicated Server;390;1.14.60;0;10;13253860892328930865;Bedrock level;Survival;1;19132;19133;";
        SendAsync(endPoint, pong.Encode());
    }

    protected void HandleOpenConnectRequest1(EndPoint endPoint, ReadOnlyMemory<byte> bytes)
    {
        var reply1 = new OpenConnectionReply1();
        reply1.mtuSize = Utils.Utils.UDP_CLIENT_MTU;
        reply1.serverHasSecurity = 0x00;
        reply1.serverGuid = guid;
        SendAsync(endPoint, reply1.Encode());
    }

    protected void HandleOpenConnectRequest2(EndPoint endPoint, ReadOnlyMemory<byte> bytes)
    {
        var request2 = new OpenConnectionRequest2();
        request2.Decode(bytes);
        var reply2 = new OpenConnectionReply2();
        reply2.mtuSize = request2.mtuSize;
        reply2.clientEndpoint = (IPEndPoint)endPoint;
        reply2.serverGuid = guid;
        reply2.doSecurityAndHandshake = new byte[] { 0x00 };
        connections.TryAdd((IPEndPoint)endPoint, new RakServerSession());
        SendAsync(endPoint, reply2.Encode());
    }

    protected override void OnError(SocketError error)
    {
        base.OnError(error);
    }
}