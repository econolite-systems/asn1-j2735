namespace Econolite.Asn1J2735.J2735;

public class RestrictionClassAssignment
{
    public int Id { get; set; }
    public RestrictionUserTypeList Users { get; set; } = new();
}