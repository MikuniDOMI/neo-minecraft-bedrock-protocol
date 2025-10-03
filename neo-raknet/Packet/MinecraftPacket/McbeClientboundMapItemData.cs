using neo_protocol.Utils;

namespace neo_protocol.Packet.MinecraftPacket;

public class McpeClientboundMapItemData : Packet
{
    public MapInfo mapinfo; // = null;

    public McpeClientboundMapItemData()
    {
        Id = 0x43;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(mapinfo);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        mapinfo = ReadMapInfo();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        mapinfo = default;
    }
}