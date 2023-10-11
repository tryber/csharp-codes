class Rocket
{
    string Name { get; set; }
    int Fuel { get; set }
    decimal Price { get; set; }

    public Rocket(string name, decimal price)
    {
        Name = name;
        Fuel = 0;
        Price = price;
    }
}