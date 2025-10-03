using neo_protocol.Packet.MinecraftStruct.Item;
using neo_protocol.Utils;

namespace neo_protocol.Packet.MinecraftPacket;

public class McpeInventoryContent : Packet
{
    public FullContainerName ContainerName = new();
    public ItemStacks input; // = null;

    public uint inventoryId; // = null;
    public Item storageItem; // = null;

    public McpeInventoryContent()
    {
        Id = 0x31;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteUnsignedVarInt(inventoryId);
        Write(input);
        Write(ContainerName);
        Write(storageItem);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        inventoryId = ReadUnsignedVarInt();
        input = ReadItemStacks();
        ContainerName = readFullContainerName();
        storageItem = ReadItem();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        inventoryId = default;
        input = default;
        storageItem = default;
        ContainerName = default;
    }
}