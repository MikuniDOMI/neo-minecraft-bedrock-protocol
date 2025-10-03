namespace neo_protocol.Packet.MinecraftPacket;

public class McpeSetTime : Packet
{
    public int time; // = null;

    public McpeSetTime()
    {
        Id = 0x0a;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteSignedVarInt(time);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        time = ReadSignedVarInt();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        time = default;
    }
}