namespace neo_protocol.Packet.MinecraftPacket;

public class McpeServerSettingsResponse : Packet
{
    public string data; // = null;

    public long formId; // = null;

    public McpeServerSettingsResponse()
    {
        Id = 0x67;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteUnsignedVarLong(formId);
        Write(data);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        formId = ReadUnsignedVarLong();
        data = ReadString();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        formId = default;
        data = default;
    }
}