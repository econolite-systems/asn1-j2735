using Econolite.J2735_201603.DSRC;
using Oss.Asn1;

namespace Econolite.Ode.Domain.Asn1.J2735.Mapping;

public static class BsmMapping
{
    public static Econolite.Asn1J2735.J2735.MessageFrame ToDecode(this MessageFrame value)
    {
        var bsm = value.Value.Decoded as BasicSafetyMessage;
        return new Econolite.Asn1J2735.J2735.MessageFrame()
        {
            MessageId = 20,
            Value = bsm!.ToDecode()
        };
    }

    public static Econolite.Asn1J2735.J2735.BasicSafetyMessage ToDecode(this BasicSafetyMessage message)
    {
        return new Econolite.Asn1J2735.J2735.BasicSafetyMessage()
        {
            CoreData = message.CoreData.ToDecode()
        };
    }

    public static Econolite.Asn1J2735.J2735.BSMcoreData ToDecode(this BSMcoreData value)
    {
        return new Econolite.Asn1J2735.J2735.BSMcoreData()
        {
            MsgCnt = value.MsgCnt,
            Id = value.Id,
            SecMark = value.SecMark,
            Lat = value.Lat,
            Long = value.Long,
            Elev = value.Elev,
            Accuracy = value.Accuracy.ToDecode(),
            Transmission = value.Transmission.ToDecode(),
            Speed = value.Speed,
            Heading = value.Heading,
            Angle = value.Angle,
            AccelSet = value.AccelSet.ToDecode(),
            Brakes = value.Brakes.ToDecode(),
            Size = value.Size.ToDecode()
        };
    }

    public static Econolite.Asn1J2735.J2735.PositionalAccuracy ToDecode(this PositionalAccuracy value)
    {
        return new Econolite.Asn1J2735.J2735.PositionalAccuracy()
        {
            SemiMajor = value.SemiMajor,
            SemiMinor = value.SemiMinor,
            Orientation = value.Orientation
        };
    }
    
    public static Econolite.Asn1J2735.J2735.AccelerationSet4Way ToDecode(this AccelerationSet4Way value)
    {
        return new Econolite.Asn1J2735.J2735.AccelerationSet4Way()
        {
            Long = value.Long,
            Lat = value.Lat,
            Vert = value.Vert,
            Yaw = value.Yaw
        };
    }
    
    public static Econolite.Asn1J2735.J2735.BrakeSystemStatus ToDecode(this BrakeSystemStatus value)
    {
        return new Econolite.Asn1J2735.J2735.BrakeSystemStatus()
        {
            WheelBrakes = value.WheelBrakes.ToDecode(),
            Traction = value.Traction.ToDecode(),
            Abs = value.Abs.ToDecode(),
            Scs = value.Scs.ToDecode(),
            BrakeBoost = value.BrakeBoost.ToDecode(),
            AuxBrakes = value.AuxBrakes.ToDecode()
        };
    }

    public static Econolite.Asn1J2735.J2735.TractionControlStatus ToDecode(this TractionControlStatus value)
    {
        return (Econolite.Asn1J2735.J2735.TractionControlStatus) value;
    }
    
    public static Econolite.Asn1J2735.J2735.AntiLockBrakeStatus ToDecode(this AntiLockBrakeStatus value)
    {
        return (Econolite.Asn1J2735.J2735.AntiLockBrakeStatus) value;
    }
    
    public static Econolite.Asn1J2735.J2735.StabilityControlStatus ToDecode(this StabilityControlStatus value)
    {
        return (Econolite.Asn1J2735.J2735.StabilityControlStatus) value;
    }
    
    public static Econolite.Asn1J2735.J2735.BrakeBoostApplied ToDecode(this BrakeBoostApplied value)
    {
        return (Econolite.Asn1J2735.J2735.BrakeBoostApplied) value;
    }
    
    public static Econolite.Asn1J2735.J2735.AuxiliaryBrakeStatus ToDecode(this AuxiliaryBrakeStatus value)
    {
        return (Econolite.Asn1J2735.J2735.AuxiliaryBrakeStatus) value;
    }
    
    public static Econolite.Asn1J2735.J2735.VehicleSize ToDecode(this VehicleSize value)
    {
        return new Econolite.Asn1J2735.J2735.VehicleSize()
        {
            Width = value.Width,
            Length = value.Length
        };
    }
    
    private static Econolite.Asn1J2735.J2735.BitString ToDecode(this BitStringWithNamedBits value)
    {
        var bitArray = value.ToBitArray();
        var bitResult = new Econolite.Asn1J2735.J2735.BitString();
        var count = 0;

        foreach (bool bit in bitArray)
        {
            var name = (BrakeAppliedStatus)count;
            var key = Enum.GetName(typeof(BrakeAppliedStatus), name) ?? string.Empty;
            if (key != string.Empty)
            {
                bitResult.Add(key, bit);
            }
            count++;
        }

        return bitResult;
    }
}