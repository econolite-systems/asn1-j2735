namespace Econolite.Asn1J2735.J2735;

public class LaneDataAttribute
{
    public int PathEndPointAngle { get; set; }
    public int LaneCrownPointCenter { get; set; }
    public int LaneCrownPointLeft { get; set; }
    public int LaneCrownPointRight { get; set; }
    public int LaneAngle { get; set; }
    public SpeedLimitList SpeedLimits { get; set; } = new();
}