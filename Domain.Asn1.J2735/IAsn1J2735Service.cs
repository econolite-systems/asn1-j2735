using Econolite.Asn1J2735.J2735;
using Econolite.Asn1J2735.Tim;

namespace Econolite.Ode.Domain.Asn1.J2735;

public interface IAsn1J2735Service
{
    BasicSafetyMessage? DecodeBsm(string message);
    string EncodeTim(TimMessage message);
    Spat? DecodeSpat(string message);
    string EncodeSsm(MessageFrame message);
    SignalStatusMessage? DecodeSsm(string message);
    SignalRequestMessage? DecodeSrm(string message);
}