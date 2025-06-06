using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeLevelChunk : Packet{

		public int chunkX; // = null;
		public int chunkZ; // = null;
		public int dimension; // = null;

		public McpeLevelChunk()
		{
			Id = 0x3a;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			WriteSignedVarInt(chunkX);
			WriteSignedVarInt(chunkZ);
			WriteSignedVarInt(0);  //dimension id. TODO if dimensions will ever be added back again....

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			chunkX = ReadSignedVarInt();
			chunkZ = ReadSignedVarInt();
			dimension = ReadSignedVarInt();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			chunkX=default(int);
			chunkZ=default(int);
			dimension=default(int);
		}

	}
}