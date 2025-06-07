namespace neo_raknet.Packet.MinecraftPacket;

public class McpeStructureTemplateDataExportRequest : Packet
{
    public McpeStructureTemplateDataExportRequest()
    {
        Id = 0x84;
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