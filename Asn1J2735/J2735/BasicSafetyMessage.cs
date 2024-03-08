namespace Econolite.Asn1J2735.J2735;

public class BasicSafetyMessage: IPdu
{
    public BSMcoreData CoreData { get; set; } = new();
    public IEnumerable<PartIIcontent> PartIIType { get; set; } = Array.Empty<PartIIcontent>();
}