using System.Text;
using System.Xml.Linq;
using Econolite.Asn1J2735.J2735;
using Econolite.Asn1J2735.J2735.TimStorage;
using Econolite.J2735_201603.DSRC;
using Econolite.J2735_201603.ITIS;
using Econolite.Ode.Domain.Asn1.J2735.Mapping;
using Oss.Asn1;

namespace Econolite.Ode.Domain.Asn1.J2735.Extensions
{
    public static class TimDecodeConversionExtensions
    {

        #region TimStorageDecoding
        public static Asn1J2735.J2735.TimStorage.Item ToTimStorageItem(this WorkZone.Element element)
        {
            var result = new Asn1J2735.J2735.TimStorage.Item();
            if (element.Item.Itis.HasValue)
            {
                result.Itis = element.Item.Itis;
            }
            else if (element.Item.Text != null)
            {
                result.Text = element.Item.Text;
            }

            return result;
        }

        public static Asn1J2735.J2735.TimStorage.Item ToTimStorageItem(this ITIScodesAndText.Element element)
        {
            var result = new Asn1J2735.J2735.TimStorage.Item();
            if (element.Item.Itis.HasValue)
            {
                result.Itis = element.Item.Itis;
            }
            else if (element.Item.Text != null)
            {
                result.Text = element.Item.Text;
            }

            return result;
        }

        public static IEnumerable<Asn1J2735.J2735.TimStorage.Item> ToTimStorageItems(this SpeedLimit speedLimit)
        {
            return speedLimit.Select(item => item.ToTimStorageItem()).ToList();
        }

        public static IEnumerable<Asn1J2735.J2735.TimStorage.Item> ToTimStorageItems(this ExitService speedLimit)
        {
            return speedLimit.Select(item => item.ToTimStorageItem()).ToList();
        }

        public static IEnumerable<Asn1J2735.J2735.TimStorage.Item> ToTimStorageItems(this WorkZone workZone)
        {
            return workZone.Select(item => item.ToTimStorageItem()).ToList();
        }

        public static IEnumerable<Asn1J2735.J2735.TimStorage.Item> ToTimStorageItems(this ITIScodesAndText advisory)
        {
            return advisory.Select(item => item.ToTimStorageItem()).ToList();
        }

        public static IEnumerable<Asn1J2735.J2735.TimStorage.Item> ToTimStorageItems(this GenericSignage genericSign)
        {
            return genericSign.Select(item => item.ToTimStorageItem()).ToList();
        }


        public static T ToDecode<R, T>(this R value) where R : Enum where T : Enum
        {
            return (T)Enum.Parse(typeof(T), value.ToString());
        }

        public static T IntToEnum<T>(this int value) where T : Enum
        {
            return (T)Enum.ToObject(typeof(T), value);
        }

        public static Asn1J2735.J2735.TimStorage.Content ToDecode(this J2735_201603.DSRC.TravelerDataFrame.ContentType value)
        {
            var result = new Asn1J2735.J2735.TimStorage.Content();
            if (value.ExitService != null)
            {
                result.ExitService = new Asn1J2735.J2735.TimStorage.ItisCodesAndText()
                {
                    Items = value.ExitService.ToTimStorageItems().ToList()
                };
            }
            if (value.SpeedLimit != null)
            {
                result.SpeedLimit = new Asn1J2735.J2735.TimStorage.ItisCodesAndText()
                {
                    Items = value.SpeedLimit.ToTimStorageItems().ToList()
                };
            }
            if (value.WorkZone != null)
            {
                result.WorkZone = new Asn1J2735.J2735.TimStorage.ItisCodesAndText()
                {
                    Items = value.WorkZone.ToTimStorageItems().ToList()
                };
            }
            if (value.Advisory != null)
            {
                result.Advisory = new Asn1J2735.J2735.TimStorage.ItisCodesAndText()
                {
                    Items = value.Advisory.ToTimStorageItems().ToList()
                };
            }
            if (value.GenericSign != null)
            {
                result.GenericSign = new Asn1J2735.J2735.TimStorage.ItisCodesAndText()
                {
                    Items = value.GenericSign.ToTimStorageItems().ToList()
                };
            }

            return result;
        }

        #endregion

        #region GeometricDecode

