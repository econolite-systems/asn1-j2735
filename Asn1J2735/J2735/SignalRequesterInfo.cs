namespace Econolite.Asn1J2735.J2735;

public class SignalRequesterInfo
{
    public VehicleId Id { get; set; } = new();
    public int Request { get; set; }
    public int SequenceNumber { get; set; }
    public BasicVehicleRole? Role { get; set; }
    public RequestorType TypeData { get; set; } = new();
}