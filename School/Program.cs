namespace School;

public class SchoolMain
{
    public static void Main(string[] args)
    {
        SchoolContext database = new SchoolContext();
        database.Database.EnsureDeleted();
        database.Database.EnsureCreated();

        database.Teachers.Add(new Teacher { Name = "Rosana" });
        database.Teachers.Add(new Teacher { Name = "Pedro" });
        database.SaveChanges();
      
        StartProgram:
       
        Console.WriteLine("Menu:");
        Console.WriteLine("1 - Visualizar dados");
        Console.WriteLine("2 - Inserir dados");
        Console.WriteLine("3 - Atualizar dados");
        Console.WriteLine("4 - Remover dados");
        Console.WriteLine("5 - Visualizar pessoas educadoras");
        
        int option = int.Parse(Console.ReadLine()!);
        
        switch(option) {
            case 1:
                SelectStudents(database);
                goto StartProgram;
            case 2:
                InsertStudents(database);
                goto StartProgram;
            case 3:
                UpdateStudent(database);
                goto StartProgram;
            case 4:
                DeleteStudent(database);
                goto StartProgram;
            case 5:
                SelectTeachers(database);
                goto StartProgram;
           
        }


    }

    public static void SelectStudents( SchoolContext database)
    {
        Console.Clear();
        foreach(Student student in database.Students)
        {
            Console.WriteLine($"{student.Id} - {student.Name} - {student.Course} - Pessoa Educadora: {student.Teacher.Name}");
        }
    }


    public static void SelectTeachers( SchoolContext database)
    {
        Console.Clear();
        foreach(Teacher teacher in database.Teachers)
        {
            Console.WriteLine($"{teacher.Id} - {teacher.Name}");
            Console.WriteLine("Pessoas estudante");
            foreach(Student student in teacher.Students)
            {
                Console.WriteLine(student.Name);
            }
            Console.WriteLine("");
        }
    }

    public static void InsertStudents( SchoolContext database)
    {
        Console.Clear();
        Console.WriteLine("Digite o nome da pessoa estudante");
        string name = Console.ReadLine()!;

        Console.WriteLine("Digite o curso");
        string course = Console.ReadLine()!;

        Console.WriteLine("Digite o id da pessoa educadora");
        int teacherId = int.Parse(Console.ReadLine());

        Student newStudent = new Student
        {
            Name = name,
            Course = course,
            TeacherId = teacherId
        };
        database.Students.Add(newStudent);
        database.SaveChanges();
    }

    public static void UpdateStudent(SchoolContext database)
    {
        Console.Clear();
        Console.WriteLine("Informe o Id da Pessoa Estudante");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o nome da pessoa estudante");
        string name = Console.ReadLine()!;

        Console.WriteLine("Digite o curso");
        string course = Console.ReadLine()!;

        Console.WriteLine("Digite o id da pessoa educadora");
        int teacherId = int.Parse(Console.ReadLine());

        Student existingStudent = database.Students.Find(id);
        existingStudent.Name = name;
        existingStudent.Course = course;
        existingStudent.TeacherId = teacherId;
        database.Students.Update(existingStudent);
        database.SaveChanges();


    }

    public static void DeleteStudent( SchoolContext database)
    {
        Console.Clear();
        Console.WriteLine("Informe o Id da Pessoa Estudante");
        int id = int.Parse(Console.ReadLine());

        Student existingStudent = database.Students.Find(id);
        database.Students.Remove(existingStudent);
        database.SaveChanges();
    }

}