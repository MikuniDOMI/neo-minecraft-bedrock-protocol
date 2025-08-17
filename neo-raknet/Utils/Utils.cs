namespace neo_raknet.Utils;

public static class Utils
{
    public static ushort UDP_CLIENT_MTU = 1400;

    public static long GetTimeStampLong()
    {
        var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var timeSinceEpoch = DateTime.UtcNow - unixEpoch;
        var milliseconds = (long)timeSinceEpoch.TotalMilliseconds;
        return milliseconds;
    }
}