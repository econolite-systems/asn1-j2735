namespace Econolite.Asn1J2735.J2735.TimStorage;

public class ShapePointSet
{
    public Position Anchor { get; set; } = new();
    public int LaneWidth { get; set; }
    public DirectionOfUse Directionality { get; set; }
    public NodeListXY NodeList { get; set; } = new();
}