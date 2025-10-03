using neo_protocol.Packet.MinecraftStruct.Item;

namespace neo_protocol.Packet.MinecraftPacket;

public class McpeCreativeContent : Packet
{
    public List<creativeGroup> groups; // = null;
    public List<CreativeItemEntry> input; // = null;

    public McpeCreativeContent()
    {
        Id = 0x91;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(groups);
        Write(input);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        groups = ReadCreativeGroups();
        input = ReadCreativeItemStacks();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        groups = default;
        input = default;
    }
}