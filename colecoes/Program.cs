namespace colecoes;
public class Program
{
    public static void Main(string[] args)
    {
        List<string> cars = new List<string>(){ "Fusca", "Brasília" };
        cars.RemoveAt(1);

        cars.ForEach(car => {
            Console.WriteLine(car);
        });
    }
}