        public static Asn1J2735.J2735.GeographicalPath ToDecode(this J2735_201603.DSRC.GeographicalPath value)
        {
            var result = new Asn1J2735.J2735.GeographicalPath()
            {
                Name = value.Name,
                LaneWidth = value.LaneWidth,
                ClosedPath = value.ClosedPath
            };

            if (value.Id != null)
            {
                result.Id = new RoadSegmentReferenceId()
                {
                    Id = value.Id.Id,
                    Region = value.Id.Region ?? 0
                };
            }

            if (value.Anchor != null)
            {
                result.Anchor = value.Anchor.ToDecode();
            }

            if (value.Directionality != null)
            {
                result.Directionality = (Asn1J2735.J2735.DirectionOfUse?)((int)value.Directionality.Value).IntToEnum<J2735_201603.DSRC.DirectionOfUse>();
            }

            if (value.Direction != null)
            {
                var bitString = value.Direction.ToBitString();
                result.Direction = bitString;
            }


            if (value.Description != null)
            {
                result.Description = value.Description.ToDecode();
            }

            return result;
        }

        public static Asn1J2735.J2735.GeometricProjection ToDecode(this J2735_201603.DSRC.GeometricProjection value)
        {
            var result = new Asn1J2735.J2735.GeometricProjection()
            {
                Circle = value.Circle.ToDecode(),
                LaneWidth = value.LaneWidth,
            };

            if (value.Direction != null)
            {
                var bitString = value.Direction.ToBitString();
                result.Direction = bitString;
            }

            if (value.Extent.HasValue)
            {
                result.Extent = value.Extent.Value.ToDecode();
            }

            return result;
        }


        public static Asn1J2735.J2735.TimStorage.Circle ToDecode(this J2735_201603.DSRC.Circle value)
        {
            return new Asn1J2735.J2735.TimStorage.Circle()
            {
                Center = value.Center.ToDecode(),
                Radius = value.Radius,
                Units = value.Units.ToDecode()
            };
        }

        public static Asn1J2735.J2735.Position3d ToDecode(this J2735_201603.DSRC.Position3D value)
        {
            return new Asn1J2735.J2735.Position3d()
            {
                Elevation = value.Elevation,
                Latitude = value.Lat,
                Longitude = value.Long
            };
        }


