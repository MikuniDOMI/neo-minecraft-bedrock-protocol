using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeMapInfoRequest : Packet{

		public long mapId; // = null;
		public pixelList pixellist; // = null;

		public McpeMapInfoRequest()
		{
			Id = 0x44;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			WriteSignedVarLong(mapId);
			WriteUnsignedVarInt(0);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			mapId = ReadSignedVarLong();
			pixellist = ReadPixelList();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			mapId=default(long);
			pixellist = default(pixelList);
		}

	}
}