namespace Airline;

public class MainClass
{
    public static void Main(string[] args)
    {
        PassengerAirplane embraer = new PassengerAirplane("PR-ABC", 110);
        Flight flightA = new Flight("001", 500);
        flightA.Airplane = embraer;

        embraer.Load();

        Console.WriteLine(flightA.Airplane.Prefix + " - " + flightA.CalculateCost().ToString());
    }
}