using Econolite.J2735_201603.DSRC;
using Oss.Asn1;
using BitString = Econolite.Asn1J2735.J2735.BitString;
using MessageFrame = Econolite.J2735_201603.DSRC.MessageFrame;
using SignalRequestMessage = Econolite.J2735_201603.DSRC.SignalRequestMessage;
using RequestorDescription = Econolite.J2735_201603.DSRC.RequestorDescription;
using SignalRequest = Econolite.J2735_201603.DSRC.SignalRequest;
using SignalRequestPackage = Econolite.J2735_201603.DSRC.SignalRequestPackage;
using TransitVehicleStatus = Econolite.J2735_201603.DSRC.TransitVehicleStatus;


namespace Econolite.Ode.Domain.Asn1.J2735.Mapping;

public static class SrmMapping
{
    public static Econolite.Asn1J2735.J2735.MessageFrame ToDecode(this MessageFrame value)
    {
        var srm = value.Value.Decoded as SignalRequestMessage;
        return new Econolite.Asn1J2735.J2735.MessageFrame()
        {
            MessageId = 30,
            Value = srm!.ToDecode()
        };
    }
    
    public static Econolite.Asn1J2735.J2735.SignalRequestMessage ToDecode(this SignalRequestMessage value)
    {
        return new Econolite.Asn1J2735.J2735.SignalRequestMessage()
        {
            TimeStamp = value.TimeStamp,
            Second = value.Second,
            SequenceNumber = value.SequenceNumber,
            Requests = value.Requests.ToDecode(),
            Requestor = value.Requestor.ToDecode()
        };
    }
    
    public static ICollection<Econolite.Asn1J2735.J2735.SignalRequestPackage> ToDecode(this SignalRequestList value)
    {
        return value.Select(signalRequestPackage => signalRequestPackage.ToDecode()).ToList();
    }
    
    public static Econolite.Asn1J2735.J2735.SignalRequestPackage ToDecode(this SignalRequestPackage value)
    {
        return new Econolite.Asn1J2735.J2735.SignalRequestPackage()
        {
            Request = value.Request.ToDecode(),
            Minute = value.Minute,
            Second = value.Second,
            Duration = value.Duration
        };
    }
    
    public static Econolite.Asn1J2735.J2735.SignalRequest ToDecode(this SignalRequest value)
    {
        return new Econolite.Asn1J2735.J2735.SignalRequest()
        {
            Id = value.Id.ToDecode(),
            RequestId = value.RequestID,
            RequestType = value.RequestType.ToDecode(),
            InBoundLane = value.InBoundLane.ToDecode(),
            OutBoundLane = value.OutBoundLane.ToDecode()
        };
    }
    
    public static Econolite.Asn1J2735.J2735.RequestorDescription ToDecode(this RequestorDescription value)
    {
        return new Econolite.Asn1J2735.J2735.RequestorDescription()
        {
            Id = value.Id.ToDecode(),
            Type = value.Type.ToDecode(),
            Position = value.Position.ToDecode(),
            Name = value.Name,
            RouteName = value.RouteName,
            TransitStatus = value.TransitStatus.ToDecode<TransitVehicleStatus>(),
            TransitOccupancy = value.TransitOccupancy.ToDecode(),
            TransitSchedule = value.TransitSchedule,
        };
    }

    public static Econolite.Asn1J2735.J2735.TransitVehicleOccupancy? ToDecode(this TransitVehicleOccupancy? value)
    {
        return value.HasValue ? (Econolite.Asn1J2735.J2735.TransitVehicleOccupancy) value : null;
    }
    
    private static Econolite.Asn1J2735.J2735.BitString ToDecode<T>(this BitStringWithNamedBits value) where T : Enum
    {
        var bitArray = value.ToBitArray();
        var bitResult = new BitString();
        var count = 0;

        foreach (bool bit in bitArray)
        {
            var name = (T)Enum.ToObject(typeof(T), count);;
            var key = Enum.GetName(typeof(T), name) ?? string.Empty;
            if (key != string.Empty)
            {
                bitResult.Add(key, bit);
            }
            count++;
        }

        return bitResult;
    }

    private static Econolite.Asn1J2735.J2735.PriorityRequestType ToDecode(this PriorityRequestType value)
    {
        return (Econolite.Asn1J2735.J2735.PriorityRequestType) value;
    }
    
    private static Econolite.Asn1J2735.J2735.RequestorPositionVector ToDecode(this RequestorPositionVector value)
    {
        return new Econolite.Asn1J2735.J2735.RequestorPositionVector()
        {
            Position = value.Position.ToDecode(),
            Heading = value.Heading,
            Speed = value.Speed.ToDecode()
        };
    }
    
