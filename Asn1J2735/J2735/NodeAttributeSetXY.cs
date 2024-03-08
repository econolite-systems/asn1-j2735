namespace Econolite.Asn1J2735.J2735;

public class NodeAttributeSetXY
{
    public NodeAttributeXYList LocalNode { get; set; } = new();
    public SegmentAttributeXYList Disabled { get; set; } = new();
    public SegmentAttributeXYList Enabled { get; set; } = new();
    public LaneDataAttributeList Data { get; set; } = new();
    public int DWidth { get; set; }
    public int DElevation { get; set; }
}