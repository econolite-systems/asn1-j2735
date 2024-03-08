using System.Text.Json.Serialization;

namespace Econolite.Asn1J2735.J2735.TimStorage;

public class Position
{
    public string Lat { get; set; } = string.Empty;
    [JsonPropertyName("long")]
    public string Lon { get; set; } = string.Empty;
    public string? Elevation { get; set; }
}