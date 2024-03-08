namespace Econolite.Asn1J2735.Models.Dsrc;

/// <summary>
/// Represents the schema type 'MUTCDCode' (ENUMERATED)
/// </summary>
[System.Serializable]
[System.Runtime.Serialization.DataContract(Namespace = "DSRC", Name = "MUTCDCode")]
public enum MUTCDCode
{
    [System.Runtime.Serialization.EnumMemberAttribute(Value = "none")]
    None = 0,
    [System.Runtime.Serialization.EnumMemberAttribute(Value = "regulatory")]
    Regulatory = 1,
    [System.Runtime.Serialization.EnumMemberAttribute(Value = "warning")]
    Warning = 2,
    [System.Runtime.Serialization.EnumMemberAttribute(Value = "maintenance")]
    Maintenance = 3,
    [System.Runtime.Serialization.EnumMemberAttribute(Value = "motoristService")]
    MotoristService = 4,
    [System.Runtime.Serialization.EnumMemberAttribute(Value = "guide")]
    Guide = 5,
    [System.Runtime.Serialization.EnumMemberAttribute(Value = "rec")]
    Rec = 6
}