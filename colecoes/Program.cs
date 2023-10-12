namespace colecoes;
public class Program
{
    public static void Main(string[] args)
    {
       
        List<string> stacksProjectA = new List<string> { "C#", "SQL Server", "JSON", "Microsserviços" };
        List<string> stacksProjectB = new List<string> { "Java", "MySQL", "JSON", "WebAPI" };
        List<string> stacksProjectC = new List<string> { "C#", "MySQL", "XML" };

        var stacksProjectsABC = stacksProjectA.Union(stacksProjectB).Union(stacksProjectC);

        foreach (var stack in stacksProjectsABC) {
            Console.WriteLine(stack);        
        }
    }
}
