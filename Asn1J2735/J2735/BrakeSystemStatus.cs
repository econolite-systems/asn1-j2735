namespace Econolite.Asn1J2735.J2735;

public class BrakeSystemStatus
{
    public BitString WheelBrakes { get; set; } = new BitString();
    public TractionControlStatus Traction { get; set; } = TractionControlStatus.Unavailable;
    public AntiLockBrakeStatus Abs { get; set; } = AntiLockBrakeStatus.Unavailable;
    public StabilityControlStatus Scs { get; set; } = StabilityControlStatus.Unavailable;
    public BrakeBoostApplied BrakeBoost { get; set; } = BrakeBoostApplied.Unavailable;
    public AuxiliaryBrakeStatus AuxBrakes { get; set; } = AuxiliaryBrakeStatus.Unavailable;
}