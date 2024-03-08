namespace Econolite.Asn1J2735.J2735;

public class VehicleId
{
    public enum Id {
        Unselected = 0,
        EntityIDChosen = 1,
        StationIDChosen = 2
    }
    private Id _id;
    private object? _contained;
    public Id Selected => _id;
    
    public byte[]? EntityId {
        get {
            if (_id == Id.EntityIDChosen)
                return _contained == null ? (_contained as byte[]) : Array.Empty<byte>();
            else
                return null;
        }
        set {
            _contained = value;
            _id = Id.EntityIDChosen;
        }
    }

    public long? StationId {
        get {
            if (_id == Id.StationIDChosen)
                return (_contained as long?);
            else
                return null;
        }
        set {
            _contained = value.HasValue ? value : null;
            if (value == null)
                _id = Id.Unselected;
            else
                _id = Id.StationIDChosen;
        }
    }

    public void Clear()
    {
        _id = Id.Unselected;
        _contained = null;
    }
}