using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeUpdateBlockProperties : Packet{

		public Nbt namedtag; // = null;

		public McpeUpdateBlockProperties()
		{
			Id = 0x86;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			Write(namedtag);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			namedtag = ReadNbt();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			namedtag=default(Nbt);
		}

	}
}