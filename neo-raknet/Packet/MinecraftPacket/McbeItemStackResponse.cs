using neo_raknet.Utils;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpeItemStackResponse : Packet
{
    public ItemStackResponses responses; // = null;

    public McpeItemStackResponse()
    {
        Id = 0x94;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(responses);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        responses = ReadItemStackResponses();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        responses = default(ItemStackResponses);
    }
}