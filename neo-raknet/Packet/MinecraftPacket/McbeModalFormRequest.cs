namespace neo_raknet.Packet.MinecraftPacket;

public class McpeModalFormRequest : Packet
{
    public string formData; // = null;

    public uint formId; // = null;

    public McpeModalFormRequest()
    {
        Id = 0x64;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteUnsignedVarInt(formId);
        Write(formData);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        formId = ReadUnsignedVarInt();
        formData = ReadString();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();


        formId = default;
        formData = default;
    }
}