namespace Econolite.Asn1J2735.J2735;

public enum PrioritizationResponseStatus
{
    Unknown = 0,
    Requested = 1,
    Processing = 2,
    WatchOtherTraffic = 3,
    Granted = 4,
    Rejected = 5,
    MaxPresence = 6,
    ReserviceLocked = 7
}