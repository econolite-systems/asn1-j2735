namespace Econolite.Asn1J2735.J2735.TimStorage;

public class ComputedLane
{
    public int ReferenceLaneId { get; set; }
    public OffsetAxis OffsetXAxis { get; set; } = new();
    public OffsetAxis OffsetYAxis { get; set; } = new();
    public int RotateXY { get; set; }
    public int ScaleXaxis { get; set; }
    public int ScaleYaxis { get; set; }
}