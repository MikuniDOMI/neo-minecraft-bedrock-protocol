using neo_raknet.Packet.MinecraftStruct;
using neo_raknet.Packet.MinecraftStruct.Metadata;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpeSetEntityData : Packet
{
    public MetadataDictionary metadata; // = null;

    public long runtimeEntityId; // = null;
    public PropertySyncData syncdata; // = null;
    public long tick; // = null;

    public McpeSetEntityData()
    {
        Id = 0x27;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteUnsignedVarLong(runtimeEntityId);
        Write(metadata);
        Write(syncdata);
        WriteUnsignedVarLong(tick);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        runtimeEntityId = ReadUnsignedVarLong();
        metadata = ReadMetadataDictionary();
        syncdata = ReadPropertySyncData();
        tick = ReadUnsignedVarLong();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        runtimeEntityId = default;
        metadata = default;
        syncdata = default;
        tick = default;
    }
}