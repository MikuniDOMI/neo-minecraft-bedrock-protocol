using neo_raknet.Packet.MinecraftStruct;
using neo_raknet.Utils;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpeResourcePackStack : Packet
{
    public ResourcePackIdVersions behaviorpackidversions; // = null;
    public Experiments            experiments; // = null;
    public bool                   experimentsPreviouslyToggled; // = null;
    public string                 gameVersion; // = null;
    public bool                   hasEditorPacks; // = null;

    public bool                   mustAccept; // = null;
    public ResourcePackIdVersions resourcepackidversions; // = null;

    public McpeResourcePackStack()
    {
        Id = 0x07;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(mustAccept);
        Write(behaviorpackidversions);
        Write(resourcepackidversions);
        Write(gameVersion);
        Write(experiments);
        Write(experimentsPreviouslyToggled);
        Write(hasEditorPacks);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        mustAccept = ReadBool();
        behaviorpackidversions = ReadResourcePackIdVersions();
        resourcepackidversions = ReadResourcePackIdVersions();
        gameVersion = ReadString();
        experiments = ReadExperiments();
        experimentsPreviouslyToggled = ReadBool();
        hasEditorPacks = ReadBool();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        mustAccept = default;
        behaviorpackidversions = default(ResourcePackIdVersions);
        resourcepackidversions = default(ResourcePackIdVersions);
        gameVersion = default;
        experiments = default(Experiments);
        experimentsPreviouslyToggled = default;
        hasEditorPacks = default;
    }
}