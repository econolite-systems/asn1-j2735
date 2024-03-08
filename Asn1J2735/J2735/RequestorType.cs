namespace Econolite.Asn1J2735.J2735;

public class RequestorType
{
    public BasicVehicleRole Role { get; set; }
    public RequestSubRole? Subrole { get; set; }
    public RequestImportanceLevel? Request { get; set; }
    public int? Iso3883 { get; set; }
    public VehicleType? HpmsType { get; set; }
}