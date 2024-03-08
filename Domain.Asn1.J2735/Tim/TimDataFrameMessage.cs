using Econolite.Asn1J2735.J2735;
using Econolite.Asn1J2735.J2735.TimStorage;

namespace Econolite.Asn1J2735.Tim;

public class TimDataFrameMessage
{
    public MsgIdType MsgId { get; set; } = new MsgIdType();
    public DateTime StartTime { get; set; }
    public int Duration { get; set; }
    public int Priority { get; set; } = 4;
    public IEnumerable<GeographicalPath> Regions { get; set; } = Array.Empty<GeographicalPath>();
    public Content Content { get; set; } = new Content();
}