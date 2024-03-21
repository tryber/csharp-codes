namespace Airline;

public class CargoAirplane : Airplane
{
    private double Payload { get; set; }
    private double LoadedWeight { get; set; }
    
    public CargoAirplane(string Prefix, double Payload) : base (Prefix)
    {
        this.Payload = Payload;
    }

    public override void Load(double weight)
    {
        if ((LoadedWeight + weight) > Payload) throw new ArgumentException("Payload achieved");
        LoadedWeight += weight;
    }

    public override double CalculateCost()
    {
        return 0;
    }

}