using Econolite.Asn1J2735.J2735;
using Econolite.Asn1J2735.J2735.TimStorage;
using Econolite.Ode.Domain.Asn1.J2735.Extensions;
using FluentAssertions;

namespace Econolite.Ode.Domain.Asn1.J2735.Mapping;

public class TimMappingTests
{
    [Fact]
    public void MapTim_ToMessageFrame_WithGeometry()
    {
        var messageFrame = new Asn1J2735.J2735.MessageFrame()
        {
            MessageId = 31,
            Value = new TravelerInformation()
            {
                MsgCnt = 1,
                DataFrames = new List<Asn1J2735.J2735.TravelerDataFrame>()
                {
                    new Asn1J2735.J2735.TravelerDataFrame()
                    {
                        SspTimRights = 6,
                        FrameType = TravelerInfoType.Advisory,
                        MsgId = new MsgIdType()
                        {
                            FurtherInfoID = "00000084",
                        },
                        StartYear = 2023,
                        StartTime = 1,
                        DurationTime = 1,
                        Priority = 4,
                        SspLocationRights = 6,
                        Regions = new List<GeographicalPath>()
                        {
                            new()
                            {
                                Name = "GP",
                                LaneWidth = 15,
                                ClosedPath = false,
                                Id = new RoadSegmentReferenceId()
                                {
                                    Id = 1,
                                    Region = 1
                                },
                                Anchor = new Position3d()
                                {
                                    Longitude = -90,
                                    Latitude = 45
                                },
                                Directionality = DirectionOfUse.Forward,
                                Direction = "0000000000000011",
                                Description = new GeometryType()
                                {
                                    Geometry = new GeometricProjection()
                                    {
                                        Circle = new Circle()
                                        {
                                            Center = new Position3d()
                                            {
                                                Longitude = -90,
                                                Latitude = 45
                                            },
                                            Radius = 2,
                                            Units = DistanceUnits.mile
                                        },
                                        Extent = Extent.UseInstantlyOnly
                                    }
                                }
                            }
                        },
                        SspMsgRights1 = 6,
                        SspMsgRights2 = 3,
                        Content = new Content()
                        {
                            Advisory = new ItisCodesAndText()
                            {
                                Items = new[] {new Item() {Itis = 534}}
                            }
                        }
                    }
                }
            }
        };
        var result = messageFrame.ToTimEncode();

        result.Value.Should().NotBeNull();
    }


    [Fact]
    public void MapTim_ToMessageFrame_WithGeometry_And_ToDecode()
    {
        var messageFrame = new Asn1J2735.J2735.MessageFrame()
        {
            MessageId = 31,
            Value = new TravelerInformation()
            {
                MsgCnt = 1,
                DataFrames = new List<Asn1J2735.J2735.TravelerDataFrame>()
                {
                    new Asn1J2735.J2735.TravelerDataFrame()
                    {
                        SspTimRights = 6,
                        FrameType = TravelerInfoType.Advisory,
                        MsgId = new MsgIdType()
                        {
                            FurtherInfoID = "00000084",
                        },
                        StartYear = 2023,
                        StartTime = 1,
                        DurationTime = 1,
                        Priority = 4,
                        SspLocationRights = 6,
                        Regions = new List<GeographicalPath>()
                        {
                            new()
                            {
                                Name = "GP",
                                LaneWidth = 15,
                                ClosedPath = false,
                                Id = new RoadSegmentReferenceId()
                                {
                                    Id = 1,
                                    Region = 1
                                },
                                Anchor = new Position3d()
                                {
                                    Longitude = -90,
                                    Latitude = 45
                                },
                                Directionality = DirectionOfUse.Forward,
                                Direction = "0000000000000011",
                                Description = new GeometryType()
                                {
                                    Geometry = new GeometricProjection()
                                    {
                                        Circle = new Circle()
                                        {
                                            Center = new Position3d()
                                            {
                                                Longitude = -90,
                                                Latitude = 45
                                            },
                                            Radius = 2,
                                            Units = DistanceUnits.mile
                                        },
                                        Extent = Extent.UseInstantlyOnly
                                    }
                                }
                            }
                        },
                        SspMsgRights1 = 6,
                        SspMsgRights2 = 3,
                        Content = new Content()
                        {
                            Advisory = new ItisCodesAndText()
                            {
                                Items = new[] {new Item() {Itis = 534}}
                            }
                        }
                    }
                }
            }
        };
        var encodedResult = messageFrame.ToTimEncode();
        var decodedResult = encodedResult.ToTimDecode();
        decodedResult.Value.Should().NotBeNull();
    }




