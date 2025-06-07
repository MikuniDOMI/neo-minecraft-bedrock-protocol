namespace neo_raknet.Packet.MinecraftStruct.Entity
{
	public class AttributeModifier
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public float Amount { get; set; }
		public int Operations { get; set; }
		public int Operand { get; set; }
		public bool Serializable { get; set; }

		public override string ToString()
		{
			return $"{{Id: {Id}, Name: {Name}, Amount: {Amount}, Operations: {Operations}, Operand: {Operand}, Serializable: {Serializable}}}";
		}
	}

	public class PlayerAttribute
	{
		public string Name { get; set; }
		public float MinValue { get; set; }
		public float MaxValue { get; set; }
		public float Value { get; set; }
		public float DefaultMinValue { get; set; }
		public float DefaultMaxValue { get; set; }
		public float Default { get; set; }
		public AttributeModifiers Modifiers { get; set; }

		public override string ToString()
		{
			return $"{{Name: {Name}, MinValue: {MinValue}, MaxValue: {MaxValue}, Value: {Value}, Default: {Default}}}";
		}
	}

	public class EntityAttribute
	{
		public string Name { get; set; }
		public float MinValue { get; set; }
		public float MaxValue { get; set; }
		public float Value { get; set; }

		public override string ToString()
		{
			return $"{{Name: {Name}, MinValue: {MinValue}, MaxValue: {MaxValue}, Value: {Value}}}";
		}
	}


	public enum GameRulesEnum
	{
		CommandblockOutput,
		DoDaylightcycle,
		DoEntitydrops,
		DoFiretick,
		DoMobloot,
		DoMobspawning,
		DoTiledrops,
		DoWeathercycle,
		DrowningDamage,
		Falldamage,
		Firedamage,
		KeepInventory,
		Mobgriefing,
		Pvp,
		ShowCoordinates,
		NaturalRegeneration,
		TntExplodes,
		SendCommandfeedback,
		ExperimentalGameplay,
		// int,
		DoInsomnia,
		CommandblocksEnabled,
		// int,
		DoImmediateRespawn,
		ShowDeathmessages,
		// int,
	}

	public abstract class GameRule
	{
		public string Name { get; }
		public bool IsPlayerModifiable { get; set; } = true;

		protected GameRule(string name)
		{
			Name = name;
		}

		protected bool Equals(GameRule other)
		{
			return string.Equals(Name, other.Name);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((GameRule)obj);
		}

		public override int GetHashCode()
		{
			return (Name != null ? Name.GetHashCode() : 0);
		}
	}

	public class GameRule<T> : GameRule
	{
		public T Value { get; set; }

		public GameRule(GameRulesEnum rule, T value) : this(rule.ToString(), value)
		{
		}

		public GameRule(string name, T value) : base(name)
		{
			Value = value;
		}
	}
}
