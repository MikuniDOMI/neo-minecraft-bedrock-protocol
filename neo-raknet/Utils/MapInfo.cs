using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo_raknet.Utils
{
    public class MapInfo : ICloneable
    {
        public long               MapId;
        public byte               UpdateType;
        public BlockCoordinates   Origin         = new BlockCoordinates();
        public MapDecorator[]     Decorators     = new MapDecorator[0];
        public MapTrackedObject[] TrackedObjects = new MapTrackedObject[0];
        public byte               X;
        public byte               Z;
        public int                Scale;
        public int                Col;
        public int                Row;
        public int                XOffset;
        public int                ZOffset;
        public byte[]             Data;

        public override string ToString()
        {
            return $"MapId: {MapId}, UpdateType: {UpdateType}, X: {X}, Z: {Z}, Col: {Col}, Row: {Row}, X-offset: {XOffset}, Z-offset: {ZOffset}, Data: {Data?.Length}";
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    public class MapDecorator
    {
        protected int    Type;
        public    byte   Rotation;
        public    byte   Icon;
        public    byte   X;
        public    byte   Z;
        public    string Label;
        public    uint   Color;
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
}
