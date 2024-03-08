namespace Econolite.Asn1J2735.J2735;

public class RoadSignId
{
    public Position3d Position { get; set; } = new();
    public string ViewAngle { get; set; }
    public MUTCDCode? MutcdCode { get; set; }
}