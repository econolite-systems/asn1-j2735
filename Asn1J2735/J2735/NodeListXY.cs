namespace Econolite.Asn1J2735.J2735;

public class NodeListXY
{
    public NodeSetXY Nodes { get; set; } = new();
    public ComputedLane Computed { get; set; } = new();
}