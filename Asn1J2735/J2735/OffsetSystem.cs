namespace Econolite.Asn1J2735.J2735;

public class OffsetSystem
{
    public int? Scale { get; set; }
    public NodeList Offset { get; set; } = new();
}