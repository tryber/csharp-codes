namespace colecoes;

public class Program
{
    public static void Main(string[] args)
    {
        string[] greetings = { "Hello World", "Hello LINQ", "Hello Trybe" };
        
        var items = from greeting in greetings
                    select greeting;
  
        foreach (var item in items)
            Console.WriteLine(item);
        }
}