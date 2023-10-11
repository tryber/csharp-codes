class Bakery
{
    public Bread fabricateBread(int weight)
    {
        return new Bread
        {
            Weight = weight,
            Type = "White"
        };
    }

    public Cake fabricateChocolateCake(string size)
    {
        return new Cake
        {
            Size = size,
            Flavour = "Chocolate"
        };
    }
}