namespace colecoes;

public class Developer
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}

public class Language
{
    public string? Name { get; set; }
}

public class Database
{
    public string? Name { get; set; }
}

public class DeveloperLanguages
{
    public Developer? developer;
    public Language? language;
}

public class DeveloperDatabases
{
    public Developer? developer;
    public Database? database;
}

public class Program
{
    public static void Main(string[] args)
    {
        Developer Julia = new Developer { FirstName = "Julia", LastName = "Santos" };
        Developer Paulo = new Developer { FirstName = "Paulo", LastName = "Oliveira" };
        Developer Rebeca = new Developer { FirstName = "Rebeca", LastName = "Silva" };
        Developer Rodrigo = new Developer { FirstName = "Rodrigo", LastName = "Alves" };
        Developer Joana = new Developer { FirstName = "Joana", LastName = "Batista" };
        Developer Alan = new Developer { FirstName = "Alan", LastName = "Martins" };

        Language csharp = new Language { Name = "C#" };
        Language java = new Language { Name = "Java" };
        Language js = new Language { Name = "Javascript" };

        Database mysql = new Database { Name = "MySQL" };
        Database sqlserver = new Database { Name = "SQL Server" };

        List<DeveloperLanguages> developerLanguages = new List<DeveloperLanguages>
        {
            new DeveloperLanguages { developer = Julia, language = csharp},
            new DeveloperLanguages { developer = Julia, language = java},
            new DeveloperLanguages { developer = Paulo, language = js},
            new DeveloperLanguages { developer = Rebeca, language = java},
            new DeveloperLanguages { developer = Rodrigo, language = csharp},
            new DeveloperLanguages { developer = Rodrigo, language = js},
            new DeveloperLanguages { developer = Joana, language = csharp},
            new DeveloperLanguages { developer = Alan, language = js}
        };

        List<DeveloperDatabases> developerDatabases = new List<DeveloperDatabases>
        {
            new DeveloperDatabases { developer = Julia, database = mysql},
            new DeveloperDatabases { developer = Julia, database = sqlserver},
            new DeveloperDatabases { developer = Paulo, database = mysql},
            new DeveloperDatabases { developer = Rebeca, database = mysql},
            new DeveloperDatabases { developer = Rodrigo, database = sqlserver},
            new DeveloperDatabases { developer = Joana, database = mysql},
            new DeveloperDatabases { developer = Alan, database = mysql},
            new DeveloperDatabases { developer = Alan, database = sqlserver}
        };

        var developerSkills = from developerLanguage in developerLanguages
                              join developerDatabase in developerDatabases 
                              on developerLanguage.developer equals developerDatabase.developer
                              select new {
                                DeveloperName = developerLanguage.developer.FirstName + " " + developerLanguage.developer.LastName,
                                Language = developerLanguage.language.Name,
                                Database = developerDatabase.database.Name
                              };

        foreach(var obj in developerSkills)
        {
            Console.WriteLine("Developer " + obj.DeveloperName 
                + " can develop a project using " + obj.Language 
                + " and " + obj.Database);
        }
    }
}
