namespace neo_raknet.Packet.MinecraftPacket;

public class McpeHurtArmor : Packet
{
    public long armorSlotFlags; // = null;

    public int cause; // = null;
    public int health; // = null;

    public McpeHurtArmor()
    {
        Id = 0x26;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteVarInt(cause);
        WriteSignedVarInt(health);
        WriteUnsignedVarLong(armorSlotFlags);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        cause = ReadVarInt();
        health = ReadSignedVarInt();
        armorSlotFlags = ReadUnsignedVarLong();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        cause = default;
        health = default;
        armorSlotFlags = default;
    }
}