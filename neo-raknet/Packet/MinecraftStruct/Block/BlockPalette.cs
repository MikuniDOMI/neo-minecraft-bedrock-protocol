using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo_raknet.Packet.MinecraftStruct.Block
{
	public class BlockPalette : Dictionary<int, BlockStateContainer>
	{
		public static int Version => 17694723;

		public static BlockPalette FromJson(string json)
		{
			var pallet = new BlockPalette();

			dynamic result = JsonConvert.DeserializeObject<dynamic>(json);
			foreach (dynamic obj in result)
			{
				var record = new BlockStateContainer();
				record.Id = obj.Id;
				record.Name = obj.Name;
				record.Data = obj.Data;
				record.RuntimeId = obj.RuntimeId;

				foreach (dynamic stateObj in obj.States)
				{
					switch ((int)stateObj.Type)
					{
						case 1:
							{
								record.States.Add(new BlockStateByte()
								{
									Name = stateObj.Name,
									Value = stateObj.Value
								});
								break;
							}
						case 3:
							{
								record.States.Add(new BlockStateInt()
								{
									Name = stateObj.Name,
									Value = stateObj.Value
								});
								break;
							}
						case 8:
							{
								record.States.Add(new BlockStateString()
								{
									Name = stateObj.Name,
									Value = stateObj.Value
								});
								break;
							}
					}
				}
				pallet.Add(record.RuntimeId, record);
			}


			return pallet;
		}
	}

	public class BlockStateContainer
	{
		public int Id { get; set; }
		public short Data { get; set; }
		public string Name { get; set; }
		public int RuntimeId { get; set; }
		public List<IBlockState> States { get; set; } = new List<IBlockState>();

		[JsonIgnore]
		public byte[] StatesCacheNbt { get; set; }

		protected bool Equals(BlockStateContainer other)
		{
			bool result = /*Id == other.Id && */Name == other.Name;
			if (!result) return false;

			var thisStates = new HashSet<IBlockState>(States);
			var otherStates = new HashSet<IBlockState>(other.States);

			otherStates.IntersectWith(thisStates);
			result = otherStates.Count == thisStates.Count;

			return result;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((BlockStateContainer)obj);
		}

		public override int GetHashCode()
		{
			var hash = new HashCode();
			hash.Add(Id);
			hash.Add(Name);
			foreach (var state in States)
			{
				switch (state)
				{
					case BlockStateByte blockStateByte:
						hash.Add(blockStateByte);
						break;
					case BlockStateInt blockStateInt:
						hash.Add(blockStateInt);
						break;
					case BlockStateString blockStateString:
						hash.Add(blockStateString);
						break;
					default:
						throw new ArgumentOutOfRangeException(nameof(state));
				}
			}

			int hashCode = hash.ToHashCode();
			return hashCode;
		}

		public override string ToString()
		{
			return $"{nameof(Name)}: {Name}, {nameof(Id)}: {Id}, {nameof(Data)}: {Data}, {nameof(RuntimeId)}: {RuntimeId}, {nameof(States)} {{ {string.Join(';', States)} }}";
		}
	}

	public interface IBlockState
	{
		public string Name { get; set; }
	}

	public class BlockStateInt : IBlockState
	{
		public int Type { get; } = 3;
		public string Name { get; set; }
		public int Value { get; set; }

		protected bool Equals(BlockStateInt other)
		{
			return Name == other.Name && Value == other.Value;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != this.GetType())
				return false;
			return Equals((BlockStateInt)obj);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(GetType().Name, Name, Value);
		}

		public override string ToString()
		{
			return $"{nameof(Name)}: {Name}, {nameof(Value)}: {Value}";
		}
	}

	public class BlockStateByte : IBlockState
	{
		public int Type { get; } = 1;
		public string Name { get; set; }
		public byte Value { get; set; }

		protected bool Equals(BlockStateByte other)
		{
			return Name == other.Name && Value == other.Value;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != this.GetType())
				return false;
			return Equals((BlockStateByte)obj);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(GetType().Name, Name, Value);
		}

		public override string ToString()
		{
			return $"{nameof(Name)}: {Name}, {nameof(Value)}: {Value}";
		}
	}

	public class BlockStateString : IBlockState
	{
		public int Type { get; } = 8;
		public string Name { get; set; }
		public string Value { get; set; }

		protected bool Equals(BlockStateString other)
		{
			return string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase) && string.Equals(Value, other.Value, StringComparison.OrdinalIgnoreCase);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != this.GetType())
				return false;
			return Equals((BlockStateString)obj);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(GetType().Name, Name, Value.ToLowerInvariant());
		}

		public override string ToString()
		{
			return $"{nameof(Name)}: {Name}, {nameof(Value)}: {Value}";
		}
	}
}
