namespace neo_protocol.Packet.MinecraftPacket;

public class McpeSetLocalPlayerAsInitialized : Packet
{
    public long runtimeEntityId; // = null;

    public McpeSetLocalPlayerAsInitialized()
    {
        Id = 0x71;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteUnsignedVarLong(runtimeEntityId);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        runtimeEntityId = ReadUnsignedVarLong();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        runtimeEntityId = default;
    }
}