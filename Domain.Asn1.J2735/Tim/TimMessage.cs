namespace Econolite.Asn1J2735.Tim;

public class TimMessage
{
    public int MsgCnt { get; set; }
    public DateTime TimeStamp { get; set; }
    public string UrlB { get; set; } = string.Empty;
    public string PacketId { get; set; } = string.Empty;
    public IEnumerable<TimDataFrameMessage> DataFrames { get; set; } = new List<TimDataFrameMessage>();
}