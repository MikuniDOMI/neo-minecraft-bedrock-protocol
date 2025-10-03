namespace neo_protocol.Packet.MinecraftPacket;

public class NoFreeIncomingConnections : Packet
{
    public readonly byte[] offlineMessageDataId = new byte[]
    {
        0x00, 0xff, 0xff, 0x00, 0xfe, 0xfe, 0xfe, 0xfe, 0xfd, 0xfd, 0xfd, 0xfd, 0x12, 0x34, 0x56, 0x78
    }; // = { 0x00, 0xff, 0xff, 0x00, 0xfe, 0xfe, 0xfe, 0xfe, 0xfd, 0xfd, 0xfd, 0xfd, 0x12, 0x34, 0x56, 0x78 };

    public long serverGuid; // = null;

    public NoFreeIncomingConnections()
    {
        Id = 0x14;
        IsMcpe = false;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(offlineMessageDataId);
        Write(serverGuid);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        ReadBytes(offlineMessageDataId.Length);
        serverGuid = ReadLong();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        serverGuid = default;
    }
}