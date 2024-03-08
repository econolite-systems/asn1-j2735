namespace Econolite.Asn1J2735.J2735;

  public enum MovementPhaseState
{
    // This state used for unknown or error
    Unavailable = 0,

    // The signal head is dark (unlit)
    Dark = 1,

    // Often called 'flashing red' in US
    // Driver Action:
    //  Stop vehicle at stop line or crosswalk
    //  Do not proceed unless it is safe
    // Note that the right to proceed either right or left when
    // it is safe may be contained in th lane description to 
    // handle what is called a 'right on red'
    StopThenProceed = 2,

    // e.g. called 'red light' in US
    // Driver Action:
    //  Stop vehicle at stop line.
    //  Do not proceed.
    // Note that the right to proceed either right or left when
    // it is safe may be contained in th lane description to 
    // handle what is called a 'right on red'
    StopAndRemain = 3,

    // Not used in the US, red+yellow partly in EU
    // Driver Action:
    //  Stop vehicle.
    //  Prepare to proceed (pending green)
    //  (Prepare for transition to green/go)
    PreMovement = 4,

    // Often called 'permissive green' in US
    // Driver Action:
    //  Proceed with caution,
    //  must yield to all conflicting traffic
    // Conflicting traffic may be present
    // in the intersection conflict area
    PermissiveMovementAllowed = 5,

    // Often called 'protected green' in US
    // Driver Action:
    //  Proceed, tossing caution to the wind,
    //  in indicated (allowed) direction
    ProtectedMovementAllowed = 6,

    // Often called 'permissive yellow' in US
    // Driver Action:
    //  Prepare to stop.
    //  Proceed if unable to stop,
    //  Clear Intersection.
    // Conflicting traffic may be present
    // in the intersection conflict area
    PermissiveClearance = 7,

    // Often called 'protected yellow' in US
    // Driver Action:
    //  Prepare to stop.
    //  Proceed if unable to stop,
    //  in indicated direction (to connected lane)
    //  Clear Intersection.
    ProtectedClearance = 8,

    // Often called 'flashing yellow' in US
    // Often used for extended periods of time
    // Driver Action:
    //  Proceed with caution,
    // Conflicting traffic may be present
    // in the intersection conflict area
    CautionConflictingTraffic = 9
}