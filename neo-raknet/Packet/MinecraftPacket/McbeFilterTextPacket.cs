using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo_raknet.Packet.MinecraftPacket
{
	public partial class McpeFilterTextPacket : Packet  //TODO DEPRECATED
	{

		public string text; // = null;
		public bool   fromServer; // = null;

		public McpeFilterTextPacket()
		{
			Id = 0xa3;
			IsMcpe = true;
		}

		protected override void EncodePacket()
		{
			base.EncodePacket();

			BeforeEncode();

			Write(text);
			Write(fromServer);

			AfterEncode();
		}

		partial void BeforeEncode();
		partial void AfterEncode();

		protected override void DecodePacket()
		{
			base.DecodePacket();

			BeforeDecode();

			text = ReadString();
			fromServer = ReadBool();

			AfterDecode();
		}

		partial void BeforeDecode();
		partial void AfterDecode();

		protected override void ResetPacket()
		{
			base.ResetPacket();

			text = default(string);
			fromServer = default(bool);
		}

	}
}
