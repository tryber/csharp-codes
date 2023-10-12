namespace colecoes;

public class Car {
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public float Price { get; set; }
}

public class Category {
    public string? Name;
    public List<Car>? Cars;
}

public class Program
{
    
    public static void Main(string[] args)
    {
       
        List<Car> cars = new List<Car>
        {
            new Car { Brand = "Ferrari", Model = "LaFerrari", Price = 7100000 },
            new Car { Brand = "McLaren", Model = "Elva", Price = 8600000 },
            new Car { Brand = "Bentley", Model = "Mulliner Batur", Price = 10200000 },
            new Car { Brand = "Aston Martin", Model = "Valkyrie", Price = 16300000 },
            new Car { Brand = "BMW", Model = "IX", Price = 670000 },
            new Car { Brand = "Bugatti", Model = "Divo", Price = 26000000 },
            new Car { Brand = "Ferrari", Model = "F8 Spider", Price = 5200000 },
            new Car { Brand = "McLaren", Model = "Speedtail", Price = 40000000 },
            new Car { Brand = "Koenigsegg", Model = "Agera", Price = 7500000 },
            new Car { Brand = "Devel", Model = "Sixteen", Price = 79000020 }
        };

        var carsOrderedByPrice = cars.OrderBy(car => car.Price);

        foreach(var carOrderedByPrice in carsOrderedByPrice)
        {
            Console.WriteLine($"{carOrderedByPrice.Brand} {carOrderedByPrice.Model} - Preço: R$ {carOrderedByPrice.Price}");
        }

    }
}
