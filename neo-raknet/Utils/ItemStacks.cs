﻿using neo_raknet.Packet.MinecraftStruct.Item;

namespace neo_raknet.Utils
{
	public class ItemStacks : List<Item>
	{
	}

	public class CreativeItemStacks : ItemStacks
	{

	}

	/// <summary>
	/// An item stack without unique identifiers
	/// </summary>
	public class GlobalItemStacks : List<Item>
	{
	}
}
