using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeSyncEntityProperty : Packet{
		public Nbt propertyData; // = null;

		public McpeSyncEntityProperty()
		{
			Id = 0xa5;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			Write(propertyData);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			propertyData = ReadNbt();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			propertyData = default(Nbt);
		}

	}
}