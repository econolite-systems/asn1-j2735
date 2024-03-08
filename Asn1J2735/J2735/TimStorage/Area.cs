namespace Econolite.Asn1J2735.J2735.TimStorage;

public class Area
{
    public ShapePointSet Shapepoint { get; set; } = new();
    public Circle Circle { get; set; } = new();
    public RegionPointSet RegionPoint { get; set; } = new();
}