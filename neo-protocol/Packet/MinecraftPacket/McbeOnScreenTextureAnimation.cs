namespace neo_protocol.Packet.MinecraftPacket;

public class McpeOnScreenTextureAnimation : Packet
{
    public int effectId; // = null;

    public McpeOnScreenTextureAnimation()
    {
        Id = 0x82;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(effectId);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        effectId = ReadInt();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        effectId = default;
    }
}