    [Fact]
    public void MapTim_ToMessageFrame_WithPath()
    {
        var travelerDataFrame = new Asn1J2735.J2735.TravelerDataFrame()
        {
            SspTimRights = 6,
            FrameType = TravelerInfoType.Advisory,
            MsgId = new MsgIdType()
            {
                FurtherInfoID = "00000084",
            },
            StartYear = 2023,
            StartTime = 1,
            DurationTime = 1,
            Priority = 4,
            SspLocationRights = 6,
            Regions = new List<GeographicalPath>()
            {
                new()
                {
                    Name = "GP",
                    LaneWidth = 15,
                    ClosedPath = false,
                    Id = new RoadSegmentReferenceId()
                    {
                       Id = 1,
                       Region = 1
                    },
                    Anchor = new Position3d()
                    {
                        Longitude = -90,
                        Latitude = 45
                    },
                    Directionality = DirectionOfUse.Forward,
                    Direction = "0000000000000011",
                    Description = new GeometryType()
                    {
                        Path = new OffsetSystem()
                        {
                            Offset = new NodeList()
                            {

                            }
                        }
                    }
                }
            },
            SspMsgRights1 = 6,
            SspMsgRights2 = 3,
            Content = new Content()
            {
                Advisory = new ItisCodesAndText()
                {
                    Items = new[] { new Item() { Itis = 534 } }
                }
            }
        };
        var result = travelerDataFrame.ToEncode();

        result.Should().NotBeNull();
    }

    [Fact]
    public void MapTim_ToMessageFrame_WithPath_And_ToDecode()
    {
        var travelerDataFrame = new Asn1J2735.J2735.TravelerDataFrame()
        {
            SspTimRights = 6,
            FrameType = TravelerInfoType.Advisory,
            MsgId = new MsgIdType()
            {
                FurtherInfoID = "00000084",
            },
            StartYear = 2023,
            StartTime = 1,
            DurationTime = 1,
            Priority = 4,
            SspLocationRights = 6,
            Regions = new List<GeographicalPath>()
            {
                new()
                {
                    Name = "GP",
                    LaneWidth = 15,
                    ClosedPath = false,
                    Id = new RoadSegmentReferenceId()
                    {
                       Id = 1,
                       Region = 1
                    },
                    Anchor = new Position3d()
                    {
                        Longitude = -90,
                        Latitude = 45
                    },
                    Directionality = DirectionOfUse.Forward,
                    Direction = "0000000000000011",
                    Description = new GeometryType()
                    {
                        Path = new OffsetSystem()
                        {
                            Offset = new NodeList()
                            {

                            }
                        }
                    }
                }
            },
            SspMsgRights1 = 6,
            SspMsgRights2 = 3,
            Content = new Content()
            {
                Advisory = new ItisCodesAndText()
                {
                    Items = new[] { new Item() { Itis = 534 } }
                }
            }
        };
        var result = travelerDataFrame.ToEncode();
        var decodedResult = result.ToDecode();
        decodedResult.Should().NotBeNull();
    }

    [Fact]
    public void DateTime_ConvertTo_RFC2579DateTime()
    {
        var dateTime = new DateTime(2017, 10, 7, 23, 34, 00, DateTimeKind.Utc);
        var result = dateTime.ToRFC2579DateTime();

        result.Should().Match("07e10a071722");
    }

    [Fact]
    public void RFC2579DateTime_ConvertTo_DateTime()
    {
        var dateTime = "07e10a071722";
        var result = dateTime.ToDateTime();

        result.Should().HaveYear(2017);
        result.Should().HaveMonth(10);
        result.Should().HaveDay(7);
        result.Should().HaveHour(23);
        result.Should().HaveMinute(34);
    }
}

