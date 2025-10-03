namespace neo_protocol.Packet.MinecraftPacket;

public class McpeModalFormResponse : Packet
{
    public byte cancelReason; // = null;
    public string data = "";

    public uint formId; // = null;

    public McpeModalFormResponse()
    {
        Id = 0x65;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();
        WriteUnsignedVarInt(formId);
        Write(data);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        formId = ReadUnsignedVarInt();
        if (ReadBool()) data = ReadString();
        if (ReadBool()) cancelReason = ReadByte();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        formId = default;
        data = default;
        cancelReason = default;
    }
}