namespace neo_protocol.Packet.MinecraftPacket;

public class McpeNetworkStackLatency : Packet
{
    public ulong timestamp; // = null;
    public byte unknownFlag; // = null;

    public McpeNetworkStackLatency()
    {
        Id = 0x73;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(timestamp);
        Write(unknownFlag);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        timestamp = ReadUlong();
        unknownFlag = ReadByte();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        timestamp = default;
        unknownFlag = default;
    }
}