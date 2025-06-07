namespace neo_raknet.Packet.MinecraftPacket;

public class McpeSetDifficulty : Packet
{
    public uint difficulty; // = null;

    public McpeSetDifficulty()
    {
        Id = 0x3c;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteUnsignedVarInt(difficulty);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        difficulty = ReadUnsignedVarInt();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        difficulty = default;
    }
}