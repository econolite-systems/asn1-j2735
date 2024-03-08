namespace Econolite.Asn1J2735.J2735;

public class SignalRequestPackage
{
    public SignalRequest Request { get; set; } = new();
    public int? Minute { get; set; }
    public int? Second { get; set; }
    public int? Duration { get; set; }
}