namespace colecoes;

public class Customer {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? City { get; set;}
    public string? Password { get; set; }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Customer> customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "Rebeca", City = "Recife", Password =  "706632"},
            new Customer { Id = 2, Name = "José", City = "Manaus", Password =  "128620"},
            new Customer { Id = 3, Name = "Sandra", City = "Salvador", Password =  "043407"}
        };

        var customersList = from customer in customers
                            select customer;

        foreach(Customer customer in customersList)
        {
            Console.WriteLine(customer.Name + " - City: " +customer.City + " - Password: " + customer.Password);
        }
    }
}