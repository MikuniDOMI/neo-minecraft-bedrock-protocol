using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo_raknet.Packet.MinecraftStruct
{
	public class fogStack
	{
		public List<string> fogList = new List<string>();

		public fogStack(params string[] efects)
		{
			fogList.AddRange(efects);
		}
	}
}
