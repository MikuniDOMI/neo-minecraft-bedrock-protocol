using neo_raknet.Packet.MinecraftStruct;
using neo_raknet.Packet.MinecraftStruct.Entity;
using neo_raknet.Packet.MinecraftStruct.Metadata;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpeAddEntity : Packet
{
    public EntityAttributes attributes; // = null;
    public float            bodyYaw; // = null;

    public long               entityIdSelf; // = null;
    public string             entityType; // = null;
    public float              headYaw; // = null;
    public EntityLinks        links; // = null;
    public MetadataDictionary metadata; // = null;
    public float              pitch; // = null;
    public long               runtimeEntityId; // = null;
    public float              speedX; // = null;
    public float              speedY; // = null;
    public float              speedZ; // = null;
    public PropertySyncData   syncdata; // = null;
    public float              x; // = null;
    public float              y; // = null;
    public float              yaw; // = null;
    public float              z; // = null;

    public McpeAddEntity()
    {
        Id = 0x0d;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteSignedVarLong(entityIdSelf);
        WriteUnsignedVarLong(runtimeEntityId);
        Write(entityType);
        Write(x);
        Write(y);
        Write(z);
        Write(speedX);
        Write(speedY);
        Write(speedZ);
        Write(pitch);
        Write(yaw);
        Write(headYaw);
        Write(bodyYaw);
        Write(attributes);
        Write(metadata);
        Write(syncdata);
        Write(links);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        entityIdSelf = ReadSignedVarLong();
        runtimeEntityId = ReadUnsignedVarLong();
        entityType = ReadString();
        x = ReadFloat();
        y = ReadFloat();
        z = ReadFloat();
        speedX = ReadFloat();
        speedY = ReadFloat();
        speedZ = ReadFloat();
        pitch = ReadFloat();
        yaw = ReadFloat();
        headYaw = ReadFloat();
        bodyYaw = ReadFloat();
        attributes = ReadEntityAttributes();
        metadata = ReadMetadataDictionary();
        syncdata = ReadPropertySyncData();
        links = ReadEntityLinks();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        entityIdSelf = default;
        runtimeEntityId = default;
        entityType = default;
        x = default;
        y = default;
        z = default;
        speedX = default;
        speedY = default;
        speedZ = default;
        pitch = default;
        yaw = default;
        headYaw = default;
        bodyYaw = default;
        attributes = default(EntityAttributes);
        metadata = default(MetadataDictionary);
        syncdata = default(PropertySyncData);
        links = default(EntityLinks);
    }
}