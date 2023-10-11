public abstract class Animal
{
    public int Age { get; set; }
    public abstract string EatingHabits { get; set; }
    public abstract string Habitat { get; set; }

    public abstract void Feed();
    public abstract void Move();

    public void Sleep()
    {
        Console.WriteLine("Zzzz");
    }
}