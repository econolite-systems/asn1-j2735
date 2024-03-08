namespace Econolite.Asn1J2735.J2735.TimStorage;

public class Circle
{
    public Position3d Center { get; set; } = new Position3d();
    public int Radius { get; set; }
    public DistanceUnits Units { get; set; } = DistanceUnits.foot; // Uses a DistanceUnits
}