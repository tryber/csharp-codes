//ordem de execução
int a = 5, b = 10, c = 15;
int result1 = (a + b * c);
Console.WriteLine("(" + a + " + " + b + " * " + c + ") = " + result1);

//utilizando parênteses
int result2 = ((a + b) * c);
Console.WriteLine("((" + a + " + " + b + ") * " + c + ") = " + result2);