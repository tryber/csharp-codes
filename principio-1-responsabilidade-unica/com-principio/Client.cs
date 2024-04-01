namespace Solid.SRP;

public class Client
{
    public string Name;

    public Client(string Name)
    {
        this.Name = Name;
    }

    public void BuyFlightTicket(FlightTicket flightTicket)
    {
        flightTicket.BuyFlightTicket(this);
    }
}