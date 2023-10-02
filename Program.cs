public class Program
{
    public static void Main()
    {
        string[] teachers = new string[] { "Joel", "Tess", "Marlene" };
        string[] students = new string[] { "Ellie", "Joel", "Abby" };
        foreach (var teacher in teachers)
        {
            Console.WriteLine("Professor: " + teacher + ". Estudante:");
            foreach (var student in students)
            {
                if (teacher == student)
                    break;
                Console.WriteLine(student);
            }
        }
    }

}