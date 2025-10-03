using neo_protocol.Packet.MinecraftStruct.Entity;

namespace neo_protocol.Packet.MinecraftPacket;

public class McpePlayerList : Packet
{
    public PlayerRecords records; // = null;

    public McpePlayerList()
    {
        Id = 0x3f;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(records);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        records = ReadPlayerRecords();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        records = default;
    }
}