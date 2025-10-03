namespace neo_protocol.Packet.MinecraftPacket;

public class McpeContainerSetData : Packet
{
    public int property; // = null;
    public int value; // = null;

    public byte windowId; // = null;

    public McpeContainerSetData()
    {
        Id = 0x33;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(windowId);
        WriteSignedVarInt(property);
        WriteSignedVarInt(value);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        windowId = ReadByte();
        property = ReadSignedVarInt();
        value = ReadSignedVarInt();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        windowId = default;
        property = default;
        value = default;
    }
}