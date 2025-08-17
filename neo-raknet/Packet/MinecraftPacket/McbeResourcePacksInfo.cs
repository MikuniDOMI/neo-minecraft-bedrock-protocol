using neo_raknet.Utils;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpeResourcePacksInfo : Packet
{
    public bool ForceDisableVibrantVisuals;
    public bool hasAddons; // = null;
    public bool hasScripts; // = null;
    public bool mustAccept; // = null;
    public UUID templateUUID; // = null;
    public string templateVersion; // = null;
    public TexturePackInfos texturepacks; // = null;

    public McpeResourcePacksInfo()
    {
        Id = 0x06;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(mustAccept);
        Write(hasAddons);
        Write(hasScripts);
        Write(ForceDisableVibrantVisuals);
        Write(templateUUID);
        Write(templateVersion);
        Write(texturepacks);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        mustAccept = ReadBool();
        hasAddons = ReadBool();
        hasScripts = ReadBool();
        ForceDisableVibrantVisuals = ReadBool();
        templateUUID = ReadUUID();
        templateVersion = ReadString();
        texturepacks = ReadTexturePackInfos();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        mustAccept = default;
        hasAddons = default;
        hasScripts = default;
        ForceDisableVibrantVisuals = default;
        templateUUID = default;
        templateVersion = default;
        texturepacks = default;
    }
}