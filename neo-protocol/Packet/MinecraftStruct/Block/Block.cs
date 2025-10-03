using System.Numerics;
using neo_protocol.Packet.MinecraftStruct.Entity;
using neo_protocol.Packet.MinecraftStruct.Item;

namespace neo_protocol.Packet.MinecraftStruct.Block;

public class Block : ICloneable
{
    //TODO: Update ALL blocks with names.
    public Block(string name, int id)
    {
        Name = name;
        Id = id;
    }

    public Block(int id) : this(string.Empty, id)
    {
    }

    public bool IsGenerated { get; protected set; } = false;

    public BlockCoordinates Coordinates { get; set; }

    public virtual string Name { get; protected set; }
    public int Id { get; }
    public byte Metadata { get; set; }

    public float Hardness { get; protected set; } = 0;
    public float BlastResistance { get; protected set; } = 0;
    public short FuelEfficiency { get; protected set; } = 0;
    public float FrictionFactor { get; protected set; } = 0.6f;
    public int LightLevel { get; set; } = 0;

    public bool IsReplaceable { get; protected set; } = false;
    public bool IsSolid { get; protected set; } = true;
    public bool IsBuildable { get; protected set; } = true;
    public bool IsTransparent { get; protected set; } = false;
    public bool IsFlammable { get; protected set; } = false;
    public bool IsBlockingSkylight { get; protected set; } = true;

    public byte BlockLight { get; set; }
    public byte SkyLight { get; set; }

    public byte BiomeId { get; set; }


    public object Clone()
    {
        return MemberwiseClone();
    }

    public virtual void SetState(BlockStateContainer blockstate)
    {
        SetState(blockstate.States);
    }

    public virtual void SetState(List<IBlockState> states)
    {
    }

    public virtual BlockStateContainer GetState()
    {
        return null;
    }

    public virtual int GetDirection()
    {
        foreach (var state in GetState().States)
            if (state is BlockStateInt s && s.Name == "direction")
                return s.Value;

        return 0;
    }


    public virtual Item.Item GetItem(int count = 1)
    {
        var id = Id;
        if (id > 255) id = -(id - 255);
        return ItemFactory.GetItem((short)id, Metadata, count);
    }


    public virtual bool PlaceBlock(Level world, Player player, BlockCoordinates targetCoordinates, BlockFace face,
        Vector3 faceCoords)
    {
        // No default placement. Return unhandled.
        return false;
    }

    public virtual void BlockAdded(Level level)
    {
    }

    public virtual bool Interact(Level world, Player player, BlockCoordinates blockCoordinates, BlockFace face,
        Vector3 faceCoord)
    {
        // No default interaction. Return unhandled.
        return false;
    }

    public virtual void OnTick(Level level, bool isRandom)
    {
    }

    public virtual void BlockUpdate(Level level, BlockCoordinates blockCoordinates)
    {
    }

    public float GetHardness()
    {
        return Hardness / 5.0F;
    }

    //public double GetMineTime(Item miningTool)
    //{
    //	int multiplier = (int) miningTool.ItemMaterial;
    //	return Hardness*(1.5*multiplier);
    //


    public virtual float GetExperiencePoints()
    {
        return 0;
    }

    public virtual void DoPhysics(Level level)
    {
    }

    public override string ToString()
    {
        return $"Id: {Id}, Metadata: {GetState()}, Coordinates: {Coordinates}";
    }
}

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public class StateAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public class StateBitAttribute : StateAttribute
{
}

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public class StateRangeAttribute : StateAttribute
{
    public StateRangeAttribute(int minimum, int maximum)
    {
        Minimum = minimum;
        Maximum = maximum;
    }

    public int Minimum { get; }
    public int Maximum { get; }
}

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public class StateEnumAttribute : StateAttribute
{
    public StateEnumAttribute(params string[] validValues)
    {
    }
}