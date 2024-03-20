class Client
{
  string Name { get; set; }
  bool Active { get; set; }
  decimal Balance { get; set; }

  public Client(string name, decimal Balance)
  {
    Name = name;
    Active = false;
    Balance = Balance;
  }
}