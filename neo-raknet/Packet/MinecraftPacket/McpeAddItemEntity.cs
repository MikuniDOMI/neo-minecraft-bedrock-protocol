using neo_raknet.Packet.MinecraftStruct.Item;
using neo_raknet.Packet.MinecraftStruct.Metadata;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpeAddItemEntity : Packet
{
    public long               entityIdSelf; // = null;
    public bool               isFromFishing; // = null;
    public Item               item; // = null;
    public MetadataDictionary metadata; // = null;
    public long               runtimeEntityId; // = null;
    public float              speedX; // = null;
    public float              speedY; // = null;
    public float              speedZ; // = null;
    public float              x; // = null;
    public float              y; // = null;
    public float              z; // = null;

    public McpeAddItemEntity()
    {
        Id = 0x0f;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteSignedVarLong(entityIdSelf);
        WriteUnsignedVarLong(runtimeEntityId);
        Write(item);
        Write(x);
        Write(y);
        Write(z);
        Write(speedX);
        Write(speedY);
        Write(speedZ);
        Write(metadata);
        Write(isFromFishing);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        entityIdSelf = ReadSignedVarLong();
        runtimeEntityId = ReadUnsignedVarLong();
        item = ReadItem();
        x = ReadFloat();
        y = ReadFloat();
        z = ReadFloat();
        speedX = ReadFloat();
        speedY = ReadFloat();
        speedZ = ReadFloat();
        metadata = ReadMetadataDictionary();
        isFromFishing = ReadBool();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        entityIdSelf = default;
        runtimeEntityId = default;
        item = default(Item);
        x = default;
        y = default;
        z = default;
        speedX = default;
        speedY = default;
        speedZ = default;
        metadata = default(MetadataDictionary);
        isFromFishing = default;
    }
}