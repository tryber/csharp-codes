namespace colecoes;
public class Program
{
    public static void Main(string[] args)
    {
       
        List<string> stacksProjectA = new List<string> { "C#", "SQL Server", "JSON", "Microsserviços" };
        List<string> stacksProjectB = new List<string> { "Java", "MySQL", "JSON", "WebAPI" };
        
        var stacksProjectsAexceptB = stacksProjectA.Except(stacksProjectB);

        foreach (var stack in stacksProjectsAexceptB) {
            Console.WriteLine(stack);
        }
    }
}
