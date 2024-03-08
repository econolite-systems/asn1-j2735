namespace Econolite.Asn1J2735.J2735;

public class TravelerInformation : IPdu
{
    public int MsgCnt { get; set; }
    public int? TimeStamp { get; set; }
    public byte[]? PacketID { get; set; }
    public string? UrlB { get; set; }
    public IEnumerable<TravelerDataFrame> DataFrames { get; set; } = Array.Empty<TravelerDataFrame>();
}