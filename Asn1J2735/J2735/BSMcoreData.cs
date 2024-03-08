namespace Econolite.Asn1J2735.J2735;

public class BSMcoreData
{
    public int MsgCnt { get; set; }
    public byte[] Id { get; set; }
    public int SecMark { get; set; }
    public int Lat { get; set; }
    public int Long { get; set; }
    public int Elev { get; set; }
    public PositionalAccuracy Accuracy { get; set; }
    public TransmissionState Transmission { get; set; }
    public int Speed { get; set; }
    public int Heading { get; set; }
    public int Angle { get; set; }
    public AccelerationSet4Way AccelSet { get; set; }
    public BrakeSystemStatus Brakes { get; set; }
    public VehicleSize Size { get; set; }
}