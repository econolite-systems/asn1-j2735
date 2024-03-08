namespace Econolite.Asn1J2735.J2735;

public class SignalStatusMessage : IPdu
{
    public int? TimeStamp { get; set; }
    public int Second { get; set; }
    public int? SequenceNumber { get; set; }
    public IEnumerable<SignalStatus> Status { get; set; } = new List<SignalStatus>();
}