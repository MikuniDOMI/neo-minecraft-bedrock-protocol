namespace neo_raknet.Packet.MinecraftPacket;

public class McpePlayStatus : Packet
{
    public int status; // = null;

    public enum PlayStatus
    {
        LoginSuccess             = 0,
        LoginFailedClient        = 1,
        LoginFailedServer        = 2,
        PlayerSpawn              = 3,
        LoginFailedInvalidTenant = 4,
        LoginFailedVanillaEdu    = 5,
        LoginFailedEduVanilla    = 6,
        LoginFailedServerFull    = 7
    }

    public McpePlayStatus()
    {
        Id = 0x02;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteBe(status);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        status = ReadIntBe();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        status = default;
    }
}