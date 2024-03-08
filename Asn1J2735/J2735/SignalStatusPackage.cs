namespace Econolite.Asn1J2735.J2735;

public class SignalStatusPackage
{
    public SignalRequesterInfo Requester { get; set; } = new();
    public IntersectionAccessPoint InboundOn { get; set; } = new();
    public IntersectionAccessPoint OutboundOn { get; set; } = new();
    public int? Minute { get; set; }
    public int? Second { get; set; }
    public int? Duration { get; set; }
    public PrioritizationResponseStatus Status { get; set; }
}