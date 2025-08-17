using Newtonsoft.Json;

namespace neo_raknet.Packet.MinecraftStruct.Entity;

public class AttributeModifiers : Dictionary<string, AttributeModifier>
{
}

public class PlayerAttributes : Dictionary<string, PlayerAttribute>
{
}

public class EntityAttributes : Dictionary<string, EntityAttribute>
{
}

public class EntityLink
{
    public enum EntityLinkType : byte
    {
        Remove = 0,
        Rider = 1,
        Passenger = 2
    }

    public EntityLink(long fromEntityId, long toEntityId, EntityLinkType type, bool immediate, bool causedByRider,
        float vehicleAngularVelocity)
    {
        FromEntityId = fromEntityId;
        ToEntityId = toEntityId;
        Type = type;
        Immediate = immediate;
        CausedByRider = causedByRider;
        VehicleAngularVelocity = vehicleAngularVelocity;
    }

    public long FromEntityId { get; set; }
    public long ToEntityId { get; set; }
    public EntityLinkType Type { get; set; }
    public bool Immediate { get; set; }
    public bool CausedByRider { get; set; }
    public float VehicleAngularVelocity { get; set; }
}

public class EntityLinks : List<EntityLink>
{
}

public class GameRules : HashSet<GameRule>
{
}

public class Itemstates : List<Itemstate>
{
    public static Itemstates FromJson(string json)
    {
        return JsonConvert.DeserializeObject<Itemstates>(json);
    }
}

public class Itemstate
{
    [JsonProperty("runtime_id")] public short Id { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("component_based")] public bool ComponentBased { get; set; }

    [JsonProperty("version")] public int Version { get; set; }

    [JsonProperty("components")] public byte[] Components { get; set; }
}