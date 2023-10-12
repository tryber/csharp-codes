namespace colecoes;

public class Developer {
    public string? Name { get; set; }
    public string? ProgrammingLanguage { get; set; }
}


public class Program
{
    public static void Main(string[] args)
    {
       
        List<Developer> developers = new List<Developer>
        {
            new Developer { Name = "Julia", ProgrammingLanguage = "C#" },
            new Developer { Name = "Paulo", ProgrammingLanguage = "Java" },
            new Developer { Name = "Rebeca", ProgrammingLanguage = "C#" },
            new Developer { Name = "Rodrigo", ProgrammingLanguage = "C#" },
            new Developer { Name = "Joana", ProgrammingLanguage = "Java" },
            new Developer { Name = "Alan", ProgrammingLanguage = "Python" }
        };

        var developerSkills = from developer in developers
                              group developer by developer.ProgrammingLanguage into languages
                              select languages;


        foreach(var languageGroup in developerSkills)
        {
            Console.WriteLine("Linguagem: " + languageGroup.Key);
            foreach(var developer in languageGroup)
            {
                Console.WriteLine("Pessoas desenvolvedoras: " + developer.Name);
            }
        }
    }
}
