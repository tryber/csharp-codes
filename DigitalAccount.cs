public class DigitalAccount : Account
{
    public OperatingSystem AccountCreationOS { get; }
    public DateTime AccountCreationDate { get; } = DateTime.Now;

    public DigitalAccount(Client owner, OperatingSystem OS) : base(owner)
    {
        AccountCreationOS = OS;
    }
}