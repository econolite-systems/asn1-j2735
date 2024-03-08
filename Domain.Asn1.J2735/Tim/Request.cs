namespace Econolite.Asn1J2735.Tim;

public class Request
{
    public Guid Rsu { get; set; } = Guid.Empty;
    public TimMessageSnmp Snmp { get; set; } = new();
}
