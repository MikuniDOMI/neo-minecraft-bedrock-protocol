using neo_protocol.Packet.MinecraftStruct.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace neo_protocol.Packet.MinecraftStruct.Item
{
	public class ItemBlock : Item
	{

		[JsonIgnore] public Block.Block Block { get; protected set; }

		protected ItemBlock(string name, short id, short metadata = 0) : base(name, id, metadata)
		{
			//TODO: Problematic block
			Block = null;
		}

		public ItemBlock([NotNull] Block.Block block, short metadata = 0) : base(block.Name, (short)(block.Id > 255 ? 255 - block.Id : block.Id), metadata)
		{
			Block = block ?? throw new ArgumentNullException(nameof(block));

			FuelEfficiency = Block.FuelEfficiency;
		}
		
	}
}
