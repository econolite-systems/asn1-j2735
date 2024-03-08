namespace Econolite.Asn1J2735.J2735;

public class LaneAttributes
{
    public BitString DirectionalUse { get; set; } = new();
    public BitString ShareWith { get; set; } = new();
    public LaneTypeAttributes LaneType { get; set; } = new();
}