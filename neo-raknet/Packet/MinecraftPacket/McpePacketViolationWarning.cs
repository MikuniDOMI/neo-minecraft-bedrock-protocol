using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpePacketViolationWarning : Packet{

		public int violationType; // = null;
		public int severity; // = null;
		public int packetId; // = null;
		public string reason; // = null;

		public McpePacketViolationWarning()
		{
			Id = 0x9c;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			WriteSignedVarInt(violationType);
			WriteSignedVarInt(severity);
			WriteSignedVarInt(packetId);
			Write(reason);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			violationType = ReadSignedVarInt();
			severity = ReadSignedVarInt();
			packetId = ReadSignedVarInt();
			reason = ReadString();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			violationType=default(int);
			severity=default(int);
			packetId=default(int);
			reason=default(string);
		}

	}
}