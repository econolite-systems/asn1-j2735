namespace Econolite.Asn1J2735.J2735;

public class AdvisorySpeed
{
  public AdvisorySpeedType Type { get; set; }
  public int? Speed { get; set; }
  public SpeedConfidence? Confidence { get; set; }
  public int? Distance { get; set; }
  public int? Class { get; set; }
}