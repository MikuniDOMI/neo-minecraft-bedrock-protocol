using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeVideoStreamConnect : Packet{

		public string serverUri; // = null;
		public float frameSendFrequency; // = null;
		public byte action; // = null;
		public int resolutionX; // = null;
		public int resolutionY; // = null;

		public McpeVideoStreamConnect()
		{
			Id = 0x7e;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			Write(serverUri);
			Write(frameSendFrequency);
			Write(action);
			Write(resolutionX);
			Write(resolutionY);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			serverUri = ReadString();
			frameSendFrequency = ReadFloat();
			action = ReadByte();
			resolutionX = ReadInt();
			resolutionY = ReadInt();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			serverUri=default(string);
			frameSendFrequency=default(float);
			action=default(byte);
			resolutionX=default(int);
			resolutionY=default(int);
		}

	}
}