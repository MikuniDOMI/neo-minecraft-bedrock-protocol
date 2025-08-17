using neo_raknet.Packet.MinecraftStruct;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpePlayerEnchantOptions : Packet
{
    public EnchantOptions enchantOptions; // = null;

    public McpePlayerEnchantOptions()
    {
        Id = 0x92;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(enchantOptions);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        enchantOptions = ReadEnchantOptions();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        enchantOptions = default;
    }
}