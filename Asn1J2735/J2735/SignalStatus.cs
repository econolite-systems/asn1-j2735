namespace Econolite.Asn1J2735.J2735;

public class SignalStatus
{
    public int SequenceNumber { get; set; }
    public IntersectionReferenceId Id { get; set; } = new();
    public IEnumerable<SignalStatusPackage> SigStatus { get; set; } = Array.Empty<SignalStatusPackage>();
}