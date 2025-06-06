using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeModalFormRequest : Packet{

		public uint formId; // = null;
		public string formData; // = null;

		public McpeModalFormRequest()
		{
			Id = 0x64;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			WriteUnsignedVarInt(formId);
			Write(formData);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			formId = ReadUnsignedVarInt();
			formData = ReadString();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();


			formId = default(uint);
			formData = default(string);
		}

	}
}