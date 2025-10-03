using System.Linq.Expressions;
using neo_protocol.Packet.MinecraftStruct.Entity;

namespace neo_protocol.Packet.MinecraftStruct.Item
{
	public interface ICustomItemFactory
	{
		Item GetItem(short id, short metadata, int count);
	}

	public interface ICustomBlockItemFactory
	{
		ItemBlock GetBlockItem(Block.Block block, short metadata, int count);
	}

	public class ItemFactory
	{

		public static ICustomItemFactory CustomItemFactory { get; set; }
		public static ICustomBlockItemFactory CustomBlockItemFactory { get; set; }

		public static Dictionary<string, short> NameToId { get; private set; }

		static ItemFactory()
		{
			NameToId = BuildNameToId();
		}

		private static Dictionary<string, short> BuildNameToId()
		{
			//TODO: Refactor to use the Item.Name in hashed set instead.

			var nameToId = new Dictionary<string, short>();

			for (short idx = -600; idx < 800; idx++)
			{
				Item item = GetItem(idx);
				string name = item.GetType().Name.ToLowerInvariant();

				if (name.Equals("item"))
				{
					continue;
				}

				if (name.Equals("itemblock"))
				{
					ItemBlock itemBlock = item as ItemBlock;

					if (itemBlock != null)
					{
						Block.Block block = itemBlock.Block;
						name = block?.GetType().Name.ToLowerInvariant();

						if (name == null || name.Equals("block"))
						{
							continue;
						}
					}
				}
				else
				{
					name = name.Substring(4);
				}

				try
				{
					nameToId.Remove(name); // This is in case a block was added that have item that should be used.
					nameToId.Add(name, idx);

					if (!string.IsNullOrWhiteSpace(item?.Name))
					{
						if (!nameToId.TryAdd(item.Name, idx))
						{

						}
					}
				}
				catch (Exception e)
				{
					throw new Exception($"Tried to add duplicate item for {name} {idx}");
				}
			}

			return nameToId;
		}

		public static short GetItemIdByName(string itemName)
		{
			return (short)0;
		}

		public static Item GetItem(string name, short metadata = 0, int count = 1)
		{
			return GetItem(GetItemIdByName(name), metadata, count);
		}

		public static Item GetItem(short id, short metadata = 0, int count = 1)
		{
			return new ItemAir();
		}
	}
}