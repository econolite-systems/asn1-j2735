using System.Text;
using Econolite.Asn1J2735.J2735;
using Econolite.J2735_201603.DSRC;
using Econolite.J2735_201603.ITIS;
using Econolite.Ode.Domain.Asn1.J2735.Extensions;
using Oss.Asn1;
using DirectionOfUse = Econolite.J2735_201603.DSRC.DirectionOfUse;
using Extent = Econolite.J2735_201603.DSRC.Extent;
using GeographicalPath = Econolite.J2735_201603.DSRC.GeographicalPath;
using GeometricProjection = Econolite.J2735_201603.DSRC.GeometricProjection;
using LaneDataAttribute = Econolite.J2735_201603.DSRC.LaneDataAttribute;
using LaneDataAttributeList = Econolite.J2735_201603.DSRC.LaneDataAttributeList;
using MessageFrame = Econolite.J2735_201603.DSRC.MessageFrame;
using MUTCDCode = Econolite.J2735_201603.DSRC.MUTCDCode;
using NodeAttributeLLList = Econolite.J2735_201603.DSRC.NodeAttributeLLList;
using NodeAttributeXY = Econolite.J2735_201603.DSRC.NodeAttributeXY;
using NodeAttributeXYList = Econolite.J2735_201603.DSRC.NodeAttributeXYList;
using NodeListLL = Econolite.J2735_201603.DSRC.NodeListLL;
using NodeListXY = Econolite.J2735_201603.DSRC.NodeListXY;
using NodeLL = Econolite.J2735_201603.DSRC.NodeLL;
using NodeLLmD64b = Econolite.J2735_201603.DSRC.NodeLLmD64b;
using NodeOffsetPointLL = Econolite.J2735_201603.DSRC.NodeOffsetPointLL;
using NodeOffsetPointXY = Econolite.J2735_201603.DSRC.NodeOffsetPointXY;
using NodeSetLL = Econolite.J2735_201603.DSRC.NodeSetLL;
using NodeSetXY = Econolite.J2735_201603.DSRC.NodeSetXY;
using NodeXY = Econolite.J2735_201603.DSRC.NodeXY;
using OffsetSystem = Econolite.J2735_201603.DSRC.OffsetSystem;
using RegulatorySpeedLimit = Econolite.J2735_201603.DSRC.RegulatorySpeedLimit;
using SegmentAttributeLLList = Econolite.J2735_201603.DSRC.SegmentAttributeLLList;
using SegmentAttributeXYList = Econolite.J2735_201603.DSRC.SegmentAttributeXYList;
using SpeedLimitList = Econolite.J2735_201603.DSRC.SpeedLimitList;
using SpeedLimitType = Econolite.J2735_201603.DSRC.SpeedLimitType;
using TravelerDataFrame = Econolite.J2735_201603.DSRC.TravelerDataFrame;
using TravelerInformation = Econolite.J2735_201603.DSRC.TravelerInformation;
using TravelerInfoType = Econolite.J2735_201603.DSRC.TravelerInfoType;

namespace Econolite.Ode.Domain.Asn1.J2735.Mapping;

public static class TimMapping
{
    public static MessageFrame ToTimEncode(this Asn1J2735.J2735.MessageFrame value)
    {
        var result = new MessageFrame()
        {
            MessageId = value.MessageId
        };

        if (value.Value is Asn1J2735.J2735.TravelerInformation)
        {
            var pdu = value.Value as Asn1J2735.J2735.TravelerInformation;

            if (pdu == null)
            {
                throw new Exception("TravelerInformation is null");
            }

            var travelerInformation = new TravelerInformation()
            {
                MsgCnt = pdu.MsgCnt,
                DataFrames = new TravelerDataFrameList(pdu.DataFrames.Select(d => d.ToEncode())),
            };

            if (pdu.PacketID != null)
            {
                travelerInformation.PacketID = pdu.PacketID;
            }

            if (pdu.TimeStamp != null)
            {
                travelerInformation.TimeStamp = pdu.TimeStamp;
            }

            if (pdu.UrlB != null)
            {
                travelerInformation.UrlB = pdu.UrlB;
            }

            result.Value = new OpenType(travelerInformation);
        }

        return result;
    }

