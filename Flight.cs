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

     public double CalculateCost()
    {
        return Airplane.CalculateCost();
    }
}