using fNbt;


namespace neo_protocol.Packet.MinecraftStruct.Metadata

{
	public class MetadataNbt : MetadataEntry
	{
		public override byte Identifier
		{
			get { return 5; }
		}

		public override string FriendlyName
		{
			get { return "nbt"; }
		}

		public NbtCompound Value { get; set; }

		public MetadataNbt()
		{
		}

		public MetadataNbt(NbtCompound value)
		{
			Value = value;
		}

		public override void FromStream(BinaryReader reader)
		{
			Value = (NbtCompound)Packet.ReadNbt(reader.BaseStream).NbtFile.RootTag;
		}

		public override void WriteTo(BinaryWriter stream)
		{
			NbtCompound nbt = Value;

			byte[] bytes = Packet.GetNbtData(nbt);
			stream.Write((ushort)0xffff);
			stream.Write((byte)0x01);
			stream.Write(bytes);
		}
	}
}