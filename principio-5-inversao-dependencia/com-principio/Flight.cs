namespace Solid.DIP;

public class Flight
{
    public IPilot Pilot;

    public Flight(IPilot pilot)
    {
        this.Pilot = pilot;
        Pilot.AssociatePilotToScale();
    } 
}