namespace Econolite.Asn1J2735.Models.Dsrc;

/// <summary>
/// Represents the schema type 'TravelerInfoType' (ENUMERATED)
/// </summary>
[System.Serializable]
[System.Runtime.Serialization.DataContract(Namespace = "DSRC", Name = "TravelerInfoType")]
public enum TravelerInfoType
{
    [System.Runtime.Serialization.EnumMemberAttribute(Value = "unknown")]
    Unknown = 0,
    [System.Runtime.Serialization.EnumMemberAttribute(Value = "advisory")]
    Advisory = 1,
    [System.Runtime.Serialization.EnumMemberAttribute(Value = "roadSignage")]
    RoadSignage = 2,
    [System.Runtime.Serialization.EnumMemberAttribute(Value = "commercialSignage")]
    CommercialSignage = 3
}