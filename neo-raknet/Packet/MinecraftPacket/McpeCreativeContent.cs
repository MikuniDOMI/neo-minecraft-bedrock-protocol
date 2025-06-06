using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeCreativeContent : Packet{

		public List<creativeGroup> groups; // = null;
		public List<CreativeItemEntry> input; // = null;

		public McpeCreativeContent()
		{
			Id = 0x91;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			Write(groups);
			Write(input);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			groups = ReadCreativeGroups();
			input = ReadCreativeItemStacks();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			groups=default(List<creativeGroup>);
			input=default(List<CreativeItemEntry>);
		}

	}
}