// See https://aka.ms/new-console-template for more information
Console.WriteLine($"Sum from 1 to 100 is {SumFrom1ToN(100)}");

int SumFrom1ToN(int n)
{
    int sum = 0;

    for (int i = 1; i <= n; i++)
    {
        sum += i;
    }

    return sum;
}