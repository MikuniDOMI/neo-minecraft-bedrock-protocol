using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeNetworkSettings : Packet{
		public enum Compression
		{
			Nothing = 0,
			Everything = 1,
		}

		public short compressionThreshold; // = null;
		public short compressionAlgorithm; // = null;
		public bool clientThrottleEnabled; // = null;
		public byte clientThrottleThreshold; // = null;
		public float clientThrottleScalar; // = null;

		public McpeNetworkSettings()
		{
			Id = 0x8f;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			Write(compressionThreshold);
			Write(compressionAlgorithm);
			Write(clientThrottleEnabled);
			Write(clientThrottleThreshold);
			Write(clientThrottleScalar);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			compressionThreshold = ReadShort();
			compressionAlgorithm = ReadShort();
			clientThrottleEnabled = ReadBool();
			clientThrottleThreshold = ReadByte();
			clientThrottleScalar = ReadFloat();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			compressionThreshold=default(short);
			compressionAlgorithm=default(short);
			clientThrottleEnabled=default(bool);
			clientThrottleThreshold=default(byte);
			clientThrottleScalar=default(float);
		}

	}
}