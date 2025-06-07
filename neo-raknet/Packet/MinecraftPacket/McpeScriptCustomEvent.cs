namespace neo_raknet.Packet.MinecraftPacket;

public class McpeScriptCustomEvent : Packet
{
    public string eventData; // = null;

    public string eventName; // = null;

    public McpeScriptCustomEvent()
    {
        Id = 0x75;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(eventName);
        Write(eventData);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        eventName = ReadString();
        eventData = ReadString();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        eventName = default;
        eventData = default;
    }
}