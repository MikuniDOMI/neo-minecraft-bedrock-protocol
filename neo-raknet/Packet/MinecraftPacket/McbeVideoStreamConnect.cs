namespace neo_protocol.Packet.MinecraftPacket;

public class McpeVideoStreamConnect : Packet
{
    public byte action; // = null;
    public float frameSendFrequency; // = null;
    public int resolutionX; // = null;
    public int resolutionY; // = null;

    public string serverUri; // = null;

    public McpeVideoStreamConnect()
    {
        Id = 0x7e;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(serverUri);
        Write(frameSendFrequency);
        Write(action);
        Write(resolutionX);
        Write(resolutionY);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        serverUri = ReadString();
        frameSendFrequency = ReadFloat();
        action = ReadByte();
        resolutionX = ReadInt();
        resolutionY = ReadInt();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        serverUri = default;
        frameSendFrequency = default;
        action = default;
        resolutionX = default;
        resolutionY = default;
    }
}