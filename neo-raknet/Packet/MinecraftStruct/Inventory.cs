﻿using fNbt;
using neo_raknet.Packet.MinecraftStruct.Entity;
using neo_raknet.Packet.MinecraftStruct.Item;
using neo_raknet.Utils;
using System.Collections.Concurrent;
namespace neo_raknet.Packet.MinecraftStruct
{
	public interface IInventory
	{
	}

	public class Inventory : IInventory
	{

		public event Action<Player, Inventory, byte, Item.Item> InventoryChange;

		public int Id { get; set; }
		public byte Type { get; set; }
		public ItemStacks Slots { get; set; }
		public short Size { get; set; }
		public BlockCoordinates Coordinates { get; set; }
		public BlockEntity BlockEntity { get; set; }
		public byte WindowsId { get; set; }

		public Inventory(int id, BlockEntity blockEntity, short inventorySize, NbtList slots)
		{
			Id = id;
			BlockEntity = blockEntity;
			Size = inventorySize;
			Coordinates = BlockEntity.Coordinates;

			Slots = new ItemStacks();
			for (byte i = 0; i < Size; i++)
			{
				Slots.Add(new ItemAir());
			}

			for (byte i = 0; i < slots.Count; i++)
			{
				var nbtItem = (NbtCompound)slots[i];

				Item.Item item = ItemFactory.GetItem(nbtItem["id"].ShortValue, nbtItem["Damage"].ShortValue, nbtItem["Count"].ByteValue);
				byte slotIdx = nbtItem["Slot"].ByteValue;
				Slots[slotIdx] = item;
			}
		}

		public void SetSlot(Player player, byte slot, Item.Item itemStack)
		{
			Slots[slot] = itemStack;

			NbtCompound compound = BlockEntity.GetCompound();
			compound["Items"] = GetSlots();

			OnInventoryChange(player, slot, itemStack);
		}

		public Item.Item GetSlot(byte slot)
		{
			return Slots[slot];
		}

		public void DecreaseSlot(byte slot)
		{
			var slotData = Slots[slot];
			if (slotData is ItemAir) return;

			slotData.Count--;

			if (slotData.Count <= 0)
			{
				slotData = new ItemAir();
			}

			SetSlot(null, slot, slotData);

			OnInventoryChange(null, slot, slotData);
		}

		public void IncreaseSlot(byte slot, short itemId, short metadata)
		{
			Item.Item slotData = Slots[slot];
			if (slotData is ItemAir)
			{
				slotData = ItemFactory.GetItem(itemId, metadata, 1);
			}
			else
			{
				slotData.Count++;
			}

			SetSlot(null, slot, slotData);

			OnInventoryChange(null, slot, slotData);
		}

		public bool IsOpen()
		{
			return InventoryChange != null;
		}


		private NbtList GetSlots()
		{
			NbtList slots = new NbtList("Items");
			for (byte i = 0; i < Size; i++)
			{
				var slot = Slots[i];
				slots.Add(new NbtCompound
				{
					new NbtByte("Count", slot.Count),
					new NbtByte("Slot", i),
					new NbtShort("id", slot.Id),
					new NbtShort("Damage", slot.Metadata),
				});
			}

			return slots;
		}

		protected virtual void OnInventoryChange(Player player, byte slot, Item.Item itemStack)
		{
			InventoryChange?.Invoke(player, this, slot, itemStack);
		}


		// Below is a workaround making it possible to send
		// updates to only peopele that is looking at this inventory.
		// Is should be converted to some sort of event based version.

		public ConcurrentBag<Player> Observers { get; } = new ConcurrentBag<Player>();

		public void AddObserver(Player player)
		{
			Observers.Add(player);
		}

		public void RemoveObserver(Player player)
		{
			// Need to arrange for this to work when players get disconnected
			// from crash. It will leak players for sure.
			Observers.TryTake(out player);
		}
	}
}
