
int[] ints = new int[5];

Console.WriteLine("ingrese 5 numeros ");

for (int x = 0; x <= 4; x++)
{
   
    ints[x] = Convert.ToInt32(Console.ReadLine());
}
//buscar una forma de invertilo mejor que el reverse
foreach (int i in ints.Reverse())
{
    Console.WriteLine("sus numeros fueron");
    Console.WriteLine(ints[i-1]);
}
