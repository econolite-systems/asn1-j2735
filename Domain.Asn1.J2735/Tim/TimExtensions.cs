using System.Text;
using Econolite.Asn1J2735.J2735;
using Econolite.Asn1J2735.J2735.TimStorage;
using Econolite.Asn1J2735.Tim;
using Econolite.Ode.Domain.Asn1.J2735.Extensions;

namespace Econolite.Ode.Domain.Asn1.J2735.Tim;

public static class TimExtensions
{
    public static MessageFrame ToMessageFrame(this TimMessage value)
    {
        var timeStampYearAndMinutes = value.TimeStamp.ConvertUtcToYearAndMinutes();
        return new MessageFrame()
        {
            MessageId = 31,
            Value = new TravelerInformation()
            {
                MsgCnt = value.DataFrames.Count(),
                TimeStamp = timeStampYearAndMinutes.MinutesSinceYearStart,
                PacketID = Encoding.UTF8.GetBytes(value.PacketId),
                DataFrames = value.DataFrames.Select(frame => frame.ToTravelerInformation())
            }
        };
    }
    
    public static TravelerDataFrame ToTravelerInformation(this TimDataFrameMessage value)
    {
        var startYearTime = value.StartTime.ConvertUtcToYearAndMinutes();
        return new TravelerDataFrame()
        {
            SspTimRights = 0,
            FrameType = value.Content.ToTravelerInfoType(),
            MsgId = value.MsgId,
            StartYear = startYearTime.Year,
            StartTime = startYearTime.MinutesSinceYearStart,
            DurationTime = value.Duration,
            Priority = value.Priority,
            SspLocationRights = 0,
            Regions = value.Regions.ToList(),
            SspMsgRights1 = 0,
            SspMsgRights2 = 0,
            Content = value.Content
        };
    }

    public static TravelerInfoType ToTravelerInfoType(this Content value)
    {
        var result = TravelerInfoType.Unknown;

        if (value.Advisory != null)
        {
            result = TravelerInfoType.Advisory;
        } else if (value.ExitService != null || value.WorkZone != null || value.GenericSign != null)
        {
            result = TravelerInfoType.RoadSignage;
        } else if (value.SpeedLimit != null)
        {
            result = TravelerInfoType.CommercialSignage;
        }
        
        return result;
    }
}