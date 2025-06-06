using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo_raknet.Utils
{
	public class pixelList
	{
		public List<pixelsData> mapData = new List<pixelsData>();
	}
	public class pixelsData
	{
		public uint  pixel;
		public short index;
	}
}
