using System;

enum DayOfWeek
{
    Monday = 1,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}

class Program
{
    static void Main()
    {
        Console.Write("Enter a number (1-7): ");
        int input = int.Parse(Console.ReadLine());

        DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), input.ToString());

        Console.WriteLine("Day is: " + day);
    }
}
