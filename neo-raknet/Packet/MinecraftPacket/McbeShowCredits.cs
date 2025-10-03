namespace neo_protocol.Packet.MinecraftPacket;

public class McpeShowCredits : Packet
{
    public long runtimeEntityId; // = null;
    public int status; // = null;

    public McpeShowCredits()
    {
        Id = 0x4b;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteUnsignedVarLong(runtimeEntityId);
        WriteSignedVarInt(status);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        runtimeEntityId = ReadUnsignedVarLong();
        status = ReadSignedVarInt();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        runtimeEntityId = default;
        status = default;
    }
}