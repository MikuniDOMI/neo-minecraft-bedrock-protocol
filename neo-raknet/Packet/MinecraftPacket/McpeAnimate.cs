using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeAnimate : Packet{

		public int actionId; // = null;
		public long runtimeEntityId; // = null;

		public McpeAnimate()
		{
			Id = 0x2c;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			WriteSignedVarInt(actionId);
			WriteUnsignedVarLong(runtimeEntityId);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			actionId = ReadSignedVarInt();
			runtimeEntityId = ReadUnsignedVarLong();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			actionId=default(int);
			runtimeEntityId=default(long);
		}

	}
}