using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeOpenSign : Packet{

		public BlockCoordinates coordinates; // = null;
		public bool front; // = null;

		public McpeOpenSign()
		{
			Id = 0x12f;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			Write(coordinates);
			Write(front);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			coordinates = ReadBlockCoordinates();
			front = ReadBool();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			coordinates=default(BlockCoordinates);
			front=default(bool);
		}

	}
}