using neo_protocol.Protocol.Biomes;

namespace neo_protocol.Packet.MinecraftPacket;

public class McpeBiomeDefinitionList : Packet
{
    public string[] biomeNames = new string[0];
    public BiomeDefinition[] biomes; // = null;

    public McpeBiomeDefinitionList()
    {
        Id = 0x7a;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();
        WriteVarInt(biomes.Length);
        foreach (var biome in biomes) WriteBiomeDefinition(biome);
        WriteUnsignedVarInt((uint)biomeNames.Length);
        foreach (var biomeName in biomeNames) Write(biomeName);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();

        var biomeCount = ReadVarInt();
        biomes = new BiomeDefinition[biomeCount];
        for (var i = 0; i < biomeCount; i++) biomes[i] = ReadBiomeDefinition();
        var biomeNameCount = ReadUnsignedVarInt();
        biomeNames = new string[biomeNameCount];
        for (var i = 0; i < biomeNameCount; i++) biomeNames[i] = ReadString();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        biomes = default;
    }
}