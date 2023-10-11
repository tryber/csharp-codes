namespace colecoes;
public class Program
{
    public static void Main(string[] args)
    {
        List<string> animals = new List<string>(){ "Cachorro", "Baleia", "Urso", "Tigre" };

        // Ordenando os elementos da lista
        animals.Sort();

        animals.ForEach(animal => {
            Console.WriteLine(animal);
        });
    }
}