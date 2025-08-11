namespace neo_raknet.Packet.MinecraftPacket;

public class McpeNpcRequest : Packet
{
    public long   runtimeEntityId; // = null;
    public byte   unknown0; // = null;
    public string unknown1; // = null;
    public byte   unknown2; // = null;

    public McpeNpcRequest()
    {
        Id = 0x62;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteUnsignedVarLong(runtimeEntityId);
        Write(unknown0);
        Write(unknown1);
        Write(unknown2);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        runtimeEntityId = ReadUnsignedVarLong();
        unknown0 = ReadByte();
        unknown1 = ReadString();
        unknown2 = ReadByte();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        runtimeEntityId = default;
        unknown0 = default;
        unknown1 = default;
        unknown2 = default;
    }
}