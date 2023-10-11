var rocket1 = new Rocket();
var rocket2 = rocket1;

rocket1.Name = "Apollo 11";
rocket2.Name = "Falcon 9";

Console.WriteLine(rocket1.Name);