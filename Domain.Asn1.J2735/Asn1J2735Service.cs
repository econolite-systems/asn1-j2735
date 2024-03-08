using System.Text;
using Econolite.Asn1J2735.J2735;
using Econolite.Asn1J2735.Tim;
using Econolite.J2735_201603.DSRC;
using Econolite.Ode.Domain.Asn1.J2735.Mapping;
using Econolite.Ode.Domain.Asn1.J2735.Tim;
using BasicSafetyMessage = Econolite.J2735_201603.DSRC.BasicSafetyMessage;
using MessageFrame = Econolite.J2735_201603.DSRC.MessageFrame;
using SignalRequestMessage = Econolite.J2735_201603.DSRC.SignalRequestMessage;
using SignalStatusMessage = Econolite.J2735_201603.DSRC.SignalStatusMessage;

namespace Econolite.Ode.Domain.Asn1.J2735;

public class Asn1J2735Service : IAsn1J2735Service
{
    public Econolite.Asn1J2735.J2735.BasicSafetyMessage? DecodeBsm(string message)
    {
        try
        {
            var bsm = Decode<BasicSafetyMessage>(message);
            return bsm?.ToDecode();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
    
    public string EncodeTim(TimMessage message)
    {
        try
        {
            var messageFrame = message.ToMessageFrame();
            var encodingMessageFrame = messageFrame.ToTimEncode();
            return Encode(encodingMessageFrame);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return string.Empty;
        }
    }

    public Spat? DecodeSpat(string message)
    {
        try
        {
            var spat = Decode<SPAT>(message);
            return spat?.ToDecode();
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return null;
        }
    }
    
    public string EncodeSsm(Econolite.Asn1J2735.J2735.MessageFrame message)
    {
        try
        {
            var encodingMessageFrame = message.ToSsmEncode();
            return Encode(encodingMessageFrame);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return string.Empty;
        }
    }
    
    public Econolite.Asn1J2735.J2735.SignalStatusMessage? DecodeSsm(string message)
    {
        try
        {
            var ssm = Decode<SignalStatusMessage>(message);
            return ssm?.ToDecode();
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            System.Console.WriteLine();
            return null;
        }
    }
    
    public Econolite.Asn1J2735.J2735.SignalRequestMessage? DecodeSrm(string message)
    {
        try
        {
            var ssm = Decode<SignalRequestMessage>(message);
            return ssm?.ToDecode();
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return null;
        }
    }

    private string Encode(MessageFrame message)
    {
        var codec = new J2735_201603.PerUnalignedCodec();
        var stream = new MemoryStream();
        try
        {
            // encode the PDU to a stream
            codec.Encode(message, stream);

            // obtain encoded bytes
            byte[] encoding = stream.ToArray();
            System.Console.WriteLine("PDU successfully encoded, in " + encoding.Length + " bytes");

            // print encoded bytes
            Console.WriteLine("Encoded value:");
            return BitConverter.ToString(encoding).Replace("-", string.Empty);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return string.Empty;
        }
    }
    
    private T? Decode<T>(string message) where T : class
    {
        var codec = new J2735_201603.PerUnalignedCodec();
        var stream = new MemoryStream();
        try
        {
            // decode the PDU from a stream
            stream.Write(StringToByteArray(message));
            stream.Position = 0;
            var toDecode = new MessageFrame();
            var messageFrame = codec.Decode(stream, toDecode);
            return toDecode.Value.Decoded as T;
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return null;
        }
    }
    
    private byte[] StringToByteArray(string message)
    {
        var numberChars = message.Length;
        var bytes = new byte[numberChars / 2];
        for (var i = 0; i < numberChars; i += 2)
            bytes[i / 2] = Convert.ToByte(message.Substring(i, 2), 16);
        return bytes;
    }
}

public static class Asn1J2735Encode
{
    public static string Encode(this TimMessage message)
    {
        var messageFrame = message.ToMessageFrame();
        var encodingMessageFrame = messageFrame.ToTimEncode();
        var codec = new J2735_201603.PerUnalignedCodec();
        var stream = new MemoryStream();
        try
        {
            // encode the PDU to a stream
            codec.Encode(encodingMessageFrame, stream);

            // obtain encoded bytes
            byte[] encoding = stream.ToArray();
            System.Console.WriteLine("PDU successfully encoded, in " + encoding.Length + " bytes");

            // print encoded bytes
            Console.WriteLine("Encoded value:");
            return BitConverter.ToString(encoding).Replace("-", string.Empty);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            System.Console.WriteLine();
            return string.Empty;
        }
    }
    
    public static string Encode(this Econolite.Asn1J2735.J2735.MessageFrame message)
    {
        var messageFrame = message;
        var encodingMessageFrame = messageFrame.ToSsmEncode();
        var codec = new J2735_201603.PerUnalignedCodec();
        var stream = new MemoryStream();
        try
        {
            // encode the PDU to a stream
            codec.Encode(encodingMessageFrame, stream);

            // obtain encoded bytes
            byte[] encoding = stream.ToArray();
            System.Console.WriteLine("PDU successfully encoded, in " + encoding.Length + " bytes");

            // print encoded bytes
            Console.WriteLine("Encoded value:");
            return BitConverter.ToString(encoding).Replace("-", string.Empty);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            System.Console.WriteLine();
            return string.Empty;
        }
    }
}