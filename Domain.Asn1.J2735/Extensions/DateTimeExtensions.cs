namespace Econolite.Ode.Domain.Asn1.J2735.Extensions;

public static class DateTimeExtensions
{
    public static DateTime ToDateTimeUtc(this string hex)
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
    
    public static string ToRfc2579DateTime(this DateTime dateTime)
    {
        if (dateTime.Kind != DateTimeKind.Utc)
        {
            dateTime = dateTime.ToUniversalTime();
        }
        
        var year = dateTime.Year.ToString("x4");
        var month = dateTime.Month.ToString("x2");
        var day = dateTime.Day.ToString("x2");
        var hour = dateTime.Hour.ToString("x2");
        var minute = dateTime.Minute.ToString("x2");

        return $"{year}{month}{day}{hour}{minute}";
    }
    
    public static (int Year, int MinutesSinceYearStart) ConvertUtcToYearAndMinutes(this DateTime utcDateTime)
    {
        var year = utcDateTime.Year;
        var startOfYear = new DateTime(year, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var timeDifference = utcDateTime - startOfYear;
        var minutesSinceYearStart = (int)timeDifference.TotalMinutes;

        return (year, minutesSinceYearStart);
    }
}