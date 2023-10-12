namespace colecoes;

public class Program
{
    public static void Main(string[] args)
    {
        string[] words = { "owner", "report", "warm", "scramble", "party" };

        var objWords = from word in words
                       select new { word, length = word.Length };

        foreach (var objWord in objWords)
        {
            Console.WriteLine(objWord.word + " - " + objWord.length);
        }
    }
}