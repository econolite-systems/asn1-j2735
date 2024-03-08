namespace Econolite.Asn1J2735.Tim;

public class RequestMessage
{
    public Request Request { get; set; } = new();
    public TimMessage Tim { get; set; } = new();
}