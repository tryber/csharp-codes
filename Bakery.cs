public class Bakery
{
    public string Name { get; set; }
    public string Owner { get; set; }

    public Bakery(string name, string owner)
    {
        Name = name;
        Owner = owner;
    }

    public void BakeCake()
    {
        Console.WriteLine($"Bakery {Name} is baking a cake...");
    }
}