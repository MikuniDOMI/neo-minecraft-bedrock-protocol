using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeWrapper : Packet{

		public ReadOnlyMemory<byte> payload; // = null;
		public McpeWrapper()
		{
			Id = 0xfe;
			IsMcpe = false;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			Write(payload);



		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			payload = ReadReadOnlyMemory(0, true);



		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();
			payload = default(ReadOnlyMemory<byte>);
		}

	}
}