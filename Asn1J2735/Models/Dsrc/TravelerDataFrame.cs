namespace Econolite.Asn1J2735.Models.Dsrc;

public class TravelerDataFrame
{
    /// <summary>Field 'sspTimRights'</summary>
    [System.Runtime.Serialization.DataMember(Name = "sspTimRights", IsRequired = true)]
    public int SspTimRights { get; set; }
    /// <summary>Field 'frameType'</summary>
    [System.Runtime.Serialization.DataMember(Name = "frameType", IsRequired = true)]
    public TravelerInfoType FrameType { get; set; }
    /// <summary>Field 'msgId'</summary>
    [System.Runtime.Serialization.DataMember(Name = "msgId", IsRequired = true)]
    public MsgIdType MsgId { get; set; }
    /// <summary>Field 'startYear'</summary>
    [System.Runtime.Serialization.DataMember(Name = "startYear")]
    public int? StartYear { get; set; }
    /// <summary>Field 'startTime'</summary>
    [System.Runtime.Serialization.DataMember(Name = "startTime", IsRequired = true)]
    public int StartTime { get; set; }
    /// <summary>Field 'duratonTime'</summary>
    [System.Runtime.Serialization.DataMember(Name = "duratonTime", IsRequired = true)]
    public int DuratonTime { get; set; }
    /// <summary>Field 'priority'</summary>
    [System.Runtime.Serialization.DataMember(Name = "priority", IsRequired = true)]
    public int Priority { get; set; }
    /// <summary>Field 'sspLocationRights'</summary>
    [System.Runtime.Serialization.DataMember(Name = "sspLocationRights", IsRequired = true)]
    public int SspLocationRights { get; set; }
    
   
}

public class MsgIdType
{
}