        public static Asn1J2735.J2735.TimStorage.DistanceUnits ToDecode(this Econolite.J2735_201603.DSRC.DistanceUnits value)
        {
            switch (value)
            {
                case Econolite.J2735_201603.DSRC.DistanceUnits.Centimeter:
                    return Asn1J2735.J2735.TimStorage.DistanceUnits.centimeter;
                case Econolite.J2735_201603.DSRC.DistanceUnits.Cm25:
                    return Asn1J2735.J2735.TimStorage.DistanceUnits.cm2_5;
                case Econolite.J2735_201603.DSRC.DistanceUnits.Decimeter:
                    return Asn1J2735.J2735.TimStorage.DistanceUnits.decimeter;
                case Econolite.J2735_201603.DSRC.DistanceUnits.Meter:
                    return Asn1J2735.J2735.TimStorage.DistanceUnits.meter;
                case Econolite.J2735_201603.DSRC.DistanceUnits.Kilometer:
                    return Asn1J2735.J2735.TimStorage.DistanceUnits.kilometer;
                case Econolite.J2735_201603.DSRC.DistanceUnits.Foot:
                    return Asn1J2735.J2735.TimStorage.DistanceUnits.foot;
                case Econolite.J2735_201603.DSRC.DistanceUnits.Yard:
                    return Asn1J2735.J2735.TimStorage.DistanceUnits.yard;
                case Econolite.J2735_201603.DSRC.DistanceUnits.Mile:
                    return Asn1J2735.J2735.TimStorage.DistanceUnits.mile;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }


        public static Asn1J2735.J2735.Extent ToDecode(this Econolite.J2735_201603.DSRC.Extent value)
        {
            return (Asn1J2735.J2735.Extent)(Asn1J2735.J2735.TimStorage.DistanceUnits)Enum.Parse(typeof(Asn1J2735.J2735.Extent), value.ToString());
        }

        #region nodeAttribute
        public static Asn1J2735.J2735.NodeAttribute ToDecode(this NodeAttribute value)
        {
            return (Asn1J2735.J2735.NodeAttribute)Enum.Parse(typeof(Asn1J2735.J2735.NodeAttribute), value.ToString());
        }

        public static Asn1J2735.J2735.SegmentAttributeLLList ToDecode(this J2735_201603.DSRC.SegmentAttributeLLList value)
        {
            var result = new Asn1J2735.J2735.SegmentAttributeLLList();
            foreach (var item in value)
            {
                result.SegAttrList.Add(item.ToDecode<J2735_201603.DSRC.SegmentAttributeLL, Asn1J2735.J2735.SegmentAttribute>());
            }
            return result;
        }

        public static Asn1J2735.J2735.SegmentAttributeXYList ToDecode(this J2735_201603.DSRC.SegmentAttributeXYList value)
        {
            var result = new Asn1J2735.J2735.SegmentAttributeXYList();
            foreach (var item in value)
            {
                result.SegAttrList.Add(item.ToDecode<J2735_201603.DSRC.SegmentAttributeXY, Asn1J2735.J2735.SegmentAttribute>());
            }
            return result;
        }

        public static Asn1J2735.J2735.NodeAttributeLLList ToDecode(this J2735_201603.DSRC.NodeAttributeLLList value)
        {
            var result = new Asn1J2735.J2735.NodeAttributeLLList();
            foreach (var item in value)
            {
                result.LocalNode.Add(item.ToDecode<J2735_201603.DSRC.NodeAttributeLL, Asn1J2735.J2735.NodeAttribute>());
            }
            return result;
        }

        public static Asn1J2735.J2735.NodeAttributeXYList ToDecode(this J2735_201603.DSRC.NodeAttributeXYList value)
        {
            var result = new Asn1J2735.J2735.NodeAttributeXYList();
            foreach (var item in value)
            {
                result.LocalNode.Add(item.ToDecode<J2735_201603.DSRC.NodeAttributeXY, Asn1J2735.J2735.NodeAttribute>());
            }
            return result;
        }
        #endregion
        #region speedlimit
        public static IEnumerable<Asn1J2735.J2735.RegulatorySpeedLimit> ToDecode(
    this IEnumerable<J2735_201603.DSRC.RegulatorySpeedLimit> value)
        {
            return value.Select(rs => rs.ToDecode());
        }

        public static Asn1J2735.J2735.RegulatorySpeedLimit ToDecode(
            this J2735_201603.DSRC.RegulatorySpeedLimit value)
        {
            return new Asn1J2735.J2735.RegulatorySpeedLimit()
            {
                Type = value.Type.ToDecode<J2735_201603.DSRC.SpeedLimitType, Asn1J2735.J2735.SpeedLimitType>(),
                Speed = value.Speed
            };
        }

        public static Asn1J2735.J2735.SpeedLimitList ToDecode(this J2735_201603.DSRC.SpeedLimitList value)
        {
            var result = value.ToDecode();
            return result;
        }
        #endregion


        public static Asn1J2735.J2735.LaneDataAttribute ToDecode(this J2735_201603.DSRC.LaneDataAttribute value)
        {
            return new Asn1J2735.J2735.LaneDataAttribute()
            {
                LaneAngle = value.LaneAngle ?? 0,
                LaneCrownPointCenter = value.LaneCrownPointCenter ?? 0,
                LaneCrownPointLeft = value.LaneCrownPointLeft ?? 0,
                LaneCrownPointRight = value.LaneCrownPointRight ?? 0,
                PathEndPointAngle = value.PathEndPointAngle ?? 0,
                SpeedLimits = value.SpeedLimits.ToDecode()
            };
        }
        public static Asn1J2735.J2735.LaneDataAttributeList ToDecode(this J2735_201603.DSRC.LaneDataAttributeList value)
        {
            var result = new Asn1J2735.J2735.LaneDataAttributeList();
            foreach (var item in value)
            {
                result.LocalNode.Add(item.ToDecode());
            }

            return result;
        }

        #region Nodes
        public static Asn1J2735.J2735.NodeXY ToDecode(this J2735_201603.DSRC.NodeXY value)
        {
            var result = new Asn1J2735.J2735.NodeXY()
            {
                Delta = new Asn1J2735.J2735.NodeOffsetPointXY()
            };

            if (value.Delta.NodeXY1 != null)
            {
                result.Delta.NodeXY1 = new Asn1J2735.J2735.Node_XY()
                {
                    X = value.Delta.NodeXY1.X.ToDouble(),
                    Y = value.Delta.NodeXY1.Y.ToDouble()
                };
            }
            else if (value.Delta.NodeXY2 != null)
            {
                result.Delta.NodeXY2 = new Asn1J2735.J2735.Node_XY()
                {
                    X = value.Delta.NodeXY2.X.ToDouble(),
                    Y = value.Delta.NodeXY2.Y.ToDouble()
                };
            }
            else if (value.Delta.NodeXY3 != null)
            {
                result.Delta.NodeXY3 = new Asn1J2735.J2735.Node_XY()
                {
                    X = value.Delta.NodeXY3.X.ToDouble(),
                    Y = value.Delta.NodeXY3.Y.ToDouble()
                };
            }
            else if (value.Delta.NodeXY4 != null)
            {
                result.Delta.NodeXY4 = new Asn1J2735.J2735.Node_XY()
                {
                    X = value.Delta.NodeXY4.X.ToDouble(),
                    Y = value.Delta.NodeXY4.Y.ToDouble()
                };
            }
            else if (value.Delta.NodeXY5 != null)
            {
                result.Delta.NodeXY5 = new Asn1J2735.J2735.Node_XY()
                {
                    X = value.Delta.NodeXY5.X.ToDouble(),
                    Y = value.Delta.NodeXY5.Y.ToDouble()
                };
            }
            else if (value.Delta.NodeXY6 != null)
            {
                result.Delta.NodeXY6 = new Asn1J2735.J2735.Node_XY()
                {
                    X = value.Delta.NodeXY6.X.ToDouble(),
                    Y = value.Delta.NodeXY6.Y.ToDouble()
                };
            }
            else if (value.Delta.NodeLatLon != null)
            {
                result.Delta.NodeLatLon = new Asn1J2735.J2735.NodeLLmD64b()
                {
                    Lat = value.Delta.NodeLatLon.Lat.ToDouble(),
                    Lon = value.Delta.NodeLatLon.Lon.ToDouble()
                };
            }

            if (value.Attributes != null)
            {
                result!.Attributes!.Data = value.Attributes.Data.ToDecode();
                result.Attributes.Disabled = value.Attributes.Disabled.ToDecode();
                result.Attributes.LocalNode = value.Attributes.LocalNode.ToDecode();
                result.Attributes.Enabled = value.Attributes.Enabled.ToDecode();
                result.Attributes.DElevation = value.Attributes.DElevation ?? 0;
                result.Attributes.DWidth = value.Attributes.DWidth ?? 0;
            }

            return result;
        }

        public static Asn1J2735.J2735.NodeListXY ToDecode(this J2735_201603.DSRC.NodeListXY? value)
        {
            var result = new Asn1J2735.J2735.NodeListXY();
            foreach (var item in value!.Nodes)
            {
                result.Nodes.NodeXY.Add(item.ToDecode());
            }

            return result;
        }

        public static Asn1J2735.J2735.NodeLL ToDecode(this J2735_201603.DSRC.NodeLL value)
        {
            var result = new Asn1J2735.J2735.NodeLL()
            {
                Delta = new Asn1J2735.J2735.NodeOffsetPointLL()
                {
                    NodeLatLon = new Asn1J2735.J2735.NodeLLmD64b()
                    {
                        Lat = value.Delta.NodeLatLon.Lat.ToDouble(),
                        Lon = value.Delta.NodeLatLon.Lon.ToDouble()
                    }
                }
            };

            if (value.Attributes != null)
            {
                result.Attributes!.Data = value.Attributes.Data.ToDecode();
                result.Attributes.Disabled = value.Attributes.Disabled.ToDecode();
                result.Attributes.LocalNode = value.Attributes.LocalNode.ToDecode();
                result.Attributes.Enabled = value.Attributes.Enabled.ToDecode();
                result.Attributes.DElevation = value.Attributes.DElevation;
                result.Attributes.DWidth = value.Attributes.DWidth;
            }

            return result;
        }

        public static Asn1J2735.J2735.NodeListLL ToDecode(this J2735_201603.DSRC.NodeListLL? value)
        {
            var result = new Asn1J2735.J2735.NodeListLL();
            foreach (var item in value!.Nodes)
            {
                result.Nodes.NodeLL.Add(item.ToDecode());
            }

            return result;
        }

        #endregion

        public static Asn1J2735.J2735.NodeList ToDecode(this J2735_201603.DSRC.OffsetSystem.OffsetType value)
        {
            var result = new Asn1J2735.J2735.NodeList();
            if (value.Xy != null)
            {
                result.Xy = value.Xy.ToDecode();
            }
            else if (value.Ll != null)
            {
                result.Ll = value.Ll.ToDecode();
            }

            return result;
        }

        public static Asn1J2735.J2735.OffsetSystem ToDecode(this J2735_201603.DSRC.OffsetSystem value)
        {
            return new Asn1J2735.J2735.OffsetSystem()
            {
                Scale = value.Scale,
                Offset = value.Offset.ToDecode()


            };
        }


        public static Asn1J2735.J2735.GeometryType ToDecode(this J2735_201603.DSRC.GeographicalPath.DescriptionType value)
        {
            var result = new Asn1J2735.J2735.GeometryType();

            if (value.Path != null)
            {
                result.Path = value.Path.ToDecode();
            }
            else if (value.Geometry != null)
            {
                result.Geometry = value.Geometry.ToDecode();
            }

            return result;
        }


        #endregion

        #region TravelerDataFrameDecode


        public static Asn1J2735.J2735.MessageFrame ToTimDecode(this J2735_201603.DSRC.MessageFrame value)
        {
            var result = new Asn1J2735.J2735.MessageFrame()
            {
                MessageId = value.MessageId
            };

            if (value.Value.Decoded is J2735_201603.DSRC.TravelerInformation)
            {
                var pdu = value.Value.Decoded as J2735_201603.DSRC.TravelerInformation;

                if (pdu == null)
                {
                    throw new Exception("TravelerInformation is null");
                }

                var travelerInformation = new Asn1J2735.J2735.TravelerInformation()
                {
                    MsgCnt = pdu.MsgCnt,
                    DataFrames = new List<Asn1J2735.J2735.TravelerDataFrame>(pdu.DataFrames.Select(d => d.ToDecode())),
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

                result.Value = travelerInformation;
            }

            return result;
        }



        public static Asn1J2735.J2735.TravelerDataFrame ToDecode(this J2735_201603.DSRC.TravelerDataFrame value)
        {
            return new Asn1J2735.J2735.TravelerDataFrame()
            {
                SspTimRights = value.SspTimRights,
                FrameType = (Asn1J2735.J2735.TravelerInfoType)((int)value.FrameType),
                MsgId = value.MsgId.ToDecode(),
                StartYear = value.StartYear,
                StartTime = value.StartTime,
                DurationTime = value.DuratonTime,
                Priority = value.Priority,
                SspLocationRights = value.SspLocationRights,
                Regions = value.Regions.ToDecode(),
                SspMsgRights1 = value.SspMsgRights1,
                SspMsgRights2 = value.SspMsgRights2,
                Content = value.Content!.ToDecode(),
                Url = value.Url
            };
        }

        public static List<Asn1J2735.J2735.GeographicalPath> ToDecode(this J2735_201603.DSRC.TravelerDataFrame.RegionsType value)
        {
            var result = new List<Asn1J2735.J2735.GeographicalPath>();
            foreach (var item in value)
            {
                result.Add(item.ToDecode());
            }

            return result;
        }

        public static Asn1J2735.J2735.MsgIdType ToDecode(this J2735_201603.DSRC.TravelerDataFrame.MsgIdType value)
        {
            var result = new Asn1J2735.J2735.MsgIdType();
            if (value.FurtherInfoID != null)
            {
                result.FurtherInfoID = Encoding.ASCII.GetString(value.FurtherInfoID);
            }
            else if (value.RoadSignID != null)
            {
                result.RoadSignID = new Asn1J2735.J2735.RoadSignId()
                {
                    Position = value.RoadSignID.Position.ToDecode(),
                    ViewAngle = value.RoadSignID.ViewAngle.ToBitString(),
                    MutcdCode = Asn1J2735.J2735.MUTCDCode.None
                }; 
            }
            return result;
        }

        #endregion

    }
    public static class BitStringWithNamedBitsExtensions
    {
        public static Asn1J2735.J2735.HeadingSlice ToHeadingSlice(this BitStringWithNamedBits bitString)
        {
            var boolArray = new bool[bitString.Length];
            for (int i = 0; i < bitString.Length; i++)
            {
                boolArray[i] = bitString[i];
            }
            var str = new string(boolArray.Select(b => b ? '1' : '0').ToArray());
            return str.ToHeadingSlice();
        }

        public static string ToBitString(this BitStringWithNamedBits bitString)
        {
            var stringBuilder = new StringBuilder();
            foreach (var bit in bitString)
            {
                stringBuilder.Append((bool)bit ? "1" : "0");
            }
            return stringBuilder.ToString();
        }
    }




}
