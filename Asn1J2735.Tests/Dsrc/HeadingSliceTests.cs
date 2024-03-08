using Econolite.Asn1J2735.J2735;
using FluentAssertions;

namespace Asn1J2735.Tests.Dsrc;

public class HeadingSliceTests
{
    [Fact]
    public void HeadingSlice_ConversionTo_BitString()
    {
        HeadingSlice? input = HeadingSlice.From0To22_5 | HeadingSlice.From22_5To45 | HeadingSlice.From337_5To360;
        var result = input.ToBitString();
        result.Should().NotBeEmpty();
    }

    [Fact]
    public void BitString_ConversionTo_HeadingSlice()
    {
        var input = "1100000000000001";
        var result = input.ToHeadingSlice();
        result.Should().HaveFlag(HeadingSlice.From0To22_5);
    }
}