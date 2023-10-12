namespace colecoes;
public class Program
{
    public static void Main(string[] args)
    {
       
        List<string> stacksProject = new List<string> { "C#", "SQL Server", "JSON", "C#", "XML", "SQL Server", "Microsserviços", "Microsserviços" };
        
        var stacksProjectDistinct = stacksProject.Distinct();

        foreach (var stack in stacksProjectDistinct) {
            Console.WriteLine(stack);
        }
    }
}
