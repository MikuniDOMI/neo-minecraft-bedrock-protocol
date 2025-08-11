namespace neo_raknet.Packet.MinecraftPacket;

public class McpeLogin : Packet
{
    public byte[] payload; // = null;

    public int protocolVersion; // = null;

    public McpeLogin()
    {
        Id = 0x01;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteBe(protocolVersion);
        WriteByteArray(payload);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        protocolVersion = ReadIntBe();
        payload = ReadByteArray();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        protocolVersion = default;
        payload = default;
    }
}