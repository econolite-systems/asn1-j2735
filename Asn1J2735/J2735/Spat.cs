namespace Econolite.Asn1J2735.J2735;

public class Spat: IPdu
{
    public int? TimeStamp { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<IntersectionState> Intersections { get; set; } = new List<IntersectionState>();
}