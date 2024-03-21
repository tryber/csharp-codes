namespace Airline;

public interface IAirplane
{
    string Prefix { get; set; }
    void Load();
    void Load(double weight);
    double CalculateCost();
}