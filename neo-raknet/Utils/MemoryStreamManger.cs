using Microsoft.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo_raknet.Utils
{
	public static class MemoryStreamManger
	{
		public static RecyclableMemoryStreamManager stream { get; set; } = new();
	}
}
