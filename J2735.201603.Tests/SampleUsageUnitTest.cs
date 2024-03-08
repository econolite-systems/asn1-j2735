namespace Econolite.J2735_201603;

public class SampleUsageUnitTest
{
    [Fact]
    public void Test1()
    {
        int failures = 0;
        Econolite.J2735_201603.PerUnalignedCodec codec = new Econolite.J2735_201603.PerUnalignedCodec();

        if (!MessageFrameSample.EncodeDecodeAndPrint(codec, MessageFrameSample.CreateMockObject(), "MockObject"))
        {
            failures++;
        }

        if (failures > 0)
        {
            System.Console.WriteLine(failures + " values failed.");
        }
        else
        {
            System.Console.WriteLine("All values encoded and decoded successfully.");
        }
    }
}

/// <summary>
/// Define sample code for the ASN.1 type 'MessageFrame' defined in the 'DSRC' ASN.1 module.
/// </summary>
public static class MessageFrameSample
{
    /// <summary>
    /// Creates a mock sample value.
    /// </summary>
    public static Econolite.J2735_201603.DSRC.MessageFrame CreateMockObject()
    {
        Econolite.J2735_201603.DSRC.MessageFrame pdu = new Econolite.J2735_201603.DSRC.MessageFrame();
        pdu.MessageId = 20;
        pdu.Value = new Oss.Asn1.OpenType(new Econolite.J2735_201603.DSRC.BasicSafetyMessage());
        Econolite.J2735_201603.DSRC.BasicSafetyMessage obj1BasicSafetyMessage = (pdu.Value.Decoded as Econolite.J2735_201603.DSRC.BasicSafetyMessage)!;
        obj1BasicSafetyMessage.CoreData = new Econolite.J2735_201603.DSRC.BSMcoreData();
        obj1BasicSafetyMessage.CoreData.MsgCnt = 0;
        obj1BasicSafetyMessage.CoreData.Id = new byte[] {
            0x00, 0x00, 0x00, 0x00
        };
        obj1BasicSafetyMessage.CoreData.SecMark = 0;
        obj1BasicSafetyMessage.CoreData.Lat = -900000000;
        obj1BasicSafetyMessage.CoreData.Long = -1799999999;
        obj1BasicSafetyMessage.CoreData.Elev = -4096;
        obj1BasicSafetyMessage.CoreData.Accuracy = new Econolite.J2735_201603.DSRC.PositionalAccuracy();
        obj1BasicSafetyMessage.CoreData.Accuracy.SemiMajor = 0;
        obj1BasicSafetyMessage.CoreData.Accuracy.SemiMinor = 0;
        obj1BasicSafetyMessage.CoreData.Accuracy.Orientation = 0;
        obj1BasicSafetyMessage.CoreData.Transmission = Econolite.J2735_201603.DSRC.TransmissionState.Neutral;
        obj1BasicSafetyMessage.CoreData.Speed = 0;
        obj1BasicSafetyMessage.CoreData.Heading = 0;
        obj1BasicSafetyMessage.CoreData.Angle = -126;
        obj1BasicSafetyMessage.CoreData.AccelSet = new Econolite.J2735_201603.DSRC.AccelerationSet4Way();
        obj1BasicSafetyMessage.CoreData.AccelSet.Long = -2000;
        obj1BasicSafetyMessage.CoreData.AccelSet.Lat = -2000;
        obj1BasicSafetyMessage.CoreData.AccelSet.Vert = 127;
        obj1BasicSafetyMessage.CoreData.AccelSet.Yaw = 32767;
        obj1BasicSafetyMessage.CoreData.Brakes = new Econolite.J2735_201603.DSRC.BrakeSystemStatus();
        obj1BasicSafetyMessage.CoreData.Brakes.WheelBrakes = new Oss.Asn1.BitStringWithNamedBits (
            new byte[] {
                0xC0
            }, 2
        );
        obj1BasicSafetyMessage.CoreData.Brakes.Traction = Econolite.J2735_201603.DSRC.TractionControlStatus.Unavailable;
        obj1BasicSafetyMessage.CoreData.Brakes.Abs = Econolite.J2735_201603.DSRC.AntiLockBrakeStatus.Unavailable;
        obj1BasicSafetyMessage.CoreData.Brakes.Scs = Econolite.J2735_201603.DSRC.StabilityControlStatus.Unavailable;
        obj1BasicSafetyMessage.CoreData.Brakes.BrakeBoost = Econolite.J2735_201603.DSRC.BrakeBoostApplied.Unavailable;
        obj1BasicSafetyMessage.CoreData.Brakes.AuxBrakes = Econolite.J2735_201603.DSRC.AuxiliaryBrakeStatus.Unavailable;
        obj1BasicSafetyMessage.CoreData.Size = new Econolite.J2735_201603.DSRC.VehicleSize();
        obj1BasicSafetyMessage.CoreData.Size.Width = 0;
        obj1BasicSafetyMessage.CoreData.Size.Length = 0;
        obj1BasicSafetyMessage.PartII = new Econolite.J2735_201603.DSRC.BasicSafetyMessage.PartIIType();
        #region fill 'obj1BasicSafetyMessage.PartII' list
        {
            Econolite.J2735_201603.DSRC.BasicSafetyMessage.PartIIType list1PartIiType = obj1BasicSafetyMessage.PartII;

            Econolite.J2735_201603.DSRC.PartIIcontent elem1PartIIcontent0 = new Econolite.J2735_201603.DSRC.PartIIcontent();
            elem1PartIIcontent0.PartIIId = 0;
            elem1PartIIcontent0.PartIIValue = new Oss.Asn1.OpenType(new Econolite.J2735_201603.DSRC.VehicleSafetyExtensions());
            Econolite.J2735_201603.DSRC.VehicleSafetyExtensions obj2VehicleSafetyExtensions = elem1PartIIcontent0.PartIIValue.Decoded as Econolite.J2735_201603.DSRC.VehicleSafetyExtensions ?? throw new InvalidOperationException();
            obj2VehicleSafetyExtensions.Events = new Oss.Asn1.BitStringWithNamedBits (
                new byte[] {
                    0xC0
                }, 2
            );
            obj2VehicleSafetyExtensions.PathHistory = new Econolite.J2735_201603.DSRC.PathHistory();
            obj2VehicleSafetyExtensions.PathHistory.InitialPosition = new Econolite.J2735_201603.DSRC.FullPositionVector();
            obj2VehicleSafetyExtensions.PathHistory.InitialPosition.UtcTime = new Econolite.J2735_201603.DSRC.DDateTime();
            obj2VehicleSafetyExtensions.PathHistory.InitialPosition.UtcTime.Year = 0;
            obj2VehicleSafetyExtensions.PathHistory.InitialPosition.UtcTime.Month = 0;
            obj2VehicleSafetyExtensions.PathHistory.InitialPosition.UtcTime.Day = 0;
            obj2VehicleSafetyExtensions.PathHistory.InitialPosition.UtcTime.Hour = 0;
            obj2VehicleSafetyExtensions.PathHistory.InitialPosition.UtcTime.Minute = 0;
            obj2VehicleSafetyExtensions.PathHistory.InitialPosition.UtcTime.Second = 0;
            obj2VehicleSafetyExtensions.PathHistory.InitialPosition.UtcTime.Offset = 840;
            obj2VehicleSafetyExtensions.PathHistory.InitialPosition.Long = -1799999999;
            obj2VehicleSafetyExtensions.PathHistory.InitialPosition.Lat = -900000000;
            obj2VehicleSafetyExtensions.PathHistory.InitialPosition.Elevation = -4096;
            obj2VehicleSafetyExtensions.PathHistory.InitialPosition.Heading = 0;
            obj2VehicleSafetyExtensions.PathHistory.InitialPosition.Speed = new Econolite.J2735_201603.DSRC.TransmissionAndSpeed();
            obj2VehicleSafetyExtensions.PathHistory.InitialPosition.Speed.Transmisson = Econolite.J2735_201603.DSRC.TransmissionState.Neutral;
            obj2VehicleSafetyExtensions.PathHistory.InitialPosition.Speed.Speed = 0;
            obj2VehicleSafetyExtensions.PathHistory.InitialPosition.PosAccuracy = new Econolite.J2735_201603.DSRC.PositionalAccuracy();
            obj2VehicleSafetyExtensions.PathHistory.InitialPosition.PosAccuracy.SemiMajor = 0;
            obj2VehicleSafetyExtensions.PathHistory.InitialPosition.PosAccuracy.SemiMinor = 0;
            obj2VehicleSafetyExtensions.PathHistory.InitialPosition.PosAccuracy.Orientation = 0;
            obj2VehicleSafetyExtensions.PathHistory.InitialPosition.TimeConfidence = Econolite.J2735_201603.DSRC.TimeConfidence.Unavailable;
            obj2VehicleSafetyExtensions.PathHistory.InitialPosition.PosConfidence = new Econolite.J2735_201603.DSRC.PositionConfidenceSet();
            obj2VehicleSafetyExtensions.PathHistory.InitialPosition.PosConfidence.Pos = Econolite.J2735_201603.DSRC.PositionConfidence.Unavailable;
            obj2VehicleSafetyExtensions.PathHistory.InitialPosition.PosConfidence.Elevation = Econolite.J2735_201603.DSRC.ElevationConfidence.Unavailable;
            obj2VehicleSafetyExtensions.PathHistory.InitialPosition.SpeedConfidence = new Econolite.J2735_201603.DSRC.SpeedandHeadingandThrottleConfidence();
            obj2VehicleSafetyExtensions.PathHistory.InitialPosition.SpeedConfidence.Heading = Econolite.J2735_201603.DSRC.HeadingConfidence.Unavailable;
            obj2VehicleSafetyExtensions.PathHistory.InitialPosition.SpeedConfidence.Speed = Econolite.J2735_201603.DSRC.SpeedConfidence.Unavailable;
            obj2VehicleSafetyExtensions.PathHistory.InitialPosition.SpeedConfidence.Throttle = Econolite.J2735_201603.DSRC.ThrottleConfidence.Unavailable;
            obj2VehicleSafetyExtensions.PathHistory.CurrGNSSstatus = new Oss.Asn1.BitStringWithNamedBits (
                new byte[] {
                    0xC0
                }, 2
            );
            obj2VehicleSafetyExtensions.PathHistory.CrumbData = new Econolite.J2735_201603.DSRC.PathHistoryPointList();
            #region fill 'obj2VehicleSafetyExtensions.PathHistory.CrumbData' list
            {
                Econolite.J2735_201603.DSRC.PathHistoryPointList list2PathHistoryPointList = obj2VehicleSafetyExtensions.PathHistory.CrumbData;

                Econolite.J2735_201603.DSRC.PathHistoryPoint elem2PathHistoryPoint_0 = new Econolite.J2735_201603.DSRC.PathHistoryPoint();
                elem2PathHistoryPoint_0.LatOffset = 131071;
                elem2PathHistoryPoint_0.LonOffset = 131071;
                elem2PathHistoryPoint_0.ElevationOffset = 2047;
                elem2PathHistoryPoint_0.TimeOffset = 1;
                elem2PathHistoryPoint_0.Speed = 0;
                elem2PathHistoryPoint_0.PosAccuracy = new Econolite.J2735_201603.DSRC.PositionalAccuracy();
                elem2PathHistoryPoint_0.PosAccuracy.SemiMajor = 0;
                elem2PathHistoryPoint_0.PosAccuracy.SemiMinor = 0;
                elem2PathHistoryPoint_0.PosAccuracy.Orientation = 0;
                elem2PathHistoryPoint_0.Heading = 0;
                list2PathHistoryPointList.Add(elem2PathHistoryPoint_0);

                Econolite.J2735_201603.DSRC.PathHistoryPoint elem2PathHistoryPoint_1 = new Econolite.J2735_201603.DSRC.PathHistoryPoint();
                elem2PathHistoryPoint_1.LatOffset = 131071;
                elem2PathHistoryPoint_1.LonOffset = 131071;
                elem2PathHistoryPoint_1.ElevationOffset = 2047;
                elem2PathHistoryPoint_1.TimeOffset = 1;
                elem2PathHistoryPoint_1.Speed = 0;
                elem2PathHistoryPoint_1.PosAccuracy = new Econolite.J2735_201603.DSRC.PositionalAccuracy();
                elem2PathHistoryPoint_1.PosAccuracy.SemiMajor = 0;
                elem2PathHistoryPoint_1.PosAccuracy.SemiMinor = 0;
                elem2PathHistoryPoint_1.PosAccuracy.Orientation = 0;
                elem2PathHistoryPoint_1.Heading = 0;
                list2PathHistoryPointList.Add(elem2PathHistoryPoint_1);
            }
            #endregion fill 'obj2VehicleSafetyExtensions.PathHistory.CrumbData' list
            obj2VehicleSafetyExtensions.PathPrediction = new Econolite.J2735_201603.DSRC.PathPrediction();
            obj2VehicleSafetyExtensions.PathPrediction.RadiusOfCurve = 32767;
            obj2VehicleSafetyExtensions.PathPrediction.Confidence = 0;
            obj2VehicleSafetyExtensions.Lights = new Oss.Asn1.BitStringWithNamedBits (
                new byte[] {
                    0xC0
                }, 2
            );
            list1PartIiType.Add(elem1PartIIcontent0);

            Econolite.J2735_201603.DSRC.PartIIcontent elem1PartIIcontent_1 = new Econolite.J2735_201603.DSRC.PartIIcontent();
            elem1PartIIcontent_1.PartIIId = 0;
            elem1PartIIcontent_1.PartIIValue = new Oss.Asn1.OpenType(new Econolite.J2735_201603.DSRC.VehicleSafetyExtensions());
            Econolite.J2735_201603.DSRC.VehicleSafetyExtensions obj3VehicleSafetyExtensions = (elem1PartIIcontent_1.PartIIValue.Decoded as Econolite.J2735_201603.DSRC.VehicleSafetyExtensions)!;
            obj3VehicleSafetyExtensions.Events = new Oss.Asn1.BitStringWithNamedBits (
                new byte[] {
                    0xC0
                }, 2
            );
            obj3VehicleSafetyExtensions.PathHistory = new Econolite.J2735_201603.DSRC.PathHistory();
            obj3VehicleSafetyExtensions.PathHistory.InitialPosition = new Econolite.J2735_201603.DSRC.FullPositionVector();
            obj3VehicleSafetyExtensions.PathHistory.InitialPosition.UtcTime = new Econolite.J2735_201603.DSRC.DDateTime();
            obj3VehicleSafetyExtensions.PathHistory.InitialPosition.UtcTime.Year = 0;
            obj3VehicleSafetyExtensions.PathHistory.InitialPosition.UtcTime.Month = 0;
            obj3VehicleSafetyExtensions.PathHistory.InitialPosition.UtcTime.Day = 0;
            obj3VehicleSafetyExtensions.PathHistory.InitialPosition.UtcTime.Hour = 0;
            obj3VehicleSafetyExtensions.PathHistory.InitialPosition.UtcTime.Minute = 0;
            obj3VehicleSafetyExtensions.PathHistory.InitialPosition.UtcTime.Second = 0;
            obj3VehicleSafetyExtensions.PathHistory.InitialPosition.UtcTime.Offset = 840;
            obj3VehicleSafetyExtensions.PathHistory.InitialPosition.Long = -1799999999;
            obj3VehicleSafetyExtensions.PathHistory.InitialPosition.Lat = -900000000;
            obj3VehicleSafetyExtensions.PathHistory.InitialPosition.Elevation = -4096;
            obj3VehicleSafetyExtensions.PathHistory.InitialPosition.Heading = 0;
            obj3VehicleSafetyExtensions.PathHistory.InitialPosition.Speed = new Econolite.J2735_201603.DSRC.TransmissionAndSpeed();
            obj3VehicleSafetyExtensions.PathHistory.InitialPosition.Speed.Transmisson = Econolite.J2735_201603.DSRC.TransmissionState.Neutral;
            obj3VehicleSafetyExtensions.PathHistory.InitialPosition.Speed.Speed = 0;
            obj3VehicleSafetyExtensions.PathHistory.InitialPosition.PosAccuracy = new Econolite.J2735_201603.DSRC.PositionalAccuracy();
            obj3VehicleSafetyExtensions.PathHistory.InitialPosition.PosAccuracy.SemiMajor = 0;
            obj3VehicleSafetyExtensions.PathHistory.InitialPosition.PosAccuracy.SemiMinor = 0;
            obj3VehicleSafetyExtensions.PathHistory.InitialPosition.PosAccuracy.Orientation = 0;
            obj3VehicleSafetyExtensions.PathHistory.InitialPosition.TimeConfidence = Econolite.J2735_201603.DSRC.TimeConfidence.Unavailable;
            obj3VehicleSafetyExtensions.PathHistory.InitialPosition.PosConfidence = new Econolite.J2735_201603.DSRC.PositionConfidenceSet();
            obj3VehicleSafetyExtensions.PathHistory.InitialPosition.PosConfidence.Pos = Econolite.J2735_201603.DSRC.PositionConfidence.Unavailable;
            obj3VehicleSafetyExtensions.PathHistory.InitialPosition.PosConfidence.Elevation = Econolite.J2735_201603.DSRC.ElevationConfidence.Unavailable;
            obj3VehicleSafetyExtensions.PathHistory.InitialPosition.SpeedConfidence = new Econolite.J2735_201603.DSRC.SpeedandHeadingandThrottleConfidence();
            obj3VehicleSafetyExtensions.PathHistory.InitialPosition.SpeedConfidence.Heading = Econolite.J2735_201603.DSRC.HeadingConfidence.Unavailable;
            obj3VehicleSafetyExtensions.PathHistory.InitialPosition.SpeedConfidence.Speed = Econolite.J2735_201603.DSRC.SpeedConfidence.Unavailable;
            obj3VehicleSafetyExtensions.PathHistory.InitialPosition.SpeedConfidence.Throttle = Econolite.J2735_201603.DSRC.ThrottleConfidence.Unavailable;
            obj3VehicleSafetyExtensions.PathHistory.CurrGNSSstatus = new Oss.Asn1.BitStringWithNamedBits (
                new byte[] {
                    0xC0
                }, 2
            );
            obj3VehicleSafetyExtensions.PathHistory.CrumbData = new Econolite.J2735_201603.DSRC.PathHistoryPointList();
            #region fill 'obj3VehicleSafetyExtensions.PathHistory.CrumbData' list
            {
                Econolite.J2735_201603.DSRC.PathHistoryPointList list2PathHistoryPointList = obj3VehicleSafetyExtensions.PathHistory.CrumbData;

                Econolite.J2735_201603.DSRC.PathHistoryPoint elem2PathHistoryPoint_0 = new Econolite.J2735_201603.DSRC.PathHistoryPoint();
                elem2PathHistoryPoint_0.LatOffset = 131071;
                elem2PathHistoryPoint_0.LonOffset = 131071;
                elem2PathHistoryPoint_0.ElevationOffset = 2047;
                elem2PathHistoryPoint_0.TimeOffset = 1;
                elem2PathHistoryPoint_0.Speed = 0;
                elem2PathHistoryPoint_0.PosAccuracy = new Econolite.J2735_201603.DSRC.PositionalAccuracy();
                elem2PathHistoryPoint_0.PosAccuracy.SemiMajor = 0;
                elem2PathHistoryPoint_0.PosAccuracy.SemiMinor = 0;
                elem2PathHistoryPoint_0.PosAccuracy.Orientation = 0;
                elem2PathHistoryPoint_0.Heading = 0;
                list2PathHistoryPointList.Add(elem2PathHistoryPoint_0);

                Econolite.J2735_201603.DSRC.PathHistoryPoint elem2PathHistoryPoint_1 = new Econolite.J2735_201603.DSRC.PathHistoryPoint();
                elem2PathHistoryPoint_1.LatOffset = 131071;
                elem2PathHistoryPoint_1.LonOffset = 131071;
                elem2PathHistoryPoint_1.ElevationOffset = 2047;
                elem2PathHistoryPoint_1.TimeOffset = 1;
                elem2PathHistoryPoint_1.Speed = 0;
                elem2PathHistoryPoint_1.PosAccuracy = new Econolite.J2735_201603.DSRC.PositionalAccuracy();
                elem2PathHistoryPoint_1.PosAccuracy.SemiMajor = 0;
                elem2PathHistoryPoint_1.PosAccuracy.SemiMinor = 0;
                elem2PathHistoryPoint_1.PosAccuracy.Orientation = 0;
                elem2PathHistoryPoint_1.Heading = 0;
                list2PathHistoryPointList.Add(elem2PathHistoryPoint_1);
            }
            #endregion fill 'obj3VehicleSafetyExtensions.PathHistory.CrumbData' list
            obj3VehicleSafetyExtensions.PathPrediction = new Econolite.J2735_201603.DSRC.PathPrediction();
            obj3VehicleSafetyExtensions.PathPrediction.RadiusOfCurve = 32767;
            obj3VehicleSafetyExtensions.PathPrediction.Confidence = 0;
            obj3VehicleSafetyExtensions.Lights = new Oss.Asn1.BitStringWithNamedBits (
                new byte[] {
                    0xC0
                }, 2
            );
            list1PartIiType.Add(elem1PartIIcontent_1);
        }
        #endregion fill 'obj1BasicSafetyMessage.PartII' list
        obj1BasicSafetyMessage.Regional = new Econolite.J2735_201603.DSRC.BasicSafetyMessage.RegionalType();
        #region fill 'obj1BasicSafetyMessage.Regional' list
        {
            Econolite.J2735_201603.DSRC.BasicSafetyMessage.RegionalType list1RegionalType = obj1BasicSafetyMessage.Regional;

            Econolite.J2735_201603.DSRC.BasicSafetyMessage.RegionalType.Element elem1Element_0 = new Econolite.J2735_201603.DSRC.BasicSafetyMessage.RegionalType.Element();
            elem1Element_0.RegionId = 0;
            elem1Element_0.RegExtValue = new Oss.Asn1.OpenType(new Econolite.J2735_201603.DSRC.BasicSafetyMessage());
            Econolite.J2735_201603.DSRC.BasicSafetyMessage obj4BasicSafetyMessage = (elem1Element_0.RegExtValue.Decoded as Econolite.J2735_201603.DSRC.BasicSafetyMessage)!;
            obj4BasicSafetyMessage.CoreData = new Econolite.J2735_201603.DSRC.BSMcoreData();
            obj4BasicSafetyMessage.CoreData.MsgCnt = 0;
            obj4BasicSafetyMessage.CoreData.Id = new byte[] {
                0x00, 0x00, 0x00, 0x00
            };
            obj4BasicSafetyMessage.CoreData.SecMark = 0;
            obj4BasicSafetyMessage.CoreData.Lat = -900000000;
            obj4BasicSafetyMessage.CoreData.Long = -1799999999;
            obj4BasicSafetyMessage.CoreData.Elev = -4096;
            obj4BasicSafetyMessage.CoreData.Accuracy = new Econolite.J2735_201603.DSRC.PositionalAccuracy();
            obj4BasicSafetyMessage.CoreData.Accuracy.SemiMajor = 0;
            obj4BasicSafetyMessage.CoreData.Accuracy.SemiMinor = 0;
            obj4BasicSafetyMessage.CoreData.Accuracy.Orientation = 0;
            obj4BasicSafetyMessage.CoreData.Transmission = Econolite.J2735_201603.DSRC.TransmissionState.Neutral;
            obj4BasicSafetyMessage.CoreData.Speed = 0;
            obj4BasicSafetyMessage.CoreData.Heading = 0;
            obj4BasicSafetyMessage.CoreData.Angle = -126;
            obj4BasicSafetyMessage.CoreData.AccelSet = new Econolite.J2735_201603.DSRC.AccelerationSet4Way();
            obj4BasicSafetyMessage.CoreData.AccelSet.Long = -2000;
            obj4BasicSafetyMessage.CoreData.AccelSet.Lat = -2000;
            obj4BasicSafetyMessage.CoreData.AccelSet.Vert = 127;
            obj4BasicSafetyMessage.CoreData.AccelSet.Yaw = 32767;
            obj4BasicSafetyMessage.CoreData.Brakes = new Econolite.J2735_201603.DSRC.BrakeSystemStatus();
            obj4BasicSafetyMessage.CoreData.Brakes.WheelBrakes = new Oss.Asn1.BitStringWithNamedBits (
                new byte[] {
                    0xC0
                }, 2
            );
            obj4BasicSafetyMessage.CoreData.Brakes.Traction = Econolite.J2735_201603.DSRC.TractionControlStatus.Unavailable;
            obj4BasicSafetyMessage.CoreData.Brakes.Abs = Econolite.J2735_201603.DSRC.AntiLockBrakeStatus.Unavailable;
            obj4BasicSafetyMessage.CoreData.Brakes.Scs = Econolite.J2735_201603.DSRC.StabilityControlStatus.Unavailable;
            obj4BasicSafetyMessage.CoreData.Brakes.BrakeBoost = Econolite.J2735_201603.DSRC.BrakeBoostApplied.Unavailable;
            obj4BasicSafetyMessage.CoreData.Brakes.AuxBrakes = Econolite.J2735_201603.DSRC.AuxiliaryBrakeStatus.Unavailable;
            obj4BasicSafetyMessage.CoreData.Size = new Econolite.J2735_201603.DSRC.VehicleSize();
            obj4BasicSafetyMessage.CoreData.Size.Width = 0;
            obj4BasicSafetyMessage.CoreData.Size.Length = 0;
            list1RegionalType.Add(elem1Element_0);

            Econolite.J2735_201603.DSRC.BasicSafetyMessage.RegionalType.Element elem1Element_1 = new Econolite.J2735_201603.DSRC.BasicSafetyMessage.RegionalType.Element();
            elem1Element_1.RegionId = 0;
            elem1Element_1.RegExtValue = new Oss.Asn1.OpenType(new Econolite.J2735_201603.DSRC.BasicSafetyMessage());
            Econolite.J2735_201603.DSRC.BasicSafetyMessage obj5BasicSafetyMessage = (elem1Element_1.RegExtValue.Decoded as Econolite.J2735_201603.DSRC.BasicSafetyMessage)!;
            obj5BasicSafetyMessage.CoreData = new Econolite.J2735_201603.DSRC.BSMcoreData();
            obj5BasicSafetyMessage.CoreData.MsgCnt = 0;
            obj5BasicSafetyMessage.CoreData.Id = new byte[] {
                0x00, 0x00, 0x00, 0x00
            };
            obj5BasicSafetyMessage.CoreData.SecMark = 0;
            obj5BasicSafetyMessage.CoreData.Lat = -900000000;
            obj5BasicSafetyMessage.CoreData.Long = -1799999999;
            obj5BasicSafetyMessage.CoreData.Elev = -4096;
            obj5BasicSafetyMessage.CoreData.Accuracy = new Econolite.J2735_201603.DSRC.PositionalAccuracy();
            obj5BasicSafetyMessage.CoreData.Accuracy.SemiMajor = 0;
            obj5BasicSafetyMessage.CoreData.Accuracy.SemiMinor = 0;
            obj5BasicSafetyMessage.CoreData.Accuracy.Orientation = 0;
            obj5BasicSafetyMessage.CoreData.Transmission = Econolite.J2735_201603.DSRC.TransmissionState.Neutral;
            obj5BasicSafetyMessage.CoreData.Speed = 0;
            obj5BasicSafetyMessage.CoreData.Heading = 0;
            obj5BasicSafetyMessage.CoreData.Angle = -126;
            obj5BasicSafetyMessage.CoreData.AccelSet = new Econolite.J2735_201603.DSRC.AccelerationSet4Way();
            obj5BasicSafetyMessage.CoreData.AccelSet.Long = -2000;
            obj5BasicSafetyMessage.CoreData.AccelSet.Lat = -2000;
            obj5BasicSafetyMessage.CoreData.AccelSet.Vert = 127;
            obj5BasicSafetyMessage.CoreData.AccelSet.Yaw = 32767;
            obj5BasicSafetyMessage.CoreData.Brakes = new Econolite.J2735_201603.DSRC.BrakeSystemStatus();
            obj5BasicSafetyMessage.CoreData.Brakes.WheelBrakes = new Oss.Asn1.BitStringWithNamedBits (
                new byte[] {
                    0xC0
                }, 2
            );
            obj5BasicSafetyMessage.CoreData.Brakes.Traction = Econolite.J2735_201603.DSRC.TractionControlStatus.Unavailable;
            obj5BasicSafetyMessage.CoreData.Brakes.Abs = Econolite.J2735_201603.DSRC.AntiLockBrakeStatus.Unavailable;
            obj5BasicSafetyMessage.CoreData.Brakes.Scs = Econolite.J2735_201603.DSRC.StabilityControlStatus.Unavailable;
            obj5BasicSafetyMessage.CoreData.Brakes.BrakeBoost = Econolite.J2735_201603.DSRC.BrakeBoostApplied.Unavailable;
            obj5BasicSafetyMessage.CoreData.Brakes.AuxBrakes = Econolite.J2735_201603.DSRC.AuxiliaryBrakeStatus.Unavailable;
            obj5BasicSafetyMessage.CoreData.Size = new Econolite.J2735_201603.DSRC.VehicleSize();
            obj5BasicSafetyMessage.CoreData.Size.Width = 0;
            obj5BasicSafetyMessage.CoreData.Size.Length = 0;
            list1RegionalType.Add(elem1Element_1);
        }
        #endregion fill 'obj1BasicSafetyMessage.Regional' list

        return pdu;
    }

