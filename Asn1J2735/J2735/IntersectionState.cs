namespace Econolite.Asn1J2735.J2735;

public class IntersectionState
{
  public string Name { get; set; } = string.Empty;
  public IntersectionReferenceId Id { get; set; } = new();
  public BitString Status { get; set; } = new();
  public int? Moy { get; set; }
  public int? TimeStamp { get; set; }
  public ICollection<int> EnabledLanes { get; set; } = new List<int>();
  public ICollection<MovementState> States { get; set; } = new List<MovementState>();
  public ICollection<ConnectionManeuverAssist> ManeuverAssistList { get; set; } = new List<ConnectionManeuverAssist>();
}