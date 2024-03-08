namespace Econolite.Asn1J2735.J2735;

public class MapData {
    public int? TimeStamp { get; set; } // MinuteOfTheYear
    public int MsgIssueRevision { get; set; }
    public LayerType? LayerType { get; set; }
    public int? LayerId { get; set; }
    public IntersectionGeometryList? Intersections { get; set; }
    public RoadSegmentList? RoadSegments { get; set; }
    public RestrictionClassList? RestrictionList { get; set; }
}
