using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeServerSettingsResponse : Packet{

		public long formId; // = null;
		public string data; // = null;

		public McpeServerSettingsResponse()
		{
			Id = 0x67;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			WriteUnsignedVarLong(formId);
			Write(data);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			formId = ReadUnsignedVarLong();
			data = ReadString();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			formId=default(long);
			data=default(string);
		}

	}
}