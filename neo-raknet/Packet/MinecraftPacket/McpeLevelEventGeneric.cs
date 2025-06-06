using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeLevelEventGeneric : Packet{

		public int eventId; // = null;
		public Nbt eventData; // = null;

		public McpeLevelEventGeneric()
		{
			Id = 0x7c;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			WriteSignedVarInt(eventId);
			Write(eventData);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			eventId = ReadSignedVarInt();
			//eventData = ReadNbt(); todo wrong
			for (byte i = 0; i < 60; i++) //shhhh
			{
				ReadByte();
			}

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			eventId = default(int);
			eventData = default(Nbt);
		}

	}
}