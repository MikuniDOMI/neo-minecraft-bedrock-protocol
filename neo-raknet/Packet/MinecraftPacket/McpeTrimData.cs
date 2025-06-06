using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeTrimData : Packet{


		public McpeTrimData()
		{
			Id = 0x12e;
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