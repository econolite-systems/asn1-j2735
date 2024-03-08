namespace Econolite.Asn1J2735.J2735;

public class SignalRequest
{
    public IntersectionReferenceId Id { get; set; } = new();
    public int RequestId { get; set; }
    public PriorityRequestType RequestType { get; set; }
    public IntersectionAccessPoint InBoundLane { get; set; } = new();
    public IntersectionAccessPoint OutBoundLane { get; set; } = new();
}