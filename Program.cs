public class Program
{
    public static void Main()
    {
        Console.WriteLine("Informe um número inteiro");
        string? response = Console.ReadLine();
        int number = 0;
        var canConvert = Int32.TryParse(response, out number);

        if (number > 0)
        {
            Console.WriteLine("maior que zero");
        }
        else
        {
            if (number < 0)
            {
                Console.WriteLine("menor que zero");
            }
            else
            {
                Console.WriteLine("igual a zero");
            }
        }

        if (number > 10)
            Console.WriteLine("maior que 10");
        else
            Console.WriteLine("menor ou igual a 10");

        if (number > 10) Console.WriteLine("maior que 10");
        else Console.WriteLine("menor ou igual a 10");

    }
}