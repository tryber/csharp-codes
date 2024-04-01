namespace Solid.NoLSP;

public class PremiumClient : Client
{
    private int Points;

    public PremiumClient(string Name) : base(Name)
    {
        this.Points = 0;
    }

    public void AddPremiumClientPoints(int Points)
    {
        this.Points += Points;
    }

    public override FlightTicket BuyFlightTicket(FlightTicket flightTicket, int Points)
    {
        flightTicket.BuyFlightTicket(this);
        return flightTicket;
    }

}