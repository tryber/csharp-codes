class Car
{
    public double TopSpeed { get; set; }
    public bool IsAutomatic { get; set; }
    public int NumberOfSeats { get; set; }

    public int EngineHorsepower { get; set; }
    public int EngineTorque { get; set; }
    public int EngineCapacity { get; set; }
    public bool IsEngineStarted { get; set; }

    public void Drive(double distanceKm, double speed)
    {
        if (speed > TopSpeed)
            Console.WriteLine("Your car can't go that fast!");
        else if (!IsEngineStarted)
            Console.WriteLine("Your car isn't turned on!");
        else
        {
            var time = distanceKm / speed;
            Console.WriteLine($"You arrived in {time} hours.");
        }
    }

    public void StartEngine()
    {
        if (IsEngineStarted)
            Console.WriteLine("The engine is already started!");
        else
            IsEngineStarted = true;
    }

    public void StopEngine()
    {
        if (!IsEngineStarted)
            Console.WriteLine("The engine is already stopped!");
        else
            IsEngineStarted = false;
    }
}