    public static Econolite.Asn1J2735.J2735.Position3d ToDecode(this Position3D value)
    {
        return new Econolite.Asn1J2735.J2735.Position3d()
        {
            Elevation = (int?) value.Elevation,
            Latitude = value.Lat.ToDouble(),
            Longitude = value.Long.ToDouble()
        };
    }
    
    private static Econolite.Asn1J2735.J2735.TransmissionAndSpeed ToDecode(this TransmissionAndSpeed value)
    {
        return new Econolite.Asn1J2735.J2735.TransmissionAndSpeed()
        {
            Transmission = value.Transmisson.ToDecode(),
            Speed = value.Speed
        };
    }

    public static Econolite.Asn1J2735.J2735.TransmissionState ToDecode(this TransmissionState value)
    {
        return (Econolite.Asn1J2735.J2735.TransmissionState) value;
    }

    public static Econolite.Asn1J2735.J2735.SignalStatusMessage ToSsm(
        this IEnumerable<Econolite.Asn1J2735.J2735.SignalRequestMessage> value,
        IDictionary<int, Econolite.Asn1J2735.J2735.PrioritizationResponseStatus> status)
    {
        var signalStatus = value.Select(srm =>
        {
            var statusList = srm.Requests.Select(signalRequestPackage =>
                signalRequestPackage.ToSsm(srm.Requestor, status[signalRequestPackage.Request.RequestId], srm.SequenceNumber)).ToList();
            var signalStatus = new Econolite.Asn1J2735.J2735.SignalStatus()
            {
                SequenceNumber = srm.SequenceNumber.Value,
                Id = srm.Requests.FirstOrDefault()?.Request.Id!,
                SigStatus = statusList
            };
            return signalStatus;
        });
        
        return new Econolite.Asn1J2735.J2735.SignalStatusMessage()
        {
            TimeStamp = value.FirstOrDefault()?.TimeStamp,
            Second = value.First().Second,
            SequenceNumber = value.FirstOrDefault()?.SequenceNumber,
            Status = signalStatus.ToList()
        };
    }
    
    public static Econolite.Asn1J2735.J2735.SignalStatusMessage ToSsm(this Econolite.Asn1J2735.J2735.SignalRequestMessage value, Econolite.Asn1J2735.J2735.PrioritizationResponseStatus status)
    {
        
        var statusList = value.Requests.Select(signalRequestPackage => signalRequestPackage.ToSsm(value.Requestor, status, value.SequenceNumber)).ToList();
        
        var signalStatus = new Econolite.Asn1J2735.J2735.SignalStatus()
        {
            SequenceNumber = value.SequenceNumber.Value,
            Id = value.Requests.FirstOrDefault()?.Request.Id!,
            SigStatus = statusList
        };
        
        return new Econolite.Asn1J2735.J2735.SignalStatusMessage()
        {
            TimeStamp = value.TimeStamp,
            Second = value.Second,
            SequenceNumber = value.SequenceNumber,
            Status = new List<Econolite.Asn1J2735.J2735.SignalStatus>() {signalStatus}
        };
    }
    
    public static Econolite.Asn1J2735.J2735.SignalStatusPackage ToSsm(this Econolite.Asn1J2735.J2735.SignalRequestPackage value, Econolite.Asn1J2735.J2735.RequestorDescription requestor, Econolite.Asn1J2735.J2735.PrioritizationResponseStatus status, int? SequenceNumber = null)
    {
        return new Econolite.Asn1J2735.J2735.SignalStatusPackage()
        {
            Requester = value.Request.ToSsm(requestor, SequenceNumber),
            InboundOn = value.Request.InBoundLane,
            OutboundOn = value.Request.OutBoundLane,
            Minute = value.Minute,
            Second = value.Second,
            Duration = value.Duration,
            Status = status
        };
    }
    
    public static Econolite.Asn1J2735.J2735.SignalRequesterInfo ToSsm(this Econolite.Asn1J2735.J2735.SignalRequest value, Econolite.Asn1J2735.J2735.RequestorDescription requestor, int? SequenceNumber = null)
    {
        return new Econolite.Asn1J2735.J2735.SignalRequesterInfo()
        {
            Id = requestor.Id,
            Request = value.RequestId,
            TypeData = requestor.Type,
            SequenceNumber = SequenceNumber.Value,
            Role = requestor.Type.Role
        };
    }
}