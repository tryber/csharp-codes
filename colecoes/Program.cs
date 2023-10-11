namespace colecoes;
public class Program
{
    public static void Main(string[] args)
    {
        List<string> vehicles = new List<string>(){ "carro", "moto", "avião" };

        foreach (var item in vehicles)
        {
            Console.WriteLine(item);
        }
    }
}