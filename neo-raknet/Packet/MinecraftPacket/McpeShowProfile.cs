using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeShowProfile : Packet{

		public string xuid; // = null;

		public McpeShowProfile()
		{
			Id = 0x68;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			Write(xuid);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			xuid = ReadString();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			xuid=default(string);
		}

	}
}