    public static TravelerDataFrame ToEncode(this Asn1J2735.J2735.TravelerDataFrame value)
    {
        return new TravelerDataFrame()
        {
            SspTimRights = value.SspTimRights,
            FrameType = (TravelerInfoType)((int)value.FrameType),
            MsgId = value.MsgId.ToEncode(),
            StartYear = value.StartYear,
            StartTime = value.StartTime,
            DuratonTime = value.DurationTime,
            Priority = value.Priority,
            SspLocationRights = value.SspLocationRights,
            Regions = value.Regions.ToEncode(),
            SspMsgRights1 = value.SspMsgRights1,
            SspMsgRights2 = value.SspMsgRights2,
            Content = value.Content!.ToEncode(),
            Url = value.Url
        };
    }


    public static TravelerDataFrame.ContentType ToEncode(this Asn1J2735.J2735.TimStorage.Content value)
    {
        var result = new TravelerDataFrame.ContentType();
        if (value.ExitService != null)
        {
            result.ExitService = new ExitService(value.ExitService.Items.Select(item => item.ToWorkzoneElement()));
        }
        else if (value.SpeedLimit != null)
        {
            result.SpeedLimit = new SpeedLimit(value.SpeedLimit.Items.Select(item => item.ToWorkzoneElement()));
        }
        else if (value.WorkZone != null)
        {
            result.WorkZone = new WorkZone(value.WorkZone.Items.Select(item => item.ToWorkzoneElement()));
        }
        else if (value.Advisory != null)
        {
            result.Advisory = new ITIScodesAndText(value.Advisory.Items.Select(item => item.ToItisCodesAndTextElement()));
        }
        else if (value.GenericSign != null)
        {
            result.GenericSign = new GenericSignage(value.GenericSign.Items.Select(item => item.ToWorkzoneElement()));
        }

        return result;
    }


    public static TravelerDataFrame.MsgIdType ToEncode(this Asn1J2735.J2735.MsgIdType value)
    {
        TravelerDataFrame.MsgIdType msgIdType = new TravelerDataFrame.MsgIdType();

        if (value.FurtherInfoID != null)
        {
            msgIdType.FurtherInfoID = Encoding.ASCII.GetBytes(value.FurtherInfoID); 
        }
        else if (value.RoadSignID != null)
        {
            var slice = value.RoadSignID.ViewAngle.ToHeadingSlice();
            msgIdType.RoadSignID = new RoadSignID()
            {
                Position = value.RoadSignID.Position.ToEncode(),
                ViewAngle =  slice.ToBitStringWithNamedBits(),
                MutcdCode = MUTCDCode.None
            };
        }

        return msgIdType;
    }

    public static WorkZone.Element ToWorkzoneElement(this Asn1J2735.J2735.TimStorage.Item item)
    {
        var itemType = new WorkZone.Element.ItemType();
        if (item.Itis.HasValue)
        {
            itemType.Itis = item.Itis;
        }
        else if (item.Text != null)
        {
            itemType.Text = item.Text;
        }

        return new WorkZone.Element()
        {
            Item = itemType
        };
    }

    public static ITIScodesAndText.Element ToItisCodesAndTextElement(this Asn1J2735.J2735.TimStorage.Item value)
    {
        var itemType = new ITIScodesAndText.Element.ItemType();
        if (value.Itis.HasValue)
        {
            itemType.Itis = value.Itis;
        }
        else if (value.Text != null)
        {
            itemType.Text = value.Text;
        }

        return new ITIScodesAndText.Element()
        {
            Item = itemType
        };
    }

    public static TravelerDataFrame.RegionsType ToEncode(this IEnumerable<Asn1J2735.J2735.GeographicalPath> value)
    {
        var result = new TravelerDataFrame.RegionsType(value.Select(p => p.ToEncode()));

        return result;
    }

    public static GeographicalPath ToEncode(this Asn1J2735.J2735.GeographicalPath value)
    {
        var result = new GeographicalPath()
        {
            Name = value.Name,
            LaneWidth = value.LaneWidth,
            ClosedPath = value.ClosedPath
        };

        if (value.Id != null)
        {
            result.Id = new RoadSegmentReferenceID()
            {
                Id = value.Id.Id,
                Region = value.Id.Region
            };
        }

        if (value.Anchor != null)
        {
            result.Anchor = value.Anchor.ToEncode();
        }

        if (value.Directionality != null)
        {
            result.Directionality = value.Directionality.Value.ToEncode<Asn1J2735.J2735.DirectionOfUse, DirectionOfUse>();
        }

        if (value.Direction != null)
        {
            var slice = value.Direction.ToHeadingSlice();
            result.Direction = slice.ToBitStringWithNamedBits();
        }

        if (value.Description != null)
        {
            result.Description = value.Description.ToEncode();
        }

        return result;
    }




