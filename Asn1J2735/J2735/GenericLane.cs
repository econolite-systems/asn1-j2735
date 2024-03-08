namespace Econolite.Asn1J2735.J2735;

public class GenericLane
{
    public int LaneId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int IngressApproach { get; set; }
    public int EgressApproach { get; set; }
    public LaneAttributes LaneAttributes { get; set; } = new();
    public BitString Maneuvers { get; set; } = new();
    public NodeListXY NodeList { get; set; } = new();
    public ConnectsToList ConnectsTo { get; set; } = new();
    public OverlayLaneList Overlays { get; set; } = new();
}