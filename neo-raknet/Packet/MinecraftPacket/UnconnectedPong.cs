namespace neo_raknet.Packet.MinecraftPacket;

public class UnconnectedPong : Packet
{
    public readonly byte[] offlineMessageDataId = new byte[]
    {
        0x00, 0xff, 0xff, 0x00, 0xfe, 0xfe, 0xfe, 0xfe, 0xfd, 0xfd, 0xfd, 0xfd, 0x12, 0x34, 0x56, 0x78
    }; // = { 0x00, 0xff, 0xff, 0x00, 0xfe, 0xfe, 0xfe, 0xfe, 0xfd, 0xfd, 0xfd, 0xfd, 0x12, 0x34, 0x56, 0x78 };

    public long pingId; // = null;
    public long serverId; // = null;
    public string serverName; // = null;

    public UnconnectedPong()
    {
        Id = 0x1c;
        IsMcpe = false;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(pingId);
        Write(serverId);
        Write(offlineMessageDataId);
        WriteFixedString(serverName);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        pingId = ReadLong();
        serverId = ReadLong();
        ReadBytes(offlineMessageDataId.Length);
        serverName = ReadFixedString();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        pingId = default;
        serverId = default;
        serverName = default;
    }
}