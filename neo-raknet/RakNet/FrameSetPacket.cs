using neo_raknet.Utils;

namespace neo_raknet.RakNet;

public enum Reliability
{
    Undefined = -1,
    Unreliable = 0,
    UnreliableSequenced = 1,
    Reliable = 2,
    ReliableOrdered = 3,
    ReliableSequenced = 4,
    UnreliableWithAckReceipt = 5,
    ReliableWithAckReceipt = 6,
    ReliableOrderedWithAckReceipt = 7
}

public class FrameSetPacket : Packet.Packet
{
    public byte[] bytes_;
    public short Compound_ID;
    public int Compound_size;
    public byte Flags;
    public int index_Fragment;
    public ushort Length;
    public byte Order_channel;
    public Int24 Ordered_frame_index;
    public Int24 Reliable_frame_index;

    public Int24 Sequence_number;
    public Int24 Sequenced_frame_index;

    public FrameSetPacket()
    {
        Id = 0x80;
        IsMcpe = false;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();
        if ((Flags & 16) != 0 && index_Fragment != 0) Id |= 0x4;
        Write(Sequence_number);
        Write(Flags);
        Write((ushort)(Length * 8), true);
        if (IsReliable()) Write(Reliable_frame_index);

        if (IsSequenced()) Write(Sequenced_frame_index);

        if (IsOrdered())
        {
            Write(Ordered_frame_index);
            Write(Order_channel);
        }

        if ((Flags & 16) != 0)
        {
            Write(Compound_size, true);
            Write(Compound_ID, true);
            Write(index_Fragment, true);
        }

        Write(bytes_);
    }

    protected override void DecodePacket()
    {
        base.DecodePacket();
        Sequence_number = ReadLittle();
        Flags = ReadByte();
        Length = (ushort)(ReadUshort(true) / 8);
        if (IsReliable()) Reliable_frame_index = ReadLittle();

        if (IsSequenced()) Sequenced_frame_index = ReadLittle();

        if (IsOrdered())
        {
            Order_channel = ReadByte();
            Ordered_frame_index = ReadLittle();
        }

        if ((Flags & 16) != 0)
        {
            Compound_size = ReadIntBe();
            Compound_ID = ReadShortBe();
            index_Fragment = ReadIntBe();
        }

        bytes_ = ReadBytes(Length);
    }

    public bool IsFragment()
    {
        return (Flags & 16) != 0;
    }

    public bool IsReliable()
    {
        var r = (Reliability)((Flags & 224) >> 5);
        return r == Reliability.Reliable || r == Reliability.ReliableOrdered || r == Reliability.ReliableSequenced;
    }

    public bool IsOrdered()
    {
        var r = (Reliability)((Flags & 224) >> 5);
        return r == Reliability.UnreliableSequenced || r == Reliability.ReliableOrdered ||
               r == Reliability.ReliableSequenced;
    }

    public bool IsSequenced()
    {
        var r = (Reliability)((Flags & 224) >> 5);
        return r == Reliability.UnreliableSequenced || r == Reliability.ReliableSequenced;
    }

    public Reliability GetReliability()
    {
        return (Reliability)((Flags & 224) >> 5);
    }

    protected override void ResetPacket()
    {
        base.ResetPacket();
    }
}