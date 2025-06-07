namespace neo_raknet.Packet.MinecraftPacket;

public class McpeAnimate : Packet
{
    public int   actionId; // = null;
    public long  runtimeEntityId; // = null;
    public float unknownFloat;

    public McpeAnimate()
    {
        Id = 0x2c;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteSignedVarInt(actionId);
        WriteUnsignedVarLong(runtimeEntityId);

        if (actionId == 0x80 || actionId == 0x81) Write(unknownFloat);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        actionId = ReadSignedVarInt();
        runtimeEntityId = ReadUnsignedVarLong();

        if (actionId == 0x80 || actionId == 0x81) unknownFloat = ReadFloat();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        actionId = default;
        runtimeEntityId = default;
    }
}