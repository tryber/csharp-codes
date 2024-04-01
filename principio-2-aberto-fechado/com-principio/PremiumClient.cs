namespace Solid.OC;

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
}