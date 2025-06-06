using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeCommandRequest : Packet{

		public string command; // = null;
		public uint commandType; // = null;
		public UUID unknownUuid; // = null;
		public string requestId; // = null;
		public bool isinternal; // = null;
		public int version; // = null;

		public McpeCommandRequest()
		{
			Id = 0x4d;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			Write(command);
			WriteUnsignedVarInt(commandType);
			Write(unknownUuid);
			Write(requestId);
			Write(isinternal);
			WriteSignedVarInt(version);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			command = ReadString();
			commandType = ReadUnsignedVarInt();
			unknownUuid = ReadUUID();
			requestId = ReadString();
			isinternal = ReadBool();
			version = ReadSignedVarInt();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			command=default(string);
			commandType=default(uint);
			unknownUuid=default(UUID);
			requestId=default(string);
			isinternal=default(bool);
			version=default(int);
		}

	}
}