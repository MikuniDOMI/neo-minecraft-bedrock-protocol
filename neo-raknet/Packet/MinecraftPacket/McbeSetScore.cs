using neo_protocol.Packet.MinecraftStruct.Entity;

namespace neo_protocol.Packet.MinecraftPacket;

public class McpeSetScore : Packet
{
    public enum ChangeTypes
    {
        Player = 1,
        Entity = 2,
        FakePlayer = 3
    }

    public enum Types
    {
        Change = 0,
        Remove = 1
    }

    public ScoreEntries entries; // = null;

    public McpeSetScore()
    {
        Id = 0x6c;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(entries);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        entries = ReadScoreEntries();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        entries = default;
    }
}