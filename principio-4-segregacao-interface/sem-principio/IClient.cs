namespace Solid.NoISP;

public interface IClient
{
    void BuyFlightTicket(FlightTicket flightTicket);
    void AddPremiumClientPoints(int Points);
}