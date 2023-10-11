namespace colecoes;
public class Program
{
    public static void Main(string[] args)
    {
        List<string> cars = new List<string>(){ "Fusca", "Brasília" };
        cars.Remove("Fusca");

        cars.ForEach(car => {
            Console.WriteLine(car);
        });
    }
}