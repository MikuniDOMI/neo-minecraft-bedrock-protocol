using neo_raknet.Packet.MinecraftStruct.Item;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpeMobArmorEquipment : Packet
{
    public Item body; // = null;
    public Item boots; // = null;
    public Item chestplate; // = null;
    public Item helmet; // = null;
    public Item leggings; // = null;

    public long runtimeEntityId; // = null;

    public McpeMobArmorEquipment()
    {
        Id = 0x20;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteUnsignedVarLong(runtimeEntityId);
        Write(helmet);
        Write(chestplate);
        Write(leggings);
        Write(boots);
        Write(body);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        runtimeEntityId = ReadUnsignedVarLong();
        helmet = ReadItem();
        chestplate = ReadItem();
        leggings = ReadItem();
        boots = ReadItem();
        body = ReadItem();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        runtimeEntityId = default;
        helmet = default;
        chestplate = default;
        leggings = default;
        boots = default;
        body = default;
    }
}