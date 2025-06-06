using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeClientboundMapItemData : Packet{

		public MapInfo mapinfo; // = null;

		public McpeClientboundMapItemData()
		{
			Id = 0x43;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			Write(mapinfo);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			mapinfo = ReadMapInfo();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			mapinfo=default(MapInfo);
		}

	}
}