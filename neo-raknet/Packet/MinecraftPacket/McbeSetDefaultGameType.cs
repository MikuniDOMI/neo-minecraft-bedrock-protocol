namespace neo_raknet.Packet.MinecraftPacket;

public class McpeSetDefaultGameType : Packet
{
    public int gamemode; // = null;

    public McpeSetDefaultGameType()
    {
        Id = 0x69;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteVarInt(gamemode);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        gamemode = ReadVarInt();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        gamemode = default;
    }
}