class Client
{
  string Name { get; set; }
  bool Active { get; set; } = true;
  decimal Balance { get; set; }

  public Client(string name, decimal Balance)
  {
    Name = name;
    Balance = Balance;
  }
}