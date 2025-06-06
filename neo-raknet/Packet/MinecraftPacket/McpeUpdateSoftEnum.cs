using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeUpdateSoftEnum : Packet{


		public McpeUpdateSoftEnum()
		{
			Id = 0x72;
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