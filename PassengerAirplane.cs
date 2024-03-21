namespace Airline;

public class PassengerAirplane : Airplane
{
    private int PassengerCapacity { get; set; }
    private int PassengerQuantity = 0;
    

    public PassengerAirplane(string Prefix, int PassengerCapacity) : base(Prefix)
    {
        this.PassengerCapacity = PassengerCapacity;
    }

    public override void Load()
    {
        if (PassengerQuantity == PassengerCapacity) throw new ArgumentException("No seats left");
        PassengerQuantity += 1;
    }

    public override double CalculateCost()
    {
        return CalculateStandardCost() + 90 * PassengerQuantity;
    }

}