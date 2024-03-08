using Econolite.J2735_201603.DSRC;
using Oss.Asn1;
using BitString = Econolite.Asn1J2735.J2735.BitString;
using IntersectionState = Econolite.J2735_201603.DSRC.IntersectionState;
using IntersectionStateList = Econolite.J2735_201603.DSRC.IntersectionStateList;
using MessageFrame = Econolite.J2735_201603.DSRC.MessageFrame;
using MovementEvent = Econolite.J2735_201603.DSRC.MovementEvent;
using MovementPhaseState = Econolite.J2735_201603.DSRC.MovementPhaseState;
using MovementState = Econolite.J2735_201603.DSRC.MovementState;

namespace Econolite.Ode.Domain.Asn1.J2735.Mapping;

public static class SpatMapping
{
    public static Econolite.Asn1J2735.J2735.MessageFrame ToDecode(this MessageFrame value)
    {
        var spat = value.Value.Decoded as SPAT;
        return new Econolite.Asn1J2735.J2735.MessageFrame()
        {
            MessageId = 19,
            Value = spat!.ToDecode()
        };
    }
    
    public static Econolite.Asn1J2735.J2735.Spat ToDecode(this SPAT value)
    {
        return new Econolite.Asn1J2735.J2735.Spat()
        {
            TimeStamp = value.TimeStamp,
            Name = value.Name,
            Intersections = value.Intersections.ToDecode()
        };
    }
    
    public static ICollection<Econolite.Asn1J2735.J2735.IntersectionState> ToDecode(this IntersectionStateList value)
    {
        return value.Select(intersectionState => intersectionState.ToDecode()).ToList();
    }
    
    public static Econolite.Asn1J2735.J2735.IntersectionState ToDecode(this IntersectionState value)
    {
        return new Econolite.Asn1J2735.J2735.IntersectionState()
        {
            Id = value.Id.ToDecode(),
            Status = value.Status.ToDecode(),
            States = value.States.ToDecode()
        };
    }
    
    public static Econolite.Asn1J2735.J2735.IntersectionReferenceId ToDecode(this IntersectionReferenceID value)
    {
        return new Econolite.Asn1J2735.J2735.IntersectionReferenceId()
        {
            Region = value.Region,
            Id = value.Id
        };
    }
    
    public static ICollection<Econolite.Asn1J2735.J2735.MovementState> ToDecode(this MovementList value)
    {
        return value.Select(movementState => movementState.ToDecode()).ToList();
    }

    public static Econolite.Asn1J2735.J2735.MovementState ToDecode(this MovementState value)
    {
        return new Econolite.Asn1J2735.J2735.MovementState()
        {
            SignalGroup = value.SignalGroup,
            StateTimeSpeed = value.StateTimeSpeed.ToDecode()
        };
    }
    
    public static ICollection<Econolite.Asn1J2735.J2735.MovementEvent> ToDecode(this MovementEventList value)
    {
        return value.Select(movementEvent => movementEvent.ToDecode()).ToList();
    }
    
    public static Econolite.Asn1J2735.J2735.MovementEvent ToDecode(this MovementEvent value)
    {
        return new Econolite.Asn1J2735.J2735.MovementEvent()
        {
            EventState = value.EventState.ToDecode(),
            Timing = value.Timing.ToDecode()
        };
    }
    
    public static Econolite.Asn1J2735.J2735.MovementPhaseState ToDecode(this MovementPhaseState value)
    {
        var result = Econolite.Asn1J2735.J2735.MovementPhaseState.Unavailable;
        
        switch (value)
        {
            case MovementPhaseState.Dark:
                result = Econolite.Asn1J2735.J2735.MovementPhaseState.Dark;
                break;
            case MovementPhaseState.PermissiveClearance:
                result = Econolite.Asn1J2735.J2735.MovementPhaseState.PermissiveClearance;
                break;
            case MovementPhaseState.PreMovement:
                result = Econolite.Asn1J2735.J2735.MovementPhaseState.PreMovement;
                break;
            case MovementPhaseState.ProtectedClearance:
                result = Econolite.Asn1J2735.J2735.MovementPhaseState.ProtectedClearance;
                break;
            case MovementPhaseState.CautionConflictingTraffic:
                result = Econolite.Asn1J2735.J2735.MovementPhaseState.CautionConflictingTraffic;
                break;
            case MovementPhaseState.PermissiveMovementAllowed:
                result = Econolite.Asn1J2735.J2735.MovementPhaseState.PermissiveMovementAllowed;
                break;
            case MovementPhaseState.ProtectedMovementAllowed:
                result = Econolite.Asn1J2735.J2735.MovementPhaseState.ProtectedMovementAllowed;
                break;
            case MovementPhaseState.StopAndRemain:
                result = Econolite.Asn1J2735.J2735.MovementPhaseState.StopAndRemain;
                break;
            case MovementPhaseState.StopThenProceed:
                result = Econolite.Asn1J2735.J2735.MovementPhaseState.StopThenProceed;
                break;
            default:
                result = Econolite.Asn1J2735.J2735.MovementPhaseState.Unavailable;
                break;
        }

        return result;
    }

    public static Econolite.Asn1J2735.J2735.TimeChangeDetails ToDecode(this TimeChangeDetails value)
    {
        return new Econolite.Asn1J2735.J2735.TimeChangeDetails()
        {
            MinEndTime = value.MinEndTime,
            MaxEndTime = value.MaxEndTime,
            LikelyTime = value.LikelyTime,
            Confidence = value.Confidence
        };
    }

    private static Econolite.Asn1J2735.J2735.BitString ToDecode(this BitStringWithNamedBits value)
    {
        var bitArray = value.ToBitArray();
        var bitResult = new BitString();
        var count = 0;

        foreach (bool bit in bitArray)
        {
            var name = (IntersectionStatusObject)count;
            var key = Enum.GetName(typeof(IntersectionStatusObject), name) ?? string.Empty;
            if (key != string.Empty)
            {
                bitResult.Add(key, bit);
            }
            count++;
        }

        return bitResult;
    }
    
}