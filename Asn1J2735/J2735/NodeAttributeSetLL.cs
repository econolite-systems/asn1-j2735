namespace Econolite.Asn1J2735.J2735;

// ReSharper disable once InconsistentNaming
public class NodeAttributeSetLL
{
    public NodeAttributeLLList LocalNode { get; set; } = new();
    public SegmentAttributeLLList Disabled { get; set; } = new();
    public SegmentAttributeLLList Enabled { get; set; } = new();
    public LaneDataAttributeList Data { get; set; } = new();
    public int? DWidth { get; set; }
    public int? DElevation { get; set; }
}