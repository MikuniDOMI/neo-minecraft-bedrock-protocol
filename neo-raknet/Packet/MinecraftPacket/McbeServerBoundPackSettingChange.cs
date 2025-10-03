using System;
using System.Collections.Generic;
using System.Text;
using neo_raknet.Utils;

namespace neo_raknet.Packet.MinecraftPacket
{
    public class McbeServerBoundPackSettingChange : Packet
    {
        public UUID PackID;
        public PackSetting Setting;
        public McbeServerBoundPackSettingChange()
        {
            Id = 329;
            IsMcpe = true;
        }
        protected override void EncodePacket()
        {
            base.EncodePacket();
            Write(PackID);
            WritePackSetting(Setting);
        }
        protected override void DecodePacket()
        {
            base.DecodePacket();
            PackID = ReadUUID();
            Setting = ReadPackSetting();
        }
        protected override void ResetPacket()
        {
            base.ResetPacket();
            PackID = default;
            Setting = default;
        }
    }
}
