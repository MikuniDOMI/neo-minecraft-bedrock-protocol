namespace neo_raknet.Packet.MinecraftPacket;

public class McpeStructureTemplateDataExportResponse : Packet
{
    public McpeStructureTemplateDataExportResponse()
    {
        Id = 0x85;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();
    }
}