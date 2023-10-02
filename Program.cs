class Program
{
    static void Main(string[] args)
    {
        int[] expensesCost;
        Console.WriteLine("Entre com o número de despesas: ");
        int numberOfExpenses = getNumberOfExpenses();

        expensesCost = new int[numberOfExpenses];
    }

    public static int getNumberOfExpenses()
    {
        string entry = Console.ReadLine();
        int convertInt = Convert.ToInt32(entry);
        return convertInt;
    }
}