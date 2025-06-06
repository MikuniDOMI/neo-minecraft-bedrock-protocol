using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeEmoteList : Packet{

		public long runtimeEntityId; // = null;
		public EmoteIds emoteIds; // = null;

		public McpeEmoteList()
		{
			Id = 0x8a;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			WriteUnsignedVarLong(runtimeEntityId);
			Write(emoteIds);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			runtimeEntityId = ReadUnsignedVarLong();
			emoteIds = ReadEmoteId();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			runtimeEntityId = default(long);
			emoteIds = default(EmoteIds);

		}

	}
}