using neo_raknet.Packet.MinecraftStruct.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
