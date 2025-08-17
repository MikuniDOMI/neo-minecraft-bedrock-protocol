using System;
using System.Collections.Generic; // For List<T>
using System.Numerics; // If needed for any Vector types, though not in these structs
namespace neo_raknet.Protocol.Biomes // Adjust namespace as needed
{
    // --- Enums (Based on Go const iota) ---

    // Note: Go's iota - 1 starts from -1. C# enums start from 0.
    // We adjust values to match Go's sequence.
    public enum BiomeExpressionOp
    {
        Unknown = -1,
        LeftBrace = 0,
        RightBrace = 1,
        LeftBracket = 2,
        RightBracket = 3,
        LeftParenthesis = 4,
        RightParenthesis = 5,
        Negate = 6,
        LogicalNot = 7,
        Abs = 8,
        Add = 9,
        Acos = 10,
        Asin = 11,
        Atan = 12,
        Atan2 = 13,
        Ceil = 14,
        Clamp = 15,
        CopySign = 16,
        Cos = 17,
        DieRoll = 18,
        DieRollInt = 19,
        Div = 20,
        Exp = 21,
        Floor = 22,
        HermiteBlend = 23,
        Lerp = 24,
        LerpRotate = 25,
        Ln = 26,
        Max = 27,
        Min = 28,
        MinAngle = 29,
        Mod = 30,
        Mul = 31,
        Pow = 32,
        Random = 33,
        RandomInt = 34,
        Round = 35,
        Sin = 36,
        Sign = 37,
        Sqrt = 38,
        Trunc = 39,
        QueryFunction = 40,
        ArrayVariable = 41,
        ContextVariable = 42,
        EntityVariable = 43,
        TempVariable = 44,
        MemberAccessor = 45,
        HashedStringHash = 46,
        GeometryVariable = 47,
        MaterialVariable = 48,
        TextureVariable = 49,
        LessThan = 50,
        LessEqual = 51,
        GreaterEqual = 52,
        GreaterThan = 53,
        LogicalEqual = 54,
        LogicalNotEqual = 55,
        LogicalOr = 56,
        LogicalAnd = 57,
        NullCoalescing = 58,
        Conditional = 59,
        ConditionalElse = 60,
        Float = 61,
        Pi = 62,
        Array = 63,
        Geometry = 64,
        Material = 65,
        Texture = 66,
        Loop = 67,
        ForEach = 68,
        Break = 69,
        Continue = 70,
        Assignment = 71,
        Pointer = 72,
        Semicolon = 73,
        Return = 74,
        Comma = 75,
        This = 76,
    }

    public enum BiomeCoordinateEvaluationOrder
    {
        XYZ = 0,
        XZY = 1,
        YXZ = 2,
        YZX = 3,
        ZXY = 4,
        ZYX = 5,
    }

    public enum BiomeRandomDistributionType
    {
        SingleValued = 0,
        Uniform = 1,
        Gaussian = 2,
        InverseGaussian = 3,
        FixedGrid = 4,
        JitteredGrid = 5,
        Triangle = 6,
    }


    // --- Struct Definitions ---

    // BiomeWeight
    public struct BiomeWeight
    {
        public short Biome { get; set; } // int16
        public uint Weight { get; set; } // uint32
    }

    // BiomeTemperatureWeight
    public struct BiomeTemperatureWeight
    {
        public int Temperature { get; set; } // int32
        public uint Weight { get; set; } // uint32
    }

    // BiomeConditionalTransformation
    public struct BiomeConditionalTransformation
    {
        public BiomeWeight[] WeightedBiomes { get; set; } // []BiomeWeight
        public short ConditionJSON { get; set; } // int16
        public uint MinPassingNeighbours { get; set; } // uint32
    }

    // BiomeMultiNoiseRules
    public struct BiomeMultiNoiseRules
    {
        public float Temperature { get; set; } // float32
        public float Humidity { get; set; } // float32
        public float Altitude { get; set; } // float32
        public float Weirdness { get; set; } // float32
        public float Weight { get; set; } // float32
    }

    // BiomeOverworldRules
    public struct BiomeOverworldRules
    {
        public BiomeWeight[] HillsTransformations { get; set; }
        public BiomeWeight[] MutateTransformations { get; set; }
        public BiomeWeight[] RiverTransformations { get; set; }
        public BiomeWeight[] ShoreTransformations { get; set; }
        public BiomeConditionalTransformation[] PreHillsEdgeTransformations { get; set; }
        public BiomeConditionalTransformation[] PostShoreEdgeTransformations { get; set; }
        public BiomeTemperatureWeight[] ClimateTransformations { get; set; }
    }

    // BiomeCappedSurface
    public struct BiomeCappedSurface
    {
        public int[] FloorBlocks { get; set; } // []int32
        public int[] CeilingBlocks { get; set; } // []int32
        public Optional<uint> SeaBlock { get; set; } // Optional[uint32]
        public Optional<uint> FoundationBlock { get; set; } // Optional[uint32]
        public Optional<uint> BeachBlock { get; set; } // Optional[uint32]
    }

    // BiomeMesaSurface
    public struct BiomeMesaSurface
    {
        public uint ClayMaterial { get; set; } // uint32
        public uint HardClayMaterial { get; set; } // uint32
        public bool BrycePillars { get; set; } // bool
        public bool HasForest { get; set; } // bool
    }

