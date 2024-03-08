namespace Econolite.Asn1J2735.J2735;

public class LaneTypeAttributes
{
    public BitString Vehicle { get; set; } = new();
    public BitString Crosswalk { get; set; } = new();
    public BitString BikeLane { get; set; } = new();
    public BitString Sidewalk { get; set; } = new();
    public BitString Median { get; set; } = new();
    public BitString Striping { get; set; } = new();
    public BitString TrackedVehicle { get; set; } = new();
    public BitString Parking { get; set; } = new();
}