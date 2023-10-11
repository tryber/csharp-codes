namespace colecoes;

public class Program
{
    public static void Main(string[] args)
    {
        string[] greetings = { "Hello World", "Hello LINQ", "Hello Trybe" };

        var numberOfItems = greetings.Count();
    
        Console.WriteLine(numberOfItems);
    }
}