namespace Airline;

public interface IAirplane
{
    string Prefix { get; set; }
    double CalculateCost();
}