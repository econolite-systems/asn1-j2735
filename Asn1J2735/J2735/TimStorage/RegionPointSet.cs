namespace Econolite.Asn1J2735.J2735.TimStorage;

public class RegionPointSet
{
    public Position Anchor { get; set; } = new();
    public int? Scale { get; set; }
    public RegionList RegionList { get; set; } = new();
}