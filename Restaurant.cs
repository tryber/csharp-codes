public class Restaurant
{
    public string Name { get; set; }
    public string Owner { get; set; }

    public Restaurant(string name, string owner)
    {
        Name = name;
        Owner = owner;
    }

    public void CookMeal()
    {
        Console.WriteLine($"Restaurant {Name} is cooking a meal...");
    }
}