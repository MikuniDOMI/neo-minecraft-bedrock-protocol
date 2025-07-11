﻿using neo_raknet.Utils;
using System.Numerics;

namespace neo_raknet.Packet.MinecraftStruct
{
	public class PlayerLocation : ICloneable
	{
		public float X { get; set; }
		public float Y { get; set; }
		public float Z { get; set; }

		public float Yaw { get; set; }
		public float Pitch { get; set; }
		public float HeadYaw { get; set; }

		public PlayerLocation()
		{
		}

		public PlayerLocation(float x, float y, float z, float headYaw = 0f, float yaw = 0f, float pitch = 0f)
		{
			X = x;
			Y = y;
			Z = z;
			HeadYaw = headYaw;
			Yaw = yaw;
			Pitch = pitch;
		}

		public PlayerLocation(double x, double y, double z, float headYaw = 0f, float yaw = 0f, float pitch = 0f) : this((float)x, (float)y, (float)z, headYaw, yaw, pitch)
		{
		}

		public PlayerLocation(Vector3 vector, float headYaw = 0f, float yaw = 0f, float pitch = 0f) : this(vector.X, vector.Y, vector.Z, headYaw, yaw, pitch)
		{
		}

		public BlockCoordinates GetCoordinates3D()
		{
			return new BlockCoordinates((int)X, (int)Y, (int)Z);
		}

		public double DistanceTo(PlayerLocation other)
		{
			return Math.Sqrt(Square(other.X - X) +
							Square(other.Y - Y) +
							Square(other.Z - Z));
		}

		private double Square(double num)
		{
			return num * num;
		}

		public Vector3 ToVector3()
		{
			return new Vector3(X, Y, Z);
		}

		//public Vector3 GetDirection()
		//{
		//	double pitch = Pitch.ToRadians();
		//	double yaw = Yaw.ToRadians();
		//	double y = -Math.Sin(pitch);
		//	double xz = Math.Cos(pitch);
		//	double x = -xz * Math.Sin(yaw);
		//	double z = xz * Math.Cos(yaw);

		//	return new Vector3((float)x, (float)y, (float)z);
		//}

		public Vector3 GetDirection()
		{
			Vector3 vector = new Vector3();
			double pitch = Pitch.ToRadians();
			double yaw = Yaw.ToRadians();
			vector.X = (float)(-Math.Sin(yaw) * Math.Cos(pitch));
			vector.Y = (float)-Math.Sin(pitch);
			vector.Z = (float)(Math.Cos(yaw) * Math.Cos(pitch));
			return vector;
		}

		public Vector3 GetHeadDirection()
		{
			Vector3 vector = new Vector3();

			double pitch = Pitch.ToRadians();
			double yaw = HeadYaw.ToRadians();
			vector.X = (float)(-Math.Sin(yaw) * Math.Cos(pitch));
			vector.Y = (float)-Math.Sin(pitch);
			vector.Z = (float)(Math.Cos(yaw) * Math.Cos(pitch));

			return vector;
		}

		public static PlayerLocation operator +(PlayerLocation b, Vector3 a)
		{
			return new PlayerLocation(
				a.X + b.X,
				a.Y + b.Y,
				a.Z + b.Z,
				b.HeadYaw,
				b.Yaw,
				b.Pitch);
		}

		public static implicit operator Vector2(PlayerLocation a)
		{
			return new Vector2(a.X, a.Z);
		}

		public static implicit operator Vector3(PlayerLocation a)
		{
			return new Vector3(a.X, a.Y, a.Z);
		}

		public static implicit operator PlayerLocation(BlockCoordinates v)
		{
			return new PlayerLocation(v.X, v.Y, v.Z);
		}

		public object Clone()
		{
			return MemberwiseClone();
		}

		public override string ToString()
		{
			return $"X={X}, Y={Y}, Z={Z}, HeadYaw={HeadYaw}, Yaw={Yaw}, Pich={Pitch}";
		}

		public static bool Equal(PlayerLocation pos_1_62, PlayerLocation pos, float tolerance = 0.01f)
		{
			return Math.Abs(pos_1_62.X - pos.X) < tolerance &&
				   Math.Abs((pos_1_62.Y + 1.62f) - pos.Y) < tolerance &&
				   Math.Abs(pos_1_62.Z - pos.Z) < tolerance &&
				   Math.Abs(pos_1_62.HeadYaw - pos.HeadYaw) < tolerance &&
				   Math.Abs(pos_1_62.Yaw - pos.Yaw) < tolerance &&
				   Math.Abs(pos_1_62.Pitch - pos.Pitch) < tolerance;
		}
	}
}
