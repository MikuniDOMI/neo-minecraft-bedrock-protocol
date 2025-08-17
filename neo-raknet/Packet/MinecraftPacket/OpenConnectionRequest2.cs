using System.Net;

namespace neo_raknet.Packet.MinecraftPacket;

public class OpenConnectionRequest2 : Packet
{
    public readonly byte[] offlineMessageDataId = new byte[]
    {
        0x00, 0xff, 0xff, 0x00, 0xfe, 0xfe, 0xfe, 0xfe, 0xfd, 0xfd, 0xfd, 0xfd, 0x12, 0x34, 0x56, 0x78
    }; // = { 0x00, 0xff, 0xff, 0x00, 0xfe, 0xfe, 0xfe, 0xfe, 0xfd, 0xfd, 0xfd, 0xfd, 0x12, 0x34, 0x56, 0x78 };

    public long clientGuid; // = null;
    public short mtuSize; // = null;
    public IPEndPoint remoteBindingAddress; // = null;

    public OpenConnectionRequest2()
    {
        Id = 0x07;
        IsMcpe = false;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(offlineMessageDataId);
        Write(remoteBindingAddress);
        WriteBe(mtuSize);
        Write(clientGuid);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        ReadBytes(offlineMessageDataId.Length);
        remoteBindingAddress = ReadIPEndPoint();
        mtuSize = ReadShortBe();
        clientGuid = ReadLong();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        remoteBindingAddress = default;
        mtuSize = default;
        clientGuid = default;
    }
}