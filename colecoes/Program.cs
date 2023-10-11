namespace colecoes;
public class Program
{
    public static void Main(string[] args)
    {
        List<int> integers = new List<int>(){ 18, 45, 29, 99 };
        Console.WriteLine(integers.IndexOf(29));
    }
}