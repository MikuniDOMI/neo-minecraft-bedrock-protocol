using neo_raknet.Utils.UDP;

namespace neo_raknet.Packet.MinecraftPacket;

public class OpenConnectionRequest1 : Packet
{
    public readonly byte[] offlineMessageDataId = new byte[]
    {
        0x00, 0xff, 0xff, 0x00, 0xfe, 0xfe, 0xfe, 0xfe, 0xfd, 0xfd, 0xfd, 0xfd, 0x12, 0x34, 0x56, 0x78
    }; // = { 0x00, 0xff, 0xff, 0x00, 0xfe, 0xfe, 0xfe, 0xfe, 0xfd, 0xfd, 0xfd, 0xfd, 0x12, 0x34, 0x56, 0x78 };

    public short mtuSize;
    public byte  raknetProtocolVersion; // = null;

    public OpenConnectionRequest1()
    {
        Id = 0x05;
        IsMcpe = false;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(offlineMessageDataId);
        Write(raknetProtocolVersion);

        Write(new byte[mtuSize - _buffer.Position - UdpConfig.udpHeaderSize]);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        ReadBytes(offlineMessageDataId.Length);
        raknetProtocolVersion = ReadByte();

        mtuSize = (short)(_reader.Length + UdpConfig.udpHeaderSize);
        ReadBytes((int)(_reader.Length - _reader.Position));
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        raknetProtocolVersion = default;
    }
}