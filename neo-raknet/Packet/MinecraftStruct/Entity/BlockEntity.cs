using fNbt;

namespace neo_raknet.Packet.MinecraftStruct.Entity;

public class BlockEntity
{
    public BlockEntity(string id)
    {
        Id = id;
    }

    public string Id { get; private set; }
    public BlockCoordinates Coordinates { get; set; }

    public bool UpdatesOnTick { get; set; }

    public virtual NbtCompound GetCompound()
    {
        return new NbtCompound();
    }

    public virtual void SetCompound(NbtCompound compound)
    {
    }

    public virtual void OnTick(Level level)
    {
    }


    public virtual List<Item.Item> GetDrops()
    {
        return new List<Item.Item>();
    }
}