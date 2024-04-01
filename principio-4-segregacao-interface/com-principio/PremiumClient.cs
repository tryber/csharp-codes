namespace Solid.ISP;

public class PremiumClient : Client, IPremiumClient
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

    public override void BuyFlightTicket(FlightTicket flightTicket)
    {
        flightTicket.BuyFlightTicket(this);
        // alguma implementação com os pontos.
        
    }

}