using neo_raknet.Packet.MinecraftStruct;

namespace neo_raknet.Utils;

public class MapInfo : ICloneable
{
    public int Col;
    public byte[] Data;
    public MapDecorator[] Decorators = new MapDecorator[0];
    public long MapId;
    public BlockCoordinates Origin = new();
    public int Row;
    public int Scale;
    public MapTrackedObject[] TrackedObjects = new MapTrackedObject[0];
    public byte UpdateType;
    public byte X;
    public int XOffset;
    public byte Z;
    public int ZOffset;

    public object Clone()
    {
        return MemberwiseClone();
    }

    public override string ToString()
    {
        return
            $"MapId: {MapId}, UpdateType: {UpdateType}, X: {X}, Z: {Z}, Col: {Col}, Row: {Row}, X-offset: {XOffset}, Z-offset: {ZOffset}, Data: {Data?.Length}";
    }
}

public class MapDecorator
{
    public uint Color;
    public byte Icon;
    public string Label;
    public byte Rotation;
    protected int Type;
    public byte X;
    public byte Z;
}

public class BlockMapDecorator : MapDecorator
{
    public BlockCoordinates Coordinates;

    public BlockMapDecorator()
    {
        Type = 1;
    }
}

public class EntityMapDecorator : MapDecorator
{
    public long EntityId;

    public EntityMapDecorator()
    {
        Type = 0;
    }
}

public class MapTrackedObject
{
    protected int Type;
}

public class EntityMapTrackedObject : MapTrackedObject
{
    public long EntityId;

    public EntityMapTrackedObject()
    {
        Type = 0;
    }
}

public class BlockMapTrackedObject : MapTrackedObject
{
    public BlockCoordinates Coordinates;

    public BlockMapTrackedObject()
    {
        Type = 1;
    }
}