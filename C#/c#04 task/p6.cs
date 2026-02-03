using System;

class Program
{
    static void Main()
    {
        int number;

        do
        {
            Console.Write("Enter a positive odd number: ");
        }
        while (!int.TryParse(Console.ReadLine(), out number) || number <= 0 || number % 2 == 0);

        Console.WriteLine("Valid number entered: " + number);
    }
}
