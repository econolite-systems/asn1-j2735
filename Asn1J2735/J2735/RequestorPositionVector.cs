namespace Econolite.Asn1J2735.J2735;

public class RequestorPositionVector
{
    public Position3d Position { get; set; } = new();
    public int? Heading { get; set; }
    public TransmissionAndSpeed Speed { get; set; } = new();
}