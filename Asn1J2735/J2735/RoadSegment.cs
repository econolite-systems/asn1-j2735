namespace Econolite.Asn1J2735.J2735;

public class RoadSegment
{
    public string? Name { get; set; }
    public RoadSegmentReferenceId Id { get; set; } = new RoadSegmentReferenceId();
    public int Revision { get; set; } = 0;
    public Position3d RefPoint { get; set; } = new Position3d();
    public int? LaneWidth { get; set; }
    public SpeedLimitList? SpeedLimits { get; set; }
    public RoadLaneSetList RoadLaneSet { get; set; } = new RoadLaneSetList();
}