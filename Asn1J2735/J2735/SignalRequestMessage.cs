namespace Econolite.Asn1J2735.J2735;

public class SignalRequestMessage : IPdu
{
    public int? TimeStamp { get; set; }
    public int Second { get; set; }
    public int? SequenceNumber { get; set; }
    public ICollection<SignalRequestPackage> Requests { get; set; } = Array.Empty<SignalRequestPackage>();
    public RequestorDescription Requestor { get; set; } = new();
}