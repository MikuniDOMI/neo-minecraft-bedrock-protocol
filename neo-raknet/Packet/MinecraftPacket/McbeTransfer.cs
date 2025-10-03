namespace neo_protocol.Packet.MinecraftPacket;

public class McpeTransfer : Packet
{
    public ushort port; // = null;
    public bool reload; // = null;

    public string serverAddress; // = null;

    public McpeTransfer()
    {
        Id = 0x55;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(serverAddress);
        Write(port);
        Write(reload);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        serverAddress = ReadString();
        port = ReadUshort();
        reload = ReadBool();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        serverAddress = default;
        port = default;
        reload = default;
    }
}