using System;

class Program
{
    static void Main()
    {
        int[,] grades = new int[3, 3];

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Enter grades for Student {i + 1}:");
            for (int j = 0; j < 3; j++)
            {
                grades[i, j] = int.Parse(Console.ReadLine());
            }
        }

        for (int i = 0; i < grades.GetLength(0); i++)
        {
            Console.Write($"Student {i + 1}: ");
            for (int j = 0; j < grades.GetLength(1); j++)
            {
                Console.Write(grades[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
