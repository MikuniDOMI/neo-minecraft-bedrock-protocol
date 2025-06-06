using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo_raknet.Packet.MinecraftStruct
{
    public class UpdateSubChunkBlocksPacketEntry
    {
        public BlockCoordinates Coordinates { get; set; }
        public uint BlockRuntimeId { get; set; }
        public uint Flags { get; set; }
        public long SyncedUpdatedEntityUniqueId { get; set; }
        public uint SyncedUpdateType { get; set; }
    }
}
