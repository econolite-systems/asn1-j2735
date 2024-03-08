using FluentAssertions;

namespace Econolite.Ode.Domain.Asn1.J2735.Extensions;

public class DateTimeConversionTests
{
    [Fact] 
    public void DateTime_ConvertTo_RFC2579DateTime()
    {
        var dateTime = new DateTime(2017, 10, 7, 23, 34, 00, DateTimeKind.Utc);
        var result = dateTime.ToRfc2579DateTime();
        result.Should().Be("07e10a071722");
    }
    
    [Fact] 
    public void RFC2579DateTime_ConvertTo_DateTime()
    {
        var dateTime = new DateTime(2017, 10, 7, 23, 34, 00, DateTimeKind.Utc);
        var hex = "07e10a071722";
        var result = hex.ToDateTimeUtc();
        result.Should().Be(dateTime);
    }
    
    [Fact]
    public void ConvertUtcToYearAndMinutes_ShouldReturnCorrectValues_Case1()
    {
        var testDateTime = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var (year, minutesSinceYearStart) = testDateTime.ConvertUtcToYearAndMinutes();

        year.Should().Be(2023);
        minutesSinceYearStart.Should().Be(0);
    }

    [Fact]
    public void ConvertUtcToYearAndMinutes_ShouldReturnCorrectValues_Case2()
    {
        var testDateTime = new DateTime(2023, 1, 1, 1, 0, 0, DateTimeKind.Utc);
        var (year, minutesSinceYearStart) = testDateTime.ConvertUtcToYearAndMinutes();

        year.Should().Be(2023);
        minutesSinceYearStart.Should().Be(60);
    }

    [Fact]
    public void ConvertUtcToYearAndMinutes_ShouldReturnCorrectValues_Case3()
    {
        var testDateTime = new DateTime(2023, 3, 16, 12, 30, 0, DateTimeKind.Utc);
        var (year, minutesSinceYearStart) = testDateTime.ConvertUtcToYearAndMinutes();

        year.Should().Be(2023);
        minutesSinceYearStart.Should().Be(107310);
    }

    [Fact]
    public void ConvertUtcToYearAndMinutes_ShouldReturnCorrectValues_Case4()
    {
        var testDateTime = new DateTime(2023, 12, 31, 23, 59, 0, DateTimeKind.Utc);
        var (year, minutesSinceYearStart) = testDateTime.ConvertUtcToYearAndMinutes();

        year.Should().Be(2023);
        minutesSinceYearStart.Should().Be(525599);
    }
}
