using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeModalFormResponse : Packet{

		public uint formId; // = null;
		public string data = "";
		public byte cancelReason; // = null;

		public McpeModalFormResponse()
		{
			Id = 0x65;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			WriteUnsignedVarInt(formId);
			Write(data);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			formId = ReadUnsignedVarInt();
			if (ReadBool())
			{
				data = ReadString();
			}
			if (ReadBool())
			{
				cancelReason = ReadByte();
			}

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			formId=default(uint);
			data=default(string);
			cancelReason=default(byte);
		}

	}
}