using System.Net;

namespace neo_raknet.Packet.MinecraftPacket;

public class NewIncomingConnection : Packet
{
    public IPEndPoint clientendpoint; // = null;
    public long incomingTimestamp; // = null;
    public long serverTimestamp; // = null;
    public IPEndPoint[] systemAddresses; // = null;

    public NewIncomingConnection()
    {
        Id = 0x13;
        IsMcpe = false;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(clientendpoint);
        Write(systemAddresses);
        Write(incomingTimestamp);
        Write(serverTimestamp);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        clientendpoint = ReadIPEndPoint();
        systemAddresses = ReadIPEndPoints(20);
        incomingTimestamp = ReadLong();
        serverTimestamp = ReadLong();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        clientendpoint = default;
        systemAddresses = default;
        incomingTimestamp = default;
        serverTimestamp = default;
    }
}