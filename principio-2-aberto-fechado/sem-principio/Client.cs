namespace Solid.NoOC;

public class Client
{
    public string Name;
    private int Points;

    public Client(string Name)
    {
        this.Name = Name;
        this.Points = 0;
    }

    public void BuyFlightTicket(FlightTicket flightTicket)
    {
        flightTicket.BuyFlightTicket(this);
    }

    public void AddPremiumClientPoints(int Points)
    {
        this.Points += Points;
    }   
}