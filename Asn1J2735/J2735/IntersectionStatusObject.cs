namespace Econolite.Asn1J2735.J2735;

public enum IntersectionStatusObject
{
    ManualControlIsEnabled = 0,
    StopTimeIsActivated = 1,
    FailureFlash = 2,
    PreemptIsActive = 3,
    SignalPriorityIsActive = 4,
    FixedTimeOperation = 5,
    TrafficDependentOperation = 6,
    StandbyOperation = 7,
    FailureMode = 8,
    Off = 9,
    RecentMAPmessageUpdate = 10,
    RecentChangeInMAPassignedLanesIDsUsed = 11,
    NoValidMAPisAvailableAtThisTime = 12,
    NoValidSPATisAvailableAtThisTime = 13
}