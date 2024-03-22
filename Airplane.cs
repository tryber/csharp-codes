namespace Airline;

public abstract class Airplane : IAirplane
{
    public string Prefix { get; set; }

    public Airplane(string Prefix)
    {
        this.Prefix = Prefix;
    }
    public abstract double CalculateCost();
    public double CalculateStandardCost()
    {
        return 1352.45;
    }
}