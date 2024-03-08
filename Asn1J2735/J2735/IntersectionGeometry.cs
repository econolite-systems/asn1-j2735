namespace Econolite.Asn1J2735.J2735;

public class IntersectionGeometry
{
    public string? Name { get; set; }
    public IntersectionReferenceId Id { get; set; } = new IntersectionReferenceId();
    public int Revision { get; set; } = 0;
    public Position3d RefPoint { get; set; } = new Position3d();
    public int? LaneWidth { get; set; }
    public SpeedLimitList? SpeedLimits { get; set; }
    public LaneList LaneSet { get; set; } = new LaneList();
}