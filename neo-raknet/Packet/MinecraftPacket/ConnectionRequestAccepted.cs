using System.Net;

namespace neo_protocol.Packet.MinecraftPacket;

public class ConnectionRequestAccepted : Packet
{
    public long incomingTimestamp; // = null;
    public long serverTimestamp; // = null;

    public IPEndPoint systemAddress; // = null;
    public IPEndPoint[] systemAddresses; // = null;
    public short systemIndex; // = null;

    public ConnectionRequestAccepted()
    {
        Id = 0x10;
        IsMcpe = false;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(systemAddress);
        WriteBe(systemIndex);
        Write(systemAddresses);
        Write(incomingTimestamp);
        Write(serverTimestamp);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        systemAddress = ReadIPEndPoint();
        systemIndex = ReadShortBe();
        systemAddresses = ReadIPEndPoints(20);
        incomingTimestamp = ReadLong();
        serverTimestamp = ReadLong();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        systemAddress = default;
        systemIndex = default;
        systemAddresses = default;
        incomingTimestamp = default;
        serverTimestamp = default;
    }
}