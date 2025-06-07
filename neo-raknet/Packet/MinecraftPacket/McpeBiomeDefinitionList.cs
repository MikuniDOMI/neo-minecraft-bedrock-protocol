using neo_raknet.Utils;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpeBiomeDefinitionList : Packet
{
    public Biome[] biomes; // = null;

    public McpeBiomeDefinitionList()
    {
        Id = 0x7a;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(biomes);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        biomes = ReadBiomes();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        biomes = default;
    }
}