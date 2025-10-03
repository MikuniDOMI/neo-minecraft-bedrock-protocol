using neo_protocol.Packet.MinecraftStruct.Block;

namespace neo_protocol.Packet.MinecraftPacket;

public class McpeAnvilDamage : Packet
{
    public BlockCoordinates coordinates; // = null;

    public byte damageAmount; // = null;

    public McpeAnvilDamage()
    {
        Id = 0x8D;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(damageAmount);
        Write(coordinates);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        damageAmount = ReadByte();
        coordinates = ReadBlockCoordinates();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        damageAmount = default;
        coordinates = default;
    }
}