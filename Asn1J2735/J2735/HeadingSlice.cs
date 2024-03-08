namespace Econolite.Asn1J2735.J2735;

[Flags]
public enum HeadingSlice
{
    None = 0,
    From0To22_5 = 1,
    From22_5To45 = 2,
    From45To67_5 = 4,
    From67_5To90 = 8,
    From90To112_5 = 16,
    From112_5To135 = 32,
    From135To157_5 = 64,
    From157_5To180 = 128,
    From180To202_5 = 256,
    From202_5To225 = 512,
    From225To247_5 = 1024,
    From247_5To270 = 2048,
    From270To292_5 = 4096,
    From292_5To315 = 8192,
    From315To337_5 = 16384,
    From337_5To360 = 32768
}

public static class HeadingSliceExtensions
{
    public static string ToBitString(this HeadingSlice? slice)
    {
        if (slice == null) return "";
        var charArray = Convert.ToString((int) slice, 2).PadLeft(16, '0').Reverse().ToArray();
        return new string(charArray);
    }

    public static HeadingSlice ToHeadingSlice(this string bitString)
    {
        var charArray = bitString.Reverse().ToArray();
        return (HeadingSlice) Convert.ToInt32(new string(charArray), 2);
    }
}