    /// <summary>
    /// This sample method demonstrates how to access the fields of the 'Econolite.J2735_201603.DSRC.MessageFrame' type.
    /// This method prints the fields of the object using the helper SampleTextWriter class.
    /// <summary>
    public static void PrintValue(Econolite.J2735_201603.DSRC.MessageFrame value, Oss.Asn1.SampleTextWriter stw)
    {
        stw.WriteBeginSequence();
        stw.WriteFieldName("messageId");
        stw.WriteInteger(value.MessageId);
        stw.WriteFieldName("value");
        stw.WriteOpenType(value.Value);
        stw.WriteEndSequence();
    }

    /// <summary>
    /// This sample method demonstrates how to encode, decode and print the 'Econolite.J2735_201603.DSRC.MessageFrame' type.
    /// <summary>
    public static bool EncodeDecodeAndPrint(Oss.Asn1.BaseCodec codec, Econolite.J2735_201603.DSRC.MessageFrame value, string valueName)
    {
        System.Console.WriteLine("EncodeDecodeAndPrint {0}", valueName);

        // print the input PDU using the BaseType.ToString() method
        System.Console.WriteLine("Input PDU:");
        System.Console.WriteLine(value);

        System.IO.MemoryStream stream = new System.IO.MemoryStream();
        try
        {
            System.Console.WriteLine("Encoding {0} PDU using {1}Codec:", valueName, codec.EncodingRules);
            // encode the PDU to a stream
            codec.Encode(value, stream);

            // obtain encoded bytes
            byte[] encoding = stream.ToArray();
            System.Console.WriteLine("PDU successfully encoded, in " + encoding.Length + " bytes");

            // print encoded bytes
            System.Console.WriteLine("Encoded value:");
            if (codec is Oss.Asn1.TextCodec)
            {
                System.Console.WriteLine(System.Text.Encoding.Default.GetString(encoding));
            }
            else
            {
                Oss.Asn1.ValueNotationFormatter.Print(encoding, encoding.Length, System.Console.Out);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Encoding failed ({0}).", valueName);
            System.Console.WriteLine(ex.Message);
            System.Console.WriteLine();
            return false;
        }

        Econolite.J2735_201603.DSRC.MessageFrame decoded = new Econolite.J2735_201603.DSRC.MessageFrame();
        try
        {
            System.Console.WriteLine("Decoding {0} PDU using {1}Codec:", valueName, codec.EncodingRules);
            // decode from stream into the new PDU
            stream.Position = 0;
            codec.Decode(stream, decoded);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Decoding failed ({0}).", valueName);
            System.Console.WriteLine(ex.Message);
            System.Console.WriteLine();
            return false;
        }

        // print the decoded value using sample PrintValue method
        System.Console.WriteLine("Decoded PDU:");
        PrintValue(decoded, new Oss.Asn1.SampleTextWriter(System.Console.Out));
        System.Console.WriteLine();

        return true;
    }
}
