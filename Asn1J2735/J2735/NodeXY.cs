namespace Econolite.Asn1J2735.J2735;

public class NodeXY
{
    public NodeOffsetPointXY Delta { get; set; } = new();
    public NodeAttributeSetXY? Attributes { get; set; }
}