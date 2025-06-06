using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeDimensionData : Packet{

		public DimensionDefinitions definitions; // = null;

		public McpeDimensionData()
		{
			Id = 0xb4;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			Write(definitions);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			definitions = ReadDimensionDefinitions();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			definitions=default(DimensionDefinitions);
		}

	}
}