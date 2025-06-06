using neo_raknet.Packet; 
 namespace neo_raknet.Packet.MinecraftPacket
{
public partial class McpeScriptCustomEvent : Packet{

		public string eventName; // = null;
		public string eventData; // = null;

		public McpeScriptCustomEvent()
		{
			Id = 0x75;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			 

			Write(eventName);
			Write(eventData);

			 
		}

		 
		 

		protected override void DecodePacket()
		{
			base.DecodePacket();

			   

			eventName = ReadString();
			eventData = ReadString();

			    
		}

		  
		   

		protected override void ResetPacket()
		{
			base.ResetPacket();

			eventName=default(string);
			eventData=default(string);
		}

	}
}