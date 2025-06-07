namespace neo_raknet.Packet.MinecraftPacket;

public class McpeRequestNetworkSettings : Packet
{
    public int protocolVersion; // = null;

    public McpeRequestNetworkSettings()
    {
        Id = 0xc1;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteBe(protocolVersion);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        protocolVersion = ReadIntBe();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        protocolVersion = default;
    }
}