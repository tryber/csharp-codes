namespace Solid.NoDIP;

public class Flight
{
    public Pilot Pilot;

    public Flight()
    {
        Pilot = new Pilot("Rebeca");
        Pilot.AssociatePilotToScale();
    } 
}