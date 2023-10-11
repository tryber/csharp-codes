public class Engine : IStartable, IStoppable
{
    public void Start() => Console.WriteLine("Engine started!");
    public void Stop() => Console.WriteLine("Engine stopped!");
}