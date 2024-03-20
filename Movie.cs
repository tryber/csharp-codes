namespace Movies;

public class Movie
{
    private string _category;
    public string Title { get; set; }
    public string Category
    {
        get 
        {
            return "Categoria: " + _category;
        }
        set
        {
            if (value != "Fantasia" && value != "Ficção científica")
                throw new Exception("Categoria não permitida");

            _category = value;
        }
    }

    public Movie(string Title, string Category)
    {
        Title = Title;
        Category = Category;
    }
}