    // BiomeSurfaceMaterial
    public struct BiomeSurfaceMaterial
    {
        public int TopBlock { get; set; } // int32
        public int MidBlock { get; set; } // int32
        public int SeaFloorBlock { get; set; } // int32
        public int FoundationBlock { get; set; } // int32
        public int SeaBlock { get; set; } // int32
        public int SeaFloorDepth { get; set; } // int32
    }

    // BiomeElementData
    public struct BiomeElementData
    {
        public float NoiseFrequencyScale { get; set; } // float32
        public float NoiseLowerBound { get; set; } // float32
        public float NoiseUpperBound { get; set; } // float32
        public int HeightMinType { get; set; } // int32
        public short HeightMin { get; set; } // int16
        public int HeightMaxType { get; set; } // int32
        public short HeightMax { get; set; } // int16
        public BiomeSurfaceMaterial AdjustedMaterials { get; set; } // BiomeSurfaceMaterial
    }

    // BiomeMountainParameters
    public struct BiomeMountainParameters
    {
        public int SteepBlock { get; set; } // int32
        public bool NorthSlopes { get; set; } // bool
        public bool SouthSlopes { get; set; } // bool
        public bool WestSlopes { get; set; } // bool
        public bool EastSlopes { get; set; } // bool
        public bool TopSlideEnabled { get; set; } // bool
    }

    // BiomeCoordinate
    public struct BiomeCoordinate
    {
        public int MinValueType { get; set; } // int32
        public short MinValue { get; set; } // int16
        public int MaxValueType { get; set; } // int32
        public short MaxValue { get; set; } // int16
        public uint GridOffset { get; set; } // uint32
        public uint GridStepSize { get; set; } // uint32
        public int Distribution { get; set; } // int32 (BiomeRandomDistributionType)
    }

    // BiomeScatterParameter
    public struct BiomeScatterParameter
    {
        public BiomeCoordinate[] Coordinates { get; set; } // []BiomeCoordinate
        public int EvaluationOrder { get; set; } // int32 (BiomeCoordinateEvaluationOrder)
        public int ChancePercentType { get; set; } // int32 (BiomeExpressionOp)
        public short ChancePercent { get; set; } // int16
        public int ChanceNumerator { get; set; } // int32
        public int ChanceDenominator { get; set; } // int32
        public int IterationsType { get; set; } // int32 (BiomeExpressionOp)
        public short Iterations { get; set; } // int16
    }

    // BiomeConsolidatedFeature
    public struct BiomeConsolidatedFeature
    {
        public BiomeScatterParameter Scatter { get; set; } // BiomeScatterParameter
        public short Feature { get; set; } // int16
        public short Identifier { get; set; } // int16
        public short Pass { get; set; } // int16
        public bool CanUseInternal { get; set; } // bool
    }

    // BiomeClimate
    public struct BiomeClimate
    {
        public float Temperature { get; set; } // float32
        public float Downfall { get; set; } // float32
        public float RedSporeDensity { get; set; } // float32
        public float BlueSporeDensity { get; set; } // float32
        public float AshDensity { get; set; } // float32
        public float WhiteAshDensity { get; set; } // float32
        public float SnowAccumulationMin { get; set; } // float32
        public float SnowAccumulationMax { get; set; } // float32
    }

    // BiomeChunkGeneration
    public struct BiomeChunkGeneration
    {
        public Optional<BiomeClimate> Climate { get; set; } // Optional[BiomeClimate]
        public Optional<BiomeConsolidatedFeature[]> ConsolidatedFeatures { get; set; } // Optional[[]BiomeConsolidatedFeature]
        public Optional<BiomeMountainParameters> MountainParameters { get; set; } // Optional[BiomeMountainParameters]
        public Optional<BiomeElementData[]> SurfaceMaterialAdjustments { get; set; } // Optional[[]BiomeElementData]
        public Optional<BiomeSurfaceMaterial> SurfaceMaterials { get; set; } // Optional[BiomeSurfaceMaterial]
        public bool HasSwampSurface { get; set; } // bool
        public bool HasFrozenOceanSurface { get; set; } // bool
        public bool HasEndSurface { get; set; } // bool
        public Optional<BiomeMesaSurface> MesaSurface { get; set; } // Optional[BiomeMesaSurface]
        public Optional<BiomeCappedSurface> CappedSurface { get; set; } // Optional[BiomeCappedSurface]
        public Optional<BiomeOverworldRules> OverworldRules { get; set; } // Optional[BiomeOverworldRules]
        public Optional<BiomeMultiNoiseRules> MultiNoiseRules { get; set; } // Optional[BiomeMultiNoiseRules]
        public Optional<BiomeConditionalTransformation[]> LegacyRules { get; set; } // Optional[[]BiomeConditionalTransformation]
    }

    // BiomeDefinition (Main struct)
    public struct BiomeDefinition
    {
        public short NameIndex { get; set; } // int16
        public short BiomeID { get; set; } // int16
        public float Temperature { get; set; } // float32
        public float Downfall { get; set; } // float32
        public float RedSporeDensity { get; set; } // float32
        public float BlueSporeDensity { get; set; } // float32
        public float AshDensity { get; set; } // float32
        public float WhiteAshDensity { get; set; } // float32
        public float Depth { get; set; } // float32
        public float Scale { get; set; } // float32
        public int MapWaterColour { get; set; } // int32
        public bool Rain { get; set; } // bool
        public Optional<ushort[]> Tags { get; set; } // Optional[[]uint16]
        public Optional<BiomeChunkGeneration> ChunkGeneration { get; set; } // Optional[BiomeChunkGeneration]
    }
}