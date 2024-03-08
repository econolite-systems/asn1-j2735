namespace Econolite.Asn1J2735.J2735;

public class IntersectionAccessPoint
{
    public enum Id {
        Unselected = 0,
        LaneChosen = 1,
        ApproachChosen = 2,
        ConnectionChosen = 3
    }
    private Id _id;
    private object? _contained;

    public Id Selected => _id;
    
    public int? Lane {
        get {
            if (_id == Id.LaneChosen)
                return (_contained as int?);
            else
                return null;
        }
        set
        {
            _contained = value.HasValue ? value : null;
            if (value == null)
                _id = Id.Unselected;
            else
                _id = Id.LaneChosen;
        }
    }

    public int? Approach {
        get {
            if (_id == Id.ApproachChosen)
                return (_contained as int?);
            else
                return null;
        }
        set {
            _contained = value.HasValue ? value : null;
            if (value == null)
                _id = Id.Unselected;
            else
                _id = Id.ApproachChosen;
        }
    }

    public int? Connection {
        get {
            if (_id == Id.ConnectionChosen)
                return (_contained as int?);
            else
                return null;
        }
        set {
            _contained = value.HasValue ? value : null;
            if (value == null)
                _id = Id.Unselected;
            else
                _id = Id.ConnectionChosen;
        }
    }
    
    public void Clear()
    {
        _id = Id.Unselected;
        _contained = null;
    }
}