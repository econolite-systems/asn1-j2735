using Econolite.Asn1J2735.J2735;
using Econolite.Asn1J2735.J2735.TimStorage;
using Econolite.Asn1J2735.Tim;
using FluentAssertions;

namespace Econolite.Ode.Domain.Asn1.J2735;

public class Asn1J2735ServiceTests
{
    [Fact]
    public void Encode_TimMessage_ToHexString()
    {
        var timMessage = new TimMessage()
        {
            DataFrames = new List<TimDataFrameMessage>()
            {
                new TimDataFrameMessage()
                {
                    MsgId = new MsgIdType()
                    {
                        FurtherInfoID = "83"
                    },
                    StartTime = new DateTime(2023, 4, 7),
                    Duration = 300,
                    Priority = 4,
                    Regions = new List<GeographicalPath>()
                    {
                        new GeographicalPath()
                        {
                            Anchor = new Position3d()
                            {
                                Latitude = 41.678473,
                                Longitude = -108.782775,
                                Elevation = 917.1432
                            },
                            Name = "Bob",
                            Direction = "0000000000000001",
                            Description = new GeometryType()
                            {
                                Geometry = new GeometricProjection()
                                {
                                    Circle = new Circle()
                                    {
                                        Center = new Position3d()
                                        {
                                            Latitude = 41.678473,
                                            Longitude = -108.782775,
                                            Elevation = 917.1432
                                        },
                                        Radius = 15,
                                        Units = DistanceUnits.foot
                                    },
                                    Direction = "0000000000000001",
                                }
                            }
                        }
                    },
                    Content = new Content()
                    {
                        Advisory = new ItisCodesAndText()
                        {
                            Items = new List<Item>()
                            {
                               new Item()
                               {
                                   Itis = 513
                               } 
                            }
                        }
                    }
                }
            }
        };

        var service = new Asn1J2735Service();
        var encoded = service.EncodeTim(timMessage);

        encoded.Should().NotBeEmpty();
    }

    [Fact]
    public void Decode_MessageFrame_FromString()
    {
        var message =
            "001338000817a780000089680500204642b342b34802021a15a955a940181190acd0acd20100868555c555c00104342aae2aae002821a155715570";
        var service = new Asn1J2735Service();
        var decoded = service.DecodeSpat(message);
        decoded.Should().NotBeNull();
    }
}