    public static BitStringWithNamedBits ToBitStringWithNamedBits(this Asn1J2735.J2735.HeadingSlice bitString)
    {
        var str = Asn1J2735.J2735.HeadingSliceExtensions.ToBitString(bitString);
        var boolArray = str.Select(bs => int.Parse(bs.ToString()) == 1 ? true : false).ToArray();
        return new BitStringWithNamedBits(boolArray);
    }

    public static Position3D ToEncode(this Asn1J2735.J2735.Position3d value)
    {
        return new Position3D()
        {
            Elevation = (int?)value.Elevation,
            Lat = value.Latitude.ToInt(),
            Long = value.Longitude.ToInt()
        };
    }

    public static GeographicalPath.DescriptionType ToEncode(this Asn1J2735.J2735.GeometryType value)
    {
        var result = new GeographicalPath.DescriptionType();

        if (value.Path != null)
        {
            result.Path = value.Path.ToEncode();
        }
        else if (value.Geometry != null)
        {
            result.Geometry = value.Geometry.ToEncode();
        }

        return result;
    }

    public static OffsetSystem ToEncode(this Asn1J2735.J2735.OffsetSystem value)
    {
        return new OffsetSystem()
        {
            Scale = value.Scale,
            Offset = value.Offset.ToEncode()
        };
    }

    public static OffsetSystem.OffsetType ToEncode(this Asn1J2735.J2735.NodeList value)
    {
        var result = new OffsetSystem.OffsetType();
        if (value.Xy != null)
        {
            result.Xy = value.Xy.ToEncode();
        }
        else if (value.Ll != null)
        {
            result.Ll = value.Ll.ToEncode();
        }

        return result;
    }

    public static NodeListLL ToEncode(this Asn1J2735.J2735.NodeListLL? value)
    {

        return new NodeListLL()
        {
            Nodes = new NodeSetLL(value?.Nodes.NodeLL.Select(n => n.ToEncode()))
        };
    }

    public static NodeLL ToEncode(this Asn1J2735.J2735.NodeLL value)
    {
        var result = new NodeLL()
        {
            Delta = new NodeOffsetPointLL()
            {
                NodeLatLon = new NodeLLmD64b()
                {
                    Lat = value.Delta.NodeLatLon.Lat.ToInt(),
                    Lon = value.Delta.NodeLatLon.Lon.ToInt()
                }
            }
        };

        if (value.Attributes != null)
        {
            result.Attributes.Data = value.Attributes.Data.ToEncode();
            result.Attributes.Disabled = value.Attributes.Disabled.ToEncode();
            result.Attributes.LocalNode = value.Attributes.LocalNode.ToEncode();
            result.Attributes.Enabled = value.Attributes.Enabled.ToEncode();
            result.Attributes.DElevation = value.Attributes.DElevation;
            result.Attributes.DWidth = value.Attributes.DWidth;
        }

        return result;
    }

    public static NodeListXY ToEncode(this Asn1J2735.J2735.NodeListXY? value)
    {
        return new NodeListXY()
        {
            Nodes = new NodeSetXY(value?.Nodes.NodeXY.Select(n => n.ToEncode()))
        };
    }

