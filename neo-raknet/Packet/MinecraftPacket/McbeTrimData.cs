using neo_raknet.Packet.MinecraftStruct;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpeTrimData : Packet
{
    public List<TrimMaterial> Materials;

    public List<TrimPattern> Patterns;

    public McpeTrimData()
    {
        Id = 0x12e;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteUnsignedVarInt((uint)Patterns.Count);
        foreach (var pattern in Patterns)
        {
            Write(pattern.ItemId);
            Write(pattern.PatternId);
        }

        WriteUnsignedVarInt((uint)Materials.Count);
        foreach (var material in Materials)
        {
            Write(material.MaterialId);
            Write(material.Color);
            Write(material.ItemId);
        }
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();

        Patterns = new List<TrimPattern>();
        var countPattern = (int)ReadUnsignedVarInt();
        for (var i = 0; i < countPattern; i++)
        {
            var pattern = new TrimPattern();
            pattern.ItemId = ReadString();
            pattern.PatternId = ReadString();
            Patterns.Add(pattern);
        }

        Materials = new List<TrimMaterial>();
        var countMaterial = (int)ReadUnsignedVarInt();
        for (var i = 0; i < countMaterial; i++)
        {
            var material = new TrimMaterial();
            material.MaterialId = ReadString();
            material.Color = ReadString();
            material.ItemId = ReadString();
            Materials.Add(material);
        }
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();
    }
}