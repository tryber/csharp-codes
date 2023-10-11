namespace colecoes;
public class Program
{
    public static void Main(string[] args)
    {
        List<string> cars = new List<string>(){ "Fusca" };
        cars.Add("Brasília");
        cars.ForEach(car => {
            Console.WriteLine(car);
        });
    }
}