    public static NodeXY ToEncode(this Asn1J2735.J2735.NodeXY value)
    {
        var result = new NodeXY()
        {
            Delta = new NodeOffsetPointXY()
        };

        if (value.Delta.NodeXY1 != null)
        {
            result.Delta.NodeXY1 = new NodeXY20b()
            {
                X = value.Delta.NodeXY1.X.ToInt(),
                Y = value.Delta.NodeXY1.Y.ToInt()
            };
        }
        else if (value.Delta.NodeXY2 != null)
        {
            result.Delta.NodeXY2 = new NodeXY22b()
            {
                X = value.Delta.NodeXY2.X.ToInt(),
                Y = value.Delta.NodeXY2.Y.ToInt()
            };
        }
        else if (value.Delta.NodeXY3 != null)
        {
            result.Delta.NodeXY3 = new NodeXY24b()
            {
                X = value.Delta.NodeXY3.X.ToInt(),
                Y = value.Delta.NodeXY3.Y.ToInt()
            };
        }
        else if (value.Delta.NodeXY4 != null)
        {
            result.Delta.NodeXY4 = new NodeXY26b()
            {
                X = value.Delta.NodeXY4.X.ToInt(),
                Y = value.Delta.NodeXY4.Y.ToInt()
            };
        }
        else if (value.Delta.NodeXY5 != null)
        {
            result.Delta.NodeXY5 = new NodeXY28b()
            {
                X = value.Delta.NodeXY5.X.ToInt(),
                Y = value.Delta.NodeXY5.Y.ToInt()
            };
        }
        else if (value.Delta.NodeXY6 != null)
        {
            result.Delta.NodeXY6 = new NodeXY32b()
            {
                X = value.Delta.NodeXY6.X.ToInt(),
                Y = value.Delta.NodeXY6.Y.ToInt()
            };
        }
        else if (value.Delta.NodeLatLon != null)
        {
            result.Delta.NodeLatLon = new NodeLLmD64b()
            {
                Lat = value.Delta.NodeLatLon.Lat.ToInt(),
                Lon = value.Delta.NodeLatLon.Lon.ToInt()
            };
        }

        if (value.Attributes != null)
        {
            result.Attributes.Data = value.Attributes.Data.ToEncode();
            result.Attributes.Disabled = value.Attributes.Disabled.ToEncode();
            result.Attributes.LocalNode = value.Attributes.LocalNode.ToEncode();
            result.Attributes.Enabled = value.Attributes.Enabled.ToEncode();
            result.Attributes.DElevation = value.Attributes.DElevation;
            result.Attributes.DWidth = value.Attributes.DWidth;
        }

        return result;
    }

    public static LaneDataAttributeList ToEncode(this Asn1J2735.J2735.LaneDataAttributeList value)
    {
        return new LaneDataAttributeList(value.LocalNode.Select(l => l.ToEncode()));
    }

    public static LaneDataAttribute ToEncode(this Asn1J2735.J2735.LaneDataAttribute value)
    {
        return new LaneDataAttribute()
        {
            LaneAngle = value.LaneAngle,
            LaneCrownPointCenter = value.LaneCrownPointCenter,
            LaneCrownPointLeft = value.LaneCrownPointLeft,
            LaneCrownPointRight = value.LaneCrownPointRight,
            PathEndPointAngle = value.PathEndPointAngle,
            SpeedLimits = value.SpeedLimits.ToEncode()
        };
    }

    public static SpeedLimitList ToEncode(this Asn1J2735.J2735.SpeedLimitList value)
    {
        return new SpeedLimitList(value.SpeedLimits.ToEncode());
    }

    public static IEnumerable<RegulatorySpeedLimit> ToEncode(
        this IEnumerable<Asn1J2735.J2735.RegulatorySpeedLimit> value)
    {
        return value.Select(rs => rs.ToEncode());
    }

    public static RegulatorySpeedLimit ToEncode(
        this Asn1J2735.J2735.RegulatorySpeedLimit value)
    {
        return new RegulatorySpeedLimit()
        {
            Type = value.Type.ToEncode<Asn1J2735.J2735.SpeedLimitType, SpeedLimitType>(),
            Speed = value.Speed
        };
    }

    public static SegmentAttributeLLList ToEncode(this Asn1J2735.J2735.SegmentAttributeLLList value)
    {
        return new SegmentAttributeLLList(value.SegAttrList.Select(sa =>
            sa.ToEncode<Asn1J2735.J2735.SegmentAttribute, SegmentAttributeLL>()));
    }

    public static SegmentAttributeXYList ToEncode(this Asn1J2735.J2735.SegmentAttributeXYList value)
    {
        return new SegmentAttributeXYList(value.SegAttrList.Select(sa =>
            sa.ToEncode<Asn1J2735.J2735.SegmentAttribute, SegmentAttributeXY>()));
    }

