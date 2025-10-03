namespace neo_protocol.Packet.MinecraftPacket;

public class McpeAnimateEntity : Packet
{
    public string animationName; // = null;
    public float blendOutTime; // = null;
    public string controllerName; // = null;
    public long[] entities; // = null;
    public int molangVersion; // = null;
    public string nextState; // = null;
    public string stopExpression; // = null;

    public McpeAnimateEntity()
    {
        Id = 0x9e;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(animationName);
        Write(nextState);
        Write(stopExpression);
        Write(molangVersion);
        Write(controllerName);
        Write(blendOutTime);
        WriteUnsignedVarInt((uint)entities.Count());
        for (var i = 0; i < entities.Count(); i++) WriteUnsignedVarLong(entities[i]);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        animationName = ReadString();
        nextState = ReadString();
        stopExpression = ReadString();
        molangVersion = ReadInt();
        controllerName = ReadString();
        blendOutTime = ReadFloat();
        for (var i = 0; i < ReadUnsignedVarInt(); i++) entities[i] = ReadUnsignedVarLong();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        animationName = default;
        nextState = default;
        stopExpression = default;
        molangVersion = default;
        controllerName = default;
        blendOutTime = default;
        entities = default;
    }
}