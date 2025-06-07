namespace neo_raknet.Packet.MinecraftPacket;

public class McpeSetCommandsEnabled : Packet
{
    public bool enabled; // = null;

    public McpeSetCommandsEnabled()
    {
        Id = 0x3b;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(enabled);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        enabled = ReadBool();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        enabled = default;
    }
}