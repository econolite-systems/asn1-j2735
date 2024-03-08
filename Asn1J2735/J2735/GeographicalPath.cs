namespace Econolite.Asn1J2735.J2735;

public class GeographicalPath
{
    public string? Name { get; set; }
    public RoadSegmentReferenceId? Id { get; set; }
    public Position3d? Anchor { get; set; }
    public int? LaneWidth { get; set; }
    public DirectionOfUse? Directionality { get; set; }
    public bool? ClosedPath { get; set; }
    public string? Direction { get; set; }
    public GeometryType? Description { get; set; } 
}