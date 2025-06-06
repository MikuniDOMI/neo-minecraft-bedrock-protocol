using fNbt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo_raknet.Packet.MinecraftStruct.Entity
{
    public class BlockEntity
    {
        public string Id { get; private set; }
        public BlockCoordinates Coordinates { get; set; }

        public bool UpdatesOnTick { get; set; }

        public BlockEntity(string id)
        {
            Id = id;
        }

        public virtual NbtCompound GetCompound()
        {
            return new NbtCompound();
        }

        public virtual void SetCompound(NbtCompound compound)
        {
        }

        public virtual void OnTick(Level level)
        {
        }


        public virtual List<Item.Item> GetDrops()
        {
            return new List<Item.Item>();
        }
    }
}
