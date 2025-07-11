#region LICENSE

// The contents of this file are subject to the Common Public Attribution
// License Version 1.0. (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
// https://github.com/NiclasOlofsson/MiNET/blob/master/LICENSE. 
// The License is based on the Mozilla Public License Version 1.1, but Sections 14 
// and 15 have been added to cover use of software over a computer network and 
// provide for limited attribution for the Original Developer. In addition, Exhibit A has 
// been modified to be consistent with Exhibit B.
// 
// Software distributed under the License is distributed on an "AS IS" basis,
// WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for
// the specific language governing rights and limitations under the License.
// 
// The Original Code is MiNET.
// 
// The Original Developer is the Initial Developer.  The Initial Developer of
// the Original Code is Niclas Olofsson.
// 
// All portions of the code written by Niclas Olofsson are Copyright (c) 2014-2018 Niclas Olofsson. 
// All Rights Reserved.

#endregion

namespace neo_raknet.Packet.MinecraftStruct.Metadata
{
	public class MetadataShort : MetadataEntry
	{
		public override byte Identifier
		{
			get { return 1; }
		}

		public override string FriendlyName
		{
			get { return "short"; }
		}

		public short Value { get; set; }

		public static implicit operator MetadataShort(short value)
		{
			return new MetadataShort(value);
		}

		public MetadataShort()
		{
		}

		public MetadataShort(short value)
		{
			Value = value;
		}

		public override void FromStream(BinaryReader reader)
		{
			Value = reader.ReadInt16();
		}

		public override void WriteTo(BinaryWriter stream)
		{
			stream.Write(Value);
		}

		public override string ToString()
		{
			return string.Format("({0}) {2}", FriendlyName, Identifier, Value);
		}
	}
}