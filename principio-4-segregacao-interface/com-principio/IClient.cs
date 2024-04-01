namespace Solid.ISP;

public interface IClient
{
    void BuyFlightTicket(FlightTicket flightTicket);
    
}

public interface IPremiumClient : IClient
{
       void AddPremiumClientPoints(int Points);
}