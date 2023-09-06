int a = 1;
//incrementa + 1 ao valor de a
a++; //substitui a instrução a = a + 1 
Console.WriteLine("A = " + a);

int b = 10;
//decrementa o -1 ao valor b
b--; //substitui a instrução b = b - 1
Console.WriteLine("B = " + b);

//incrementa qualquer valor à direita na variável à esquerda
int c = 23;
c += 15; //substitui a instrução c = c + 15 
Console.WriteLine("C = " + c);

//incrementa multiplicando qualquer valor à direita na variável à esquerda
int e = 11;
e *= 3; //substitui a instrução e = e * 3 
Console.WriteLine("E = " + e);

//decrementa dividindo qualquer valor à direita na variável à esquerda
decimal f = 11;
f /= 3; //substitui a instrução f = f / 3 
Console.WriteLine("F = " + f.ToString("N2"));

//decrementa com a operação de módulo de qualquer valor à direita na variável à esquerda
decimal g = 11;
g %= 3; //substitui a instrução g = g % 3 
Console.WriteLine("G = " + g.ToString("N2"));