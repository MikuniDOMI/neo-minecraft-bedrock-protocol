using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo_raknet.Packet.MinecraftStruct.Block
{
	public enum BlockFace
	{
		Down  = 0,
		Up    = 1,
		North = 2, // -> North
		South = 3, // -> South
		West  = 4, // ->  West
		East  = 5, // -> East
		None  = 255
	}

	public enum BlockAxis
	{
		X,
		Y,
		Z
	}
}
