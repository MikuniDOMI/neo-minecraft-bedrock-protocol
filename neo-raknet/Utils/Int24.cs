﻿#region LICENSE

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

namespace neo_raknet.Utils
{
	public struct Int24 : IComparable // later , IConvertible
	{
		private int _value;

		public Int24(ReadOnlySpan<byte> value)
		{
			_value = ToInt24(value).IntValue();
		}

		public Int24(int value)
		{
			_value = value;
		}

		private static Int24 ToInt24(ReadOnlySpan<byte> value)
		{
			if (value.Length > 3) throw new ArgumentOutOfRangeException();
			return new Int24(value[0] | value[1] << 8 | value[2] << 16);
		}

		public byte[] GetBytes()
		{
			return FromInt(_value);
		}

		public int IntValue()
		{
			return _value;
		}

		public static byte[] FromInt(int value)
		{
			byte[] buffer = new byte[3];
			buffer[0] = (byte)value;
			buffer[1] = (byte)(value >> 8);
			buffer[2] = (byte)(value >> 16);
			return buffer;
		}

		public static byte[] FromInt24(Int24 value)
		{
			byte[] buffer = new byte[3];
			buffer[0] = (byte)value.IntValue();
			buffer[1] = (byte)(value.IntValue() >> 8);
			buffer[2] = (byte)(value.IntValue() >> 16);
			return buffer;
		}

#pragma warning disable CS8767 // 参数类型中引用类型的为 Null 性与隐式实现的成员不匹配(可能是由于为 Null 性特性)。
		public int CompareTo(object value)
#pragma warning restore CS8767 // 参数类型中引用类型的为 Null 性与隐式实现的成员不匹配(可能是由于为 Null 性特性)。
		{
			return _value.CompareTo(value);
		}

		public static explicit operator Int24(byte[] values)
		{
			return new Int24(values);
		}

		public static implicit operator Int24(int value)
		{
			return new Int24(value);
		}

		public static explicit operator byte[](Int24 d)
		{
			return d.GetBytes();
		}

		public static implicit operator int(Int24 d)
		{
			return d.IntValue(); // implicit conversion
		}

		public override string ToString()
		{
			return _value.ToString();
		}
	}
}