namespace colecoes;

public class Program
{
    public static void Main(string[] args)
    {
        List<string> names = new List<string>
        {
            "Roberta", "Laura", "Maria", "Ana", "Pedro", "Ricardo"
        };

        var orderedNames = from name in names
                            orderby name
                            select name;

        foreach(string orderedName in orderedNames) {
            Console.WriteLine(orderedName);
        }
    }
}