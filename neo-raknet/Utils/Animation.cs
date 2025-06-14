﻿namespace neo_raknet.Utils
{
	public class Animation : ICloneable
	{
		public byte[] Image { get; set; }
		public int ImageWidth { get; set; }
		public int ImageHeight { get; set; }
		public float FrameCount { get; set; }
		public int Expression { get; set; }
		public int Type { get; set; } // description above

		// doesn't have reference-type fields so use MemberwiseClone
		public object Clone()
		{
			var clone = (Animation)MemberwiseClone();
			clone.Image = Image?.Clone() as byte[];
			return clone;
		}
	}
}
