namespace neo_raknet.Packet.MinecraftStruct
{
	public class DimensionData
	{
		public int MaxHeight { get; set; }
		public int MinHeight { get; set; }
		public int Generator { get; set; }
	}

	public class DimensionDefinitions : Dictionary<string, DimensionData>
	{

	}
}
