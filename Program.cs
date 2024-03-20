namespace Airline;

public class MainClass
{
    public static void Main(string[] args)
    {
        Airplane embraer = new Airplane("PR-ABC");
        Flight flightA = new Flight("001", 500);
        flightA.Airplane = embraer;

        Console.WriteLine(flightA.Airplane.Prefix + " - " + flightA.CalculateCost().ToString());
    }
}