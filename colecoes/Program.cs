namespace colecoes;
public class Program
{
    public static void Main(string[] args)
    {
       
        List<string> stacksProjectA = new List<string> { "C#", "SQL Server", "JSON", "Microsserviços" };
        List<string> stacksProjectB = new List<string> { "Java", "MySQL", "JSON", "WebAPI" };
        

        var stacksProjectsAandB = stacksProjectA.Intersect(stacksProjectB);

        foreach (var stack in stacksProjectsAandB) {
            Console.WriteLine(stack);
        }
    }
}
