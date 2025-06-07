namespace neo_raknet.Packet.MinecraftPacket;

public class McpeShowStoreOffer : Packet
{
    public string unknown0; // = null;
    public bool   unknown1; // = null;

    public McpeShowStoreOffer()
    {
        Id = 0x5b;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(unknown0);
        Write(unknown1);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        unknown0 = ReadString();
        unknown1 = ReadBool();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        unknown0 = default;
        unknown1 = default;
    }
}