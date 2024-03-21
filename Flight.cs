namespace Airline;

public class Flight
{
    public string FlightId { get; set; }
    public double Distance;

    private string _FlightType;
    private IAirplane? _Airplane;
    public IAirplane? Airplane { 
        get { return _Airplane } 
        set
        {
            if (value.GetType() == typeof(PassengerAirplane))
            {
                _FlIghtType = "Commercial";
            }
            else
            {
                _FlightType = "Cargo";
            }
            _Airplane = value;
        } 
    }

    public Flight(string FlightId, double Distance)
    {
        this.FlightId = FlightId;
        this.Distance = Distance;
    }

    public void Load()
    {
        if (_Airplane is null) throw new InvalidDataException("Airplane not defined");
        if (_FlightType == "Cargo") throw new ArgumentException("Cargo flights must specify a load weight");
        _Airplane.Load();
    }

    public void Load(double weight)
    {
        if (_Airplane is null) throw new InvalidDataException("Airplane not defined");
        if (_FlightType == "Commercial") throw new ArgumentException("Commercial flights must not specify a load");
        _Airplane.Load(weight);
    }

     public double CalculateCost()
    {
        if (_Airplane is null) throw new InvalidDataException("Airplane not defined");
        return 20 * Distance + _Airplane!.CalculateCost();
    }
}