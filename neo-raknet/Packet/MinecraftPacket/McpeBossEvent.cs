using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeBossEvent : Packet{
		public enum Type
		{
			AddBoss = 0,
			AddPlayer = 1,
			RemoveBoss = 2,
			RemovePlayer = 3,
			UpdateProgress = 4,
			UpdateName = 5,
			UpdateOptions = 6,
			UpdateStyle = 7,
			Query = 8,
		}

		public long bossEntityId; // = null;
		public uint eventType; // = null;

		public McpeBossEvent()
		{
			Id = 0x4a;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			WriteSignedVarLong(bossEntityId);
			WriteUnsignedVarInt(eventType);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			bossEntityId = ReadSignedVarLong();
			eventType = ReadUnsignedVarInt();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			bossEntityId=default(long);
			eventType=default(uint);
		}

	}
}