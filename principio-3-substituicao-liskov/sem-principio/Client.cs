namespace Solid.NoLSP;

public class Client
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

    
}