namespace Econolite.Asn1J2735.J2735;

public class ConnectingLane
{
    public int Lane { get; set; }
    public BitString Maneuver { get; set; } = new();
}