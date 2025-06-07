namespace neo_raknet.Packet.MinecraftPacket;

public class McpeStopSound : Packet
{
    public string name; // = null;
    public bool   stopAll; // = null;

    public McpeStopSound()
    {
        Id = 0x57;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(name);
        Write(stopAll);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        name = ReadString();
        stopAll = ReadBool();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        name = default;
        stopAll = default;
    }
}