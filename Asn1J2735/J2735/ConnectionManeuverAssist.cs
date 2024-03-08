namespace Econolite.Asn1J2735.J2735;
public class ConnectionManeuverAssist
{
  public int ConnectionID { get; set; }
  public int? QueueLength { get; set; }
  public int? AvailableStorageLength { get; set; }
  public bool? WaitOnStop { get; set; }
  public bool? PedBicycleDetect { get; set; }
}
