using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpePermissionRequest : Packet{

		public long runtimeEntityId; // = null;
		public uint permission; // = null;
		public short flagss; // = null;

		public McpePermissionRequest()
		{
			Id = 0xb9;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			runtimeEntityId = ReadLong();
			permission = ReadUnsignedVarInt();
			flagss = ReadShort();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			runtimeEntityId = default(long);
			permission = default(int);
			flagss = default(short);

		}

	}
}