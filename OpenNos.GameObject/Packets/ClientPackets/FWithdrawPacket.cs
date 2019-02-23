﻿////<auto-generated <- Codemaid exclusion for now (PacketIndex Order is important for maintenance)

using OpenNos.Core;

namespace OpenNos.GameObject
{
    [PacketHeader("f_withdraw")]
    public class FWithdrawPacket : PacketDefinition
    {
        #region Properties        

        [PacketIndex(0)]
        public short Slot { get; set; }

        [PacketIndex(1)]
        public byte Amount { get; set; }

        [PacketIndex(2)]
        public byte? Unknown { get; set; }
        #endregion
    }
}