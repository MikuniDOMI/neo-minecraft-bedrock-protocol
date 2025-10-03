namespace neo_protocol.Packet.MinecraftPacket;

public class McpePermissionRequest : Packet
{
    public short flagss; // = null;
    public uint permission; // = null;

    public long runtimeEntityId; // = null;

    public McpePermissionRequest()
    {
        Id = 0xb9;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        runtimeEntityId = ReadLong();
        permission = ReadUnsignedVarInt();
        flagss = ReadShort();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        runtimeEntityId = default;
        permission = default(int);
        flagss = default;
    }
}