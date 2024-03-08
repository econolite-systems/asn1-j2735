namespace Econolite.Asn1J2735.J2735;

public class NodeLL
{
    public NodeOffsetPointLL Delta { get; set; } = new();
    public NodeAttributeSetLL? Attributes { get; set; }
}