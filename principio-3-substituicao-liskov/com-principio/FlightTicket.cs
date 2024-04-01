namespace Solid.LSP;

public class FlightTicket
{
    private string FlightTicketId = "";
    private string FlightId = "";
    private Client Client = null!;

    public FlightTicket(string FlightTicketId, string FlightId)
    {
        this.FlightTicketId = FlightTicketId;
        this.FlightId = FlightId;
    }

    public void BuyFlightTicket(Client client)
    {
        this.Client = client;
        Console.WriteLine($"Client {this.Client} - FlightId {this.FlightId} - FlightTicketId {this.FlightTicketId}");
        
    }
}