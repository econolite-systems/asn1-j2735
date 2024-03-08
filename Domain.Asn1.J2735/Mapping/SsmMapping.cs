using Econolite.Asn1J2735.J2735;
using Econolite.J2735_201603.DSRC;
using Oss.Asn1;
using BasicVehicleRole = Econolite.J2735_201603.DSRC.BasicVehicleRole;
using MessageFrame = Econolite.J2735_201603.DSRC.MessageFrame;
using SignalStatusMessage = Econolite.J2735_201603.DSRC.SignalStatusMessage;
using SignalStatus = Econolite.J2735_201603.DSRC.SignalStatus;
using SignalStatusList = Econolite.J2735_201603.DSRC.SignalStatusList;
using SignalStatusPackage = Econolite.J2735_201603.DSRC.SignalStatusPackage;
using SignalRequesterInfo = Econolite.J2735_201603.DSRC.SignalRequesterInfo;
using IntersectionAccessPoint = Econolite.J2735_201603.DSRC.IntersectionAccessPoint;
using PrioritizationResponseStatus = Econolite.J2735_201603.DSRC.PrioritizationResponseStatus;
using RequestImportanceLevel = Econolite.J2735_201603.DSRC.RequestImportanceLevel;
using RequestorType = Econolite.J2735_201603.DSRC.RequestorType;
using RequestSubRole = Econolite.J2735_201603.DSRC.RequestSubRole;
using VehicleType = Econolite.J2735_201603.DSRC.VehicleType;

namespace Econolite.Ode.Domain.Asn1.J2735.Mapping;

public static class SsmMapping
{
    public static Econolite.Asn1J2735.J2735.MessageFrame ToDecode(this MessageFrame value)
    {
        var ssm = value.Value.Decoded as SignalStatusMessage;
        return new Econolite.Asn1J2735.J2735.MessageFrame()
        {
            MessageId = 30,
            Value = ssm!.ToDecode()
        };
    }
    
    public static Econolite.Asn1J2735.J2735.SignalStatusMessage ToDecode(this SignalStatusMessage value)
    {
        return new Econolite.Asn1J2735.J2735.SignalStatusMessage()
        {
            TimeStamp = value.TimeStamp,
            Second = value.Second,
            SequenceNumber = value.SequenceNumber,
            Status = value.Status.ToDecode()
        };
    }
    
    public static ICollection<Econolite.Asn1J2735.J2735.SignalStatus> ToDecode(this SignalStatusList value)
    {
        return value.Select(signalStatus => signalStatus.ToDecode()).ToList();
    }
    
    public static Econolite.Asn1J2735.J2735.SignalStatus ToDecode(this SignalStatus value)
    {
        return new Econolite.Asn1J2735.J2735.SignalStatus()
        {
            SequenceNumber = value.SequenceNumber,
            Id = value.Id.ToDecode(),
            SigStatus = value.SigStatus.ToDecode()
        };
    }
    
    public static ICollection<Econolite.Asn1J2735.J2735.SignalStatusPackage> ToDecode(this SignalStatusPackageList value)
    {
        return value.Select(signalStatusPackage => signalStatusPackage.ToDecode()).ToList();
    }

    public static Econolite.Asn1J2735.J2735.SignalStatusPackage ToDecode(this SignalStatusPackage value)
    {
        return new Econolite.Asn1J2735.J2735.SignalStatusPackage()
        {
            Requester = value.Requester.ToDecode(),
            InboundOn = value.InboundOn.ToDecode(),
            OutboundOn = value.OutboundOn.ToDecode(),
            Minute = value.Minute,
            Second = value.Second,
            Duration = value.Duration,
            Status = value.Status.ToDecode()
        };
    }
    
    public static Econolite.Asn1J2735.J2735.SignalRequesterInfo ToDecode(this SignalRequesterInfo value)
    {
        return new Econolite.Asn1J2735.J2735.SignalRequesterInfo()
        {
            Id = value.Id.ToDecode(),
            Request = value.Request,
            SequenceNumber = value.SequenceNumber,
            Role = value.Role.ToDecode(),
            TypeData = value.TypeData.ToDecode()
        };
    }
    
    public static Econolite.Asn1J2735.J2735.IntersectionAccessPoint ToDecode(this IntersectionAccessPoint value)
    {
        return new Econolite.Asn1J2735.J2735.IntersectionAccessPoint()
        {
            Lane = value.Lane,
            Approach = value.Approach,
            Connection = value.Connection
        };
    }
    
    public static Econolite.Asn1J2735.J2735.PrioritizationResponseStatus ToDecode(this PrioritizationResponseStatus value)
    {
        return (Econolite.Asn1J2735.J2735.PrioritizationResponseStatus) value;
    }

    public static Econolite.Asn1J2735.J2735.VehicleId ToDecode(this VehicleID value)
    {
        return new VehicleId()
        {
            EntityId = value.EntityID,
            StationId = value.StationID
        };
    }
    
    public static Econolite.Asn1J2735.J2735.BasicVehicleRole? ToDecode(this BasicVehicleRole? value)
    {
        return value.HasValue ? (Econolite.Asn1J2735.J2735.BasicVehicleRole) value : null;
    }
    
    public static Econolite.Asn1J2735.J2735.RequestorType ToDecode(this RequestorType value)
    {
        return new Econolite.Asn1J2735.J2735.RequestorType()
        {
            Role = value.Role.ToDecode(),
            Subrole = value.Subrole.ToDecode(),
            Iso3883 = value.Iso3883,
            HpmsType = value.HpmsType.ToDecode()
        };
    }
    
    public static Econolite.Asn1J2735.J2735.BasicVehicleRole ToDecode(this BasicVehicleRole value)
    {
        return (Econolite.Asn1J2735.J2735.BasicVehicleRole) value;
    }
    
    public static Econolite.Asn1J2735.J2735.RequestSubRole? ToDecode(this RequestSubRole? value)
    {
        return value.HasValue ? (Econolite.Asn1J2735.J2735.RequestSubRole) value : null;
    }
    
    public static Econolite.Asn1J2735.J2735.RequestImportanceLevel? ToDecode(this RequestImportanceLevel? value)
    {
        return value.HasValue ? (Econolite.Asn1J2735.J2735.RequestImportanceLevel) value : null;
    }
    
    public static Econolite.Asn1J2735.J2735.VehicleType? ToDecode(this VehicleType? value)
    {
        return value.HasValue ? (Econolite.Asn1J2735.J2735.VehicleType) value : null;
    }
    public static MessageFrame ToSsmEncode(this Econolite.Asn1J2735.J2735.MessageFrame value)
    {
        var ssm = value.Value as Econolite.Asn1J2735.J2735.SignalStatusMessage;
        return new MessageFrame()
        {
            MessageId = 30,
            Value = ssm!.ToEncode()
        };
    }
    
    public static OpenType ToEncode(this Econolite.Asn1J2735.J2735.SignalStatusMessage value)
    {
        var signalStatusMessage = new SignalStatusMessage()
        {
            TimeStamp = value.TimeStamp,
            Second = value.Second,
            SequenceNumber = value.SequenceNumber,
            Status = value.Status.ToEncode()
        };
        return new OpenType(signalStatusMessage);
    }
    
    public static SignalStatusList ToEncode(this IEnumerable<Econolite.Asn1J2735.J2735.SignalStatus> value)
    {
        return new SignalStatusList(value.Select(signalStatus => signalStatus.ToEncode()));
    }
    
    public static SignalStatus ToEncode(this Econolite.Asn1J2735.J2735.SignalStatus value)
    {
        return new SignalStatus()
        {
            SequenceNumber = value.SequenceNumber,
            Id = value.Id.ToEncode(),
            SigStatus = value.SigStatus.ToEncode()
        };
    }
    
    public static IntersectionReferenceID ToEncode(this Econolite.Asn1J2735.J2735.IntersectionReferenceId value)
    {
        return new IntersectionReferenceID()
        {
            Region = value.Region,
            Id = value.Id
        };
    }
    
    public static SignalStatusPackageList ToEncode(this IEnumerable<Econolite.Asn1J2735.J2735.SignalStatusPackage> value)
    {
        ;
        return new SignalStatusPackageList(value.Select(signalStatusPackage => signalStatusPackage.ToEncode()));
    }

    public static SignalStatusPackage ToEncode(this Econolite.Asn1J2735.J2735.SignalStatusPackage value)
    {
        return new SignalStatusPackage()
        {
            Requester = value.Requester.ToEncode(),
            InboundOn = value.InboundOn.ToEncode(),
            OutboundOn = value.OutboundOn.ToEncode(),
            Minute = value.Minute,
            Second = value.Second,
            Duration = value.Duration,
            Status = value.Status.ToEncode()
        };
    }
    
    public static SignalRequesterInfo ToEncode(this Econolite.Asn1J2735.J2735.SignalRequesterInfo value)
    {
        return new SignalRequesterInfo()
        {
            Id = value.Id.ToEncode(),
            Request = value.Request,
            SequenceNumber = value.SequenceNumber,
            Role = value.Role.ToEncode(),
            TypeData = value.TypeData.ToEncode()
        };
    }
    
    public static IntersectionAccessPoint ToEncode(this Econolite.Asn1J2735.J2735.IntersectionAccessPoint value)
    {
        return new IntersectionAccessPoint()
        {
            Lane = value.Lane,
            Approach = value.Approach,
            Connection = value.Connection
        };
    }
    
    public static PrioritizationResponseStatus ToEncode(this Econolite.Asn1J2735.J2735.PrioritizationResponseStatus value)
    {
        return (PrioritizationResponseStatus) value;
    }

    public static VehicleID ToEncode(this VehicleId value)
    {
        return new VehicleID()
        {
            EntityID = value.EntityId,
            StationID = value.StationId
        };
    }
    
    public static BasicVehicleRole? ToEncode(this Econolite.Asn1J2735.J2735.BasicVehicleRole? value)
    {
        return value.HasValue ? (BasicVehicleRole) value : null;
    }
    
    public static RequestorType ToEncode(this Econolite.Asn1J2735.J2735.RequestorType value)
    {
        return new RequestorType()
        {
            Role = value.Role.ToEncode(),
            Subrole = value.Subrole.ToEncode(),
            Iso3883 = value.Iso3883,
            HpmsType = value.HpmsType.ToEncode()
        };
    }
    
    public static BasicVehicleRole ToEncode(this Econolite.Asn1J2735.J2735.BasicVehicleRole value)
    {
        return (BasicVehicleRole) value;
    }
    
    public static RequestSubRole? ToEncode(this Econolite.Asn1J2735.J2735.RequestSubRole? value)
    {
        return value.HasValue ? (RequestSubRole) value : null;
    }
    
    public static RequestImportanceLevel? ToEncode(this Econolite.Asn1J2735.J2735.RequestImportanceLevel? value)
    {
        return value.HasValue ? (RequestImportanceLevel) value : null;
    }
    
    public static VehicleType? ToEncode(this Econolite.Asn1J2735.J2735.VehicleType? value)
    {
        return value.HasValue ? (VehicleType) value : null;
    }
}