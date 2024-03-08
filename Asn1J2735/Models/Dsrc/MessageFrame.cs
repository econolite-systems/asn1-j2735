using Econolite.Asn1J2735.J2735;

namespace Econolite.Asn1J2735.Models.Dsrc;

public class MessageFrame : IPdu
{
    public int MessageId { get; set; }
    public IPdu Value { get; set; }
}