namespace neo_protocol.Packet.MinecraftPacket;

public class McpeSetPlayerGameType : Packet
{
    public int gamemode; // = null;

    public McpeSetPlayerGameType()
    {
        Id = 0x3e;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteSignedVarInt(gamemode);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        gamemode = ReadSignedVarInt();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        gamemode = default;
    }
}