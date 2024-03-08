namespace Econolite.Asn1J2735.Tim;

public class TimMessageSnmp
{
    public string RsuId { get; set; } = string.Empty;
    public int Msgid { get; set; } = 31;
    public int Mode { get; set; } = 1;
    public int Channel { get; set; } = 178;
    public int Interval { get; set; } = 5;
    public DateTime DeliveryStart { get; set; }
    public DateTime DeliveryStop { get; set; }
    public bool Enable { get; set; } = true;
    public int Status { get; set; }
}