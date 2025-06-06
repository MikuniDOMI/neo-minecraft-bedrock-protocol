using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