    public static NodeAttributeLLList ToEncode(this Asn1J2735.J2735.NodeAttributeLLList value)
    {
        return new NodeAttributeLLList(
            value.LocalNode.Select(sa => sa.ToEncode<Asn1J2735.J2735.NodeAttribute, NodeAttributeLL>()));
    }

    public static NodeAttributeXYList ToEncode(this Asn1J2735.J2735.NodeAttributeXYList value)
    {
        return new NodeAttributeXYList(
            value.LocalNode.Select(sa => sa.ToEncode<Asn1J2735.J2735.NodeAttribute, NodeAttributeXY>()));
    }

    public static GeometricProjection ToEncode(this Asn1J2735.J2735.GeometricProjection value)
    {
        var result = new GeometricProjection()
        {
            Circle = value.Circle.ToEncode(),
            LaneWidth = value.LaneWidth,
        };

        if (value.Direction != null)
        {
            var slice = value.Direction.ToHeadingSlice();
            result.Direction = slice.ToBitStringWithNamedBits();
        }

        if (value.Extent.HasValue)
        {
            result.Extent = value.Extent.Value.ToEncode<Asn1J2735.J2735.Extent, Extent>();
        }

        return result;
    }

    public static Circle ToEncode(this Asn1J2735.J2735.TimStorage.Circle value)
    {
        return new Circle()
        {
            Center = value.Center.ToEncode(),
            Radius = value.Radius,
            Units = value.Units.ToEncode<Asn1J2735.J2735.TimStorage.DistanceUnits, DistanceUnits>()
        };
    }

    public static R ToEncode<T, R>(this T value) where T : Enum where R : Enum
    {
        return (R)(object)value.EnumToInt();
    }

    public static int EnumToInt<T>(this T value) where T : Enum
        => (int)(object)value;
}

public static class DateTimeIso
{
    public static DateTime ToDateTime(this string hex)
    {
        var sanitized = hex.Replace("0x", "");
        var length = sanitized.Length;
        var year = int.Parse(sanitized.Substring(0, 4), System.Globalization.NumberStyles.HexNumber);
        var month = int.Parse(sanitized.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        var day = int.Parse(sanitized.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
        var hour = int.Parse(length >= 10 ? sanitized.Substring(8, 2) : "00",
            System.Globalization.NumberStyles.HexNumber);
        var minute = int.Parse(length >= 12 ? sanitized.Substring(10, 2) : "00",
            System.Globalization.NumberStyles.HexNumber);
        var second = int.Parse(length >= 14 ? sanitized.Substring(12, 2) : "00",
            System.Globalization.NumberStyles.HexNumber);

        return new DateTime(year, month, day, hour, minute, second, DateTimeKind.Utc);
    }

    public static string ToRFC2579DateTime(this DateTime dateTime)
    {
        var year = dateTime.Year.ToString("x4");
        var month = dateTime.Month.ToString("x2");
        var day = dateTime.Day.ToString("x2");
        var hour = dateTime.Hour.ToString("x2");
        var minute = dateTime.Minute.ToString("x2");

        return $"{year}{month}{day}{hour}{minute}";
    }
}

public static class LatLonExtensions
{
    public static int ToInt(this double value)
    {
        return (int)(value * Math.Pow(10, 7));
    }

    public static double ToDouble(this int value)
    {
        return Math.Round(value / Math.Pow(10, 7), 7, MidpointRounding.AwayFromZero);
    }

    public static NodeLL ToNodeLL(this Asn1J2735.J2735.Position3d point)
    {
        return new NodeLL()
        {
            Delta = new NodeOffsetPointLL()
            {
                NodeLatLon = new NodeLLmD64b()
                {
                    Lat = point.Latitude.ToInt(),
                    Lon = point.Longitude.ToInt(),
                }
            }
        };
    }

    // public static string ToDelta(this Position3D point, Position3D previous)
    // {
    //     var latDif = previous.Lat - point.Lat;
    //     var lonDif = previous.Long - point.Long;
    //
    //     if (latDif.Between(-22.634554, 22.634554))
    //     {
    //         
    //     }
    //     else if (latDif.Between(-90.571389, 90.571389))
    //     {
    //         
    //     }
    //     else if (latDif.Between(-90.571389, 90.571389))
    //     {
    //         
    //     }
    //     
    //     return string.Empty;
    // }

    public static bool Between(this int value, double lower, double higher)
    {
        return lower <= value && higher >= value;
    }
}

