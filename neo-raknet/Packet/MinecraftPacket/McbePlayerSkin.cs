using neo_raknet.Utils;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpePlayerSkin : Packet
{
    public bool isVerified; // = null;
    public string oldSkinName; // = null;
    public Skin skin; // = null;
    public string skinName; // = null;

    public UUID uuid; // = null;

    public McpePlayerSkin()
    {
        Id = 0x5d;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(uuid);
        Write(skin);
        Write(skinName);
        Write(oldSkinName);
        Write(isVerified);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        uuid = ReadUUID();
        skin = ReadSkin();
        skinName = ReadString();
        oldSkinName = ReadString();
        isVerified = ReadBool();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        uuid = default;
        skin = default;
        skinName = default;
        oldSkinName = default;
        isVerified = default;
    }
}