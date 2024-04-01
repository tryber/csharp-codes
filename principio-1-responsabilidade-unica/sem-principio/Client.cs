namespace Solid.NoSRP;

public class Client
{
    private string Name;
    private string FlightTicketId = "";
    private string FlightId = "";

    public Client(string Name)
    {
        this.Name = Name;
    }

    public void BuyFlightTicket(string FlightTicketId, string FlightId)
    {
        this.FlightTicketId = FlightTicketId;
        this.FlightId = FlightId;
        Console.WriteLine($"Client {Name} - FlightId {this.FlightId} - FlightTicketId {this.FlightTicketId}");
    }
}