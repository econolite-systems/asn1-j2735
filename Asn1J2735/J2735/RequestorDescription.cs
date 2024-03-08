namespace Econolite.Asn1J2735.J2735;

public class RequestorDescription
{
    public VehicleId Id { get; set; } = new();
    public RequestorType Type { get; set; } = new();
    public RequestorPositionVector Position { get; set; } = new();
    public string Name { get; set; } = string.Empty;
    public string RouteName { get; set; } = string.Empty;
    public BitString TransitStatus { get; set; } = new();
    public TransitVehicleOccupancy? TransitOccupancy { get; set; }
    public int? TransitSchedule { get; set; }
}