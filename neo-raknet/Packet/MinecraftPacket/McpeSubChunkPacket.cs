using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeSubChunkPacket : Packet{

		public bool cacheEnabled; // = null;
		public int dimension; // = null;
		public BlockCoordinates subchunkCoordinates; // = null;

		public McpeSubChunkPacket()
		{
			Id = 0xae;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			Write(cacheEnabled);
			WriteVarInt(dimension);
			Write(subchunkCoordinates);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			cacheEnabled = ReadBool();
			dimension = ReadVarInt();
			subchunkCoordinates = ReadBlockCoordinates();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			cacheEnabled=default(bool);
			dimension=default(int);
			subchunkCoordinates=default(BlockCoordinates);
		}

	}
}