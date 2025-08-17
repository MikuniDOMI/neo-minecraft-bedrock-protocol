using neo_raknet.Utils;

namespace neo_raknet.Packet.MinecraftPacket;

public class FtlCreatePlayer : Packet
{
    public long clientId; // = null;
    public UUID clientuuid; // = null;
    public string serverAddress; // = null;
    public Skin skin; // = null;

    public string username; // = null;

    public FtlCreatePlayer()
    {
        Id = 0x01;
        IsMcpe = false;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(username);
        Write(clientuuid);
        Write(serverAddress);
        Write(clientId);
        Write(skin);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        username = ReadString();
        clientuuid = ReadUUID();
        serverAddress = ReadString();
        clientId = ReadLong();
        skin = ReadSkin();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        username = default;
        clientuuid = default;
        serverAddress = default;
        clientId = default;
        skin = default;
    }
}