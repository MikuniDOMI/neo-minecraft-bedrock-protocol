// Assuming base Packet class is here or adjust accordingly

namespace neo_raknet.Packet.MinecraftPacket;

/// <summary>
///     ServerBoundDiagnostics 数据包：由客户端发送，用于向服务器报告客户端的性能诊断信息。
///     当启用 "Creator > Enable Client Diagnostics" 设置时，客户端大约每 500ms 或 10 个游戏刻发送一次。
/// </summary>
public class McpeServerBoundDiagnostics : Packet
{
    /// <summary>
    ///     初始化 McpeServerBoundDiagnostics 类的新实例。
    /// </summary>
    public McpeServerBoundDiagnostics()
    {
        Id = 315; // IDServerBoundDiagnostics
        IsMcpe = true;
    }

    /// <summary>
    ///     AverageFramesPerSecond 是客户端运行的平均帧率。
    /// </summary>
    public float AverageFramesPerSecond { get; set; } // float32 -> float

    /// <summary>
    ///     AverageServerSimTickTime 是服务器模拟单个刻所花费的平均时间（毫秒）。
    /// </summary>
    public float AverageServerSimTickTime { get; set; } // float32 -> float

    /// <summary>
    ///     AverageClientSimTickTime 是客户端模拟单个刻所花费的平均时间（毫秒）。
    /// </summary>
    public float AverageClientSimTickTime { get; set; } // float32 -> float

    /// <summary>
    ///     AverageBeginFrameTime 是客户端开始渲染一帧所花费的平均时间（毫秒）。
    /// </summary>
    public float AverageBeginFrameTime { get; set; } // float32 -> float

    /// <summary>
    ///     AverageInputTime 是客户端处理输入所花费的平均时间（毫秒）。
    /// </summary>
    public float AverageInputTime { get; set; } // float32 -> float

    /// <summary>
    ///     AverageRenderTime 是客户端渲染所花费的平均时间（毫秒）。
    /// </summary>
    public float AverageRenderTime { get; set; } // float32 -> float

    /// <summary>
    ///     AverageEndFrameTime 是客户端结束渲染一帧所花费的平均时间（毫秒）。
    /// </summary>
    public float AverageEndFrameTime { get; set; } // float32 -> float

    /// <summary>
    ///     AverageRemainderTimePercent 是客户端花费在未明确计入的其他任务上的平均时间百分比。
    /// </summary>
    public float AverageRemainderTimePercent { get; set; } // float32 -> float

    /// <summary>
    ///     AverageUnaccountedTimePercent 是客户端花费在未计入任务上的平均时间百分比。
    /// </summary>
    public float AverageUnaccountedTimePercent { get; set; } // float32 -> float

    /// <summary>
    ///     编码数据包数据。
    /// </summary>
    protected override void EncodePacket()
    {
        base.EncodePacket();

        // void Write(float value) - 对应 Go 的 io.Float32
        Write(AverageFramesPerSecond);
        Write(AverageServerSimTickTime);
        Write(AverageClientSimTickTime);
        Write(AverageBeginFrameTime);
        Write(AverageInputTime);
        Write(AverageRenderTime);
        Write(AverageEndFrameTime);
        Write(AverageRemainderTimePercent);
        Write(AverageUnaccountedTimePercent);
    }

    /// <summary>
    ///     解码数据包数据。
    /// </summary>
    protected override void DecodePacket()
    {
        base.DecodePacket();

        // float ReadFloat() - 对应 Go 的 io.Float32
        AverageFramesPerSecond = ReadFloat();
        AverageServerSimTickTime = ReadFloat();
        AverageClientSimTickTime = ReadFloat();
        AverageBeginFrameTime = ReadFloat();
        AverageInputTime = ReadFloat();
        AverageRenderTime = ReadFloat();
        AverageEndFrameTime = ReadFloat();
        AverageRemainderTimePercent = ReadFloat();
        AverageUnaccountedTimePercent = ReadFloat();
    }

    /// <summary>
    ///     将数据包数据重置为默认值。
    /// </summary>
    protected override void ResetPacket()
    {
        base.ResetPacket();
        AverageFramesPerSecond = 0.0f;
        AverageServerSimTickTime = 0.0f;
        AverageClientSimTickTime = 0.0f;
        AverageBeginFrameTime = 0.0f;
        AverageInputTime = 0.0f;
        AverageRenderTime = 0.0f;
        AverageEndFrameTime = 0.0f;
        AverageRemainderTimePercent = 0.0f;
        AverageUnaccountedTimePercent = 0.0f;
    }
}