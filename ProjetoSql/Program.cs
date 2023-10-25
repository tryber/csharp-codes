namespace ProjetoSql;

public class Program
{
    public static void Main(string[] args)
    {
         using (var db = new MyContext())
        {
            db.Database.EnsureCreated();

            // Create and save a new Category
            Console.Write("Enter a name for a new Category: ");
            var name = Console.ReadLine();

            var category = new Category { Name = name };
            db.Categories.Add(category);
            db.SaveChanges();

            // Display all Categories from the database
            var query = from b in db.Categories
                        orderby b.Name
                        select b;

            Console.WriteLine("All categories in the database:");
            foreach (var item in query)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
