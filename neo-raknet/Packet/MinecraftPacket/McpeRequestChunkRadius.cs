using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeRequestChunkRadius : Packet{

		public int chunkRadius; // = null;
		public byte maxRadius; // = null;

		public McpeRequestChunkRadius()
		{
			Id = 0x45;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			WriteSignedVarInt(chunkRadius);
			Write(maxRadius);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			chunkRadius = ReadSignedVarInt();
			maxRadius = ReadByte();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			chunkRadius=default(int);
			maxRadius=default(byte);
		}

	}
}