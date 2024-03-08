using Econolite.Asn1J2735.J2735.TimStorage;

namespace Econolite.Asn1J2735.J2735;

public class TravelerDataFrame
{
    public int SspTimRights { get; set; }
    public TravelerInfoType FrameType { get; set; }
    public MsgIdType MsgId { get; set; } = new();
    public int? StartYear { get; set; }
    public int StartTime { get; set; }
    public int DurationTime { get; set; }
    public int Priority { get; set; }
    public int SspLocationRights { get; set; }
    public List<GeographicalPath> Regions { get; set; } = new();
    public int SspMsgRights1 { get; set; }
    public int SspMsgRights2 { get; set; }
    public Content? Content { get; set; }
    public string? Url { get; set; }
}