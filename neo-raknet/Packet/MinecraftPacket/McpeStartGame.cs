using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeStartGame : Packet{


		public McpeStartGame()
		{
			Id = 0x0b;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 


			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   


			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

		}

	}
}