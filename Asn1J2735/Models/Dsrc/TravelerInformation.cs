namespace Econolite.Asn1J2735.Models.Dsrc;

public class TravelerInformation
{
    /// <summary>Field 'msgCnt'</summary>
    [System.Runtime.Serialization.DataMember(Name = "msgCnt", IsRequired = true)]
    public int MsgCnt { get; set; }
    /// <summary>Field 'timeStamp'</summary>
    [System.Runtime.Serialization.DataMember(Name = "timeStamp")]
    public int? TimeStamp { get; set; }
    /// <summary>Field 'packetID'</summary>
    [System.Runtime.Serialization.DataMember(Name = "packetID")]
    public byte[] PacketID { get; set; }
    /// <summary>Field 'urlB'</summary>
    [System.Runtime.Serialization.DataMember(Name = "urlB")]
    public string UrlB { get; set; }
    /// <summary>Field 'dataFrames'</summary>
    [System.Runtime.Serialization.DataMember(Name = "dataFrames", IsRequired = true)]
    public IEnumerable<TravelerDataFrame> DataFrames { get; set; }
}