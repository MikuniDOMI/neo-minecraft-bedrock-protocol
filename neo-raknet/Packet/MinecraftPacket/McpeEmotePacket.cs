using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeEmotePacket : Packet{

		public long runtimeEntityId; // = null;
		public string xuid; // = null;
		public string platformId; // = null;
		public string emoteId; // = null;
		public byte flags; // = null;
		public uint tick; // = null;

		public McpeEmotePacket()
		{
			Id = 0x8a;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			WriteUnsignedVarLong(runtimeEntityId);
			Write(emoteId);
			WriteUnsignedVarInt(tick);
			Write(xuid);
			Write(platformId);
			Write(flags);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			runtimeEntityId = ReadUnsignedVarLong();
			emoteId = ReadString();
			tick = ReadUnsignedVarInt();
			xuid = ReadString();
			platformId = ReadString();
			flags = ReadByte();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			runtimeEntityId = default(long);
			xuid = default(string);
			platformId = default(string);
			emoteId = default(string);
			tick = default(uint);
			flags = default(byte);
		}

	}
}