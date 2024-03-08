namespace Econolite.Asn1J2735.J2735;

public class MovementEvent
{
  public MovementPhaseState EventState { get; set; }
  public TimeChangeDetails Timing { get; set; } = new();
  public ICollection<AdvisorySpeed> Speeds { get; set; } = new List<AdvisorySpeed>();
}
