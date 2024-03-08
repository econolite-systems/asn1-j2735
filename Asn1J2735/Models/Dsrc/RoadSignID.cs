using Econolite.Asn1J2735.Models.Asn1;

namespace Econolite.Asn1J2735.Models.Dsrc;

public class RoadSignID
{
    public Position3D Position { get; set; }
    public HeadingSlice ViewAngle { get; set; }
    public MUTCDCode? MutcdCode { get; set; }
    public byte[] Crc { get; set; }
}