namespace Solid.NoISP;

public class Client: IClient
{
    public string Name;

    public Client(string Name)
    {
        this.Name = Name;
    }

    public virtual void BuyFlightTicket(FlightTicket flightTicket)
    {
        flightTicket.BuyFlightTicket(this);
    }
    public virtual void AddPremiumClientPoints(int Points)
    {

    }
    
}