using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeTransfer : Packet{

		public string serverAddress; // = null;
		public ushort port; // = null;
		public bool reload; // = null;

		public McpeTransfer()
		{
			Id = 0x55;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			Write(serverAddress);
			Write(port);
			Write(reload);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			serverAddress = ReadString();
			port = ReadUshort();
			reload = ReadBool();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			serverAddress=default(string);
			port=default(ushort);
			reload=default(bool);
		}

	}
}