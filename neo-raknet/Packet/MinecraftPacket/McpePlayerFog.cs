using neo_raknet.Packet.MinecraftStruct;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpePlayerFog : Packet
{
    public fogStack fogstack; // = null;

    public McpePlayerFog()
    {
        Id = 0xa0;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(fogstack);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        fogstack = Read();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        fogstack = default(fogStack);
    }
}