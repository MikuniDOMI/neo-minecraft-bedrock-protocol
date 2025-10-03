namespace neo_protocol.Packet.MinecraftPacket;

public class McpeAddBehaviorTree : Packet
{
    public string behaviortree; // = null;

    public McpeAddBehaviorTree()
    {
        Id = 0x59;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        Write(behaviortree);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        behaviortree = ReadString();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        behaviortree = default;
    }
}