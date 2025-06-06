using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeUpdateSubChunkBlocksPacket : Packet{

		public BlockCoordinates subchunkCoordinates; // = null;
		public UpdateSubChunkBlocksPacketEntry[] layerZeroUpdates; // = null;
		public UpdateSubChunkBlocksPacketEntry[] layerOneUpdates; // = null;

		public McpeUpdateSubChunkBlocksPacket()
		{
			Id = 0xac;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			Write(subchunkCoordinates);
			Write(layerZeroUpdates);
			Write(layerOneUpdates);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			subchunkCoordinates = ReadBlockCoordinates();
			layerZeroUpdates = ReadUpdateSubChunkBlocksPacketEntrys();
			layerOneUpdates = ReadUpdateSubChunkBlocksPacketEntrys();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			subchunkCoordinates=default(BlockCoordinates);
			layerZeroUpdates=default(UpdateSubChunkBlocksPacketEntry[]);
			layerOneUpdates=default(UpdateSubChunkBlocksPacketEntry[]);
		}

	}
}