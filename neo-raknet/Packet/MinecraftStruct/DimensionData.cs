namespace neo_protocol.Packet.MinecraftStruct
{
	public class DimensionData
	{
		public string Identifier { get; set; } = string.Empty; // Dimension identifier, e.g., "minecraft:overworld"
        public int MaxHeight { get; set; }
		public int MinHeight { get; set; }
		public int Generator { get; set; }
	}

	public class DimensionDefinitions : Dictionary<string, DimensionData>
	{

	}
}
