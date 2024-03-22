namespace Airline;

public class MainClass
{
    public static void Main(string[] args)
    {
        PassengerAirplane embraer = new PassengerAirplane("PR-ABC", 110);
        CargoAirplane boeing = new CargoAirplane("PT-DEF", 88000);

        Flight flightA = new Flight("001", 500);
        Flight flightB = new Flight("002", 200);

        flightA.Airplane = embraer;
        flightB.Airplane = boeing;

        flightA.Load();
        flightB.Load();

        Console.WriteLine(flightA.Airplane.Prefix + " - " + flightA.CalculateCost().ToString());
    }
}