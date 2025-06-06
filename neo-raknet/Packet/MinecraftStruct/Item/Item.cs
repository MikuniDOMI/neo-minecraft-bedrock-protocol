using fNbt;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo_raknet.Packet.MinecraftStruct.Item
{
	public class Item : ICloneable
	{
		public int UniqueId { get; set; } = Environment.TickCount;
		public string Name { get; protected set; } = string.Empty;
		public short Id { get; protected set; }
		public int NetworkId { get; set; } = -1;
		public int RuntimeId { get; set; }
		public short Metadata { get; set; }
		public byte Count { get; set; }
		public virtual NbtCompound ExtraData { get; set; }

		[JsonIgnore] public ItemMaterial ItemMaterial { get; set; } = ItemMaterial.None;

		[JsonIgnore] public ItemType ItemType { get; set; } = ItemType.Item;

		[JsonIgnore] public int MaxStackSize { get; set; } = 64;

		[JsonIgnore] public bool IsStackable => MaxStackSize > 1;

		[JsonIgnore] public int Durability { get; set; } = 0;
		[JsonIgnore] public int Damage { get; set; } = 0;

		[JsonIgnore] public int FuelEfficiency { get; set; }

		protected internal Item(string name, short id, short metadata = 0, int count = 1)
		{
			Name = name;
			Id = id;
			Metadata = metadata;
			Count = (byte)count;
		}
		protected internal Item(short id, short metadata = 0, int count = 1) : this(String.Empty, id, metadata, count)
		{
		}
		public override int GetHashCode()
		{
			unchecked
			{
				return Id * 397 ^ Metadata.GetHashCode();
			}
		}

		public object Clone()
		{
			return MemberwiseClone();
		}

		public override string ToString()
		{
			return $"{GetType().Name}(Id={Id}, Meta={Metadata}, UniqueId={UniqueId}) Count={Count}, NBT={ExtraData}";
		}
		
	}
	public enum ItemMaterial
	{
		//Armor Only
		Leather = -2,
		Chain = -1,

		None = 0,
		Wood = 1,
		Stone = 2,
		Gold = 3,
		Iron = 4,
		Diamond = 5,
		Netherite = 6
	}

	public enum ItemType
	{
		//Tools
		Sword,
		Bow,
		Shovel,
		PickAxe,
		Axe,
		Item,
		Hoe,
		Sheers,
		FlintAndSteel,
		Elytra,
		Trident,
		CarrotOnAStick,
		FishingRod,
		Book,

		//Armor
		Helmet,
		Chestplate,
		Leggings,
		Boots
	}

	public enum ItemDamageReason
	{
		BlockBreak,
		BlockInteract,
		EntityAttack,
		EntityInteract,
		ItemUse,
	}
}
