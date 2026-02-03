using System;

class Program
{
    static void Main()
    {
        int month = int.Parse(Console.ReadLine());

        if (month == 1) Console.WriteLine("January");
        else if (month == 2) Console.WriteLine("February");
        else Console.WriteLine("Invalid");

        switch (month)
        {
            case 1: Console.WriteLine("January"); break;
            case 2: Console.WriteLine("February"); break;
            default: Console.WriteLine("Invalid"); break;
        }
    }
}
