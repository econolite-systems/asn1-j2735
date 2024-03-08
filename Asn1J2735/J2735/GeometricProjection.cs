using Econolite.Asn1J2735.J2735.TimStorage;

namespace Econolite.Asn1J2735.J2735;

public class GeometricProjection
{
    public string? Direction { get; set; }
    public int? LaneWidth { get; set; }
    public Circle Circle { get; set; } = new();
    public Extent? Extent { get; set; }
}