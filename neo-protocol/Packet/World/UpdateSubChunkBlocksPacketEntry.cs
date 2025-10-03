using neo_protocol.Packet.MinecraftStruct.Block;

namespace neo_protocol.Packet.World
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
