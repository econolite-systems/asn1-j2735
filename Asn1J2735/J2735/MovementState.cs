namespace Econolite.Asn1J2735.J2735;

public class MovementState
{
  public string MovementName { get; set; } = string.Empty;
  public int SignalGroup { get; set; }
  public ICollection<MovementEvent> StateTimeSpeed { get; set; } = new List<MovementEvent>();
  public ICollection<ConnectionManeuverAssist> ManeuverAssistList { get; set; } = new List<ConnectionManeuverAssist>();
}