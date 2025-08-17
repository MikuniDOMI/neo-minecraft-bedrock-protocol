using System.Numerics;

namespace neo_raknet.Packet.MinecraftPacket;

public class McpeCorrectPlayerMovePrediction : Packet
{
    /// <summary>
    ///     定义预测类型的枚举。
    /// </summary>
    public enum PredictionType : byte
    {
        Player = 0, // 玩家移动预测
        Vehicle = 1 // 载具移动预测
    }

    /// <summary>
    ///     构造函数，设置数据包 ID 并标记为 MCPE 包。
    /// </summary>
    public McpeCorrectPlayerMovePrediction()
    {
        Id = 161; // IDCorrectPlayerMovePrediction
        IsMcpe = true; // 标记为 MCPE 协议包
    }

    /// <summary>
    ///     预测类型，指定被纠正的预测类型。
    /// </summary>
    public PredictionType Type { get; set; }

    /// <summary>
    ///     在下面指定的 tick 时，玩家应该所在的位置。
    ///     客户端将从该 Position 开始，根据之后的移动来更新其当前位置。
    /// </summary>
    public Vector3 Position { get; set; }

    /// <summary>
    ///     与客户端在该特定 tick 发送的位置相比的位置变化量。
    /// </summary>
    public Vector3 Delta { get; set; }

    /// <summary>
    ///     在下面指定的 tick 时玩家的旋转角度。
    /// </summary>
    public Vector2 Rotation { get; set; }

    /// <summary>
    ///     骑手所骑载具的角速度（可选）。
    /// </summary>
    public Optional<float> VehicleAngularVelocity { get; set; } = new();

    /// <summary>
    ///     指定在下面的 tick 时玩家是否在地面上。
    /// </summary>
    public bool OnGround { get; set; }

    /// <summary>
    ///     被此数据包纠正的移动的 tick。
    /// </summary>
    public long Tick { get; set; }

    /// <summary>
    ///     将数据包编码为字节流。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket(); // 调用基类的 EncodePacket 方法

        Write((byte)Type);
        Write(Position);
        Write(Delta);
        Write(Rotation);

        // 对应 Go 的 protocol.OptionalFunc(io, &pk.VehicleAngularVelocity, io.Float32)
        Write(VehicleAngularVelocity.HasValue);
        if (VehicleAngularVelocity.HasValue) Write(VehicleAngularVelocity.Value);

        Write(OnGround);
        WriteUnsignedVarLong(Tick);
    }

    /// <summary>
    ///     从字节流中解码数据包。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket(); // 调用基类的 DecodePacket 方法

        Type = (PredictionType)ReadByte();
        Position = ReadVector3();
        Delta = ReadVector3();
        Rotation = ReadVector2();

        // 对应 Go 的 protocol.OptionalFunc(io, &pk.VehicleAngularVelocity, io.Float32)
        VehicleAngularVelocity.HasValue = ReadBool();
        if (VehicleAngularVelocity.HasValue) VehicleAngularVelocity.Value = ReadFloat();

        OnGround = ReadBool();
        Tick = ReadUnsignedVarLong();
    }
}