using neo_raknet.Utils;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpeResourcePackClientResponse : Packet
{
    public enum ResponseStatus
    {
        Refused = 1,
        SendPacks = 2,
        HaveAllPacks = 3,
        Completed = 4
    }

    public ResourcePackIds resourcepackids; // = null;

    public byte responseStatus; // = null;

    public McpeResourcePackClientResponse()
    {
        Id = 0x08;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(responseStatus);
        Write(resourcepackids);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        responseStatus = ReadByte();
        resourcepackids = ReadResourcePackIds();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        responseStatus = default;
        resourcepackids = default;
    }
}