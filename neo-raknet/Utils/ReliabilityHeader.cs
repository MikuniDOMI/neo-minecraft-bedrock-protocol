﻿namespace neo_raknet.Utils;

public class ReliabilityHeader
{
    public Reliability Reliability { get; set; } = Reliability.Undefined;
    public Int24 ReliableMessageNumber { get; set; }
    public Int24 SequencingIndex { get; set; }
    public Int24 OrderingIndex { get; set; }
    public byte OrderingChannel { get; set; }

    public bool HasSplit { get; set; }
    public int PartCount { get; set; }
    public short PartId { get; set; }
    public int PartIndex { get; set; }

    public void Reset()
    {
        Reliability = Reliability.Undefined;
        ReliableMessageNumber = default;
        SequencingIndex = default;
        OrderingIndex = default;
        OrderingChannel = default;

        HasSplit = false;
        PartCount = default;
        PartId = default;
        PartIndex = default;
    }
}