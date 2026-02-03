using System;

class Program
{
    static void Main()
    {
        int[] arr = { 4, 2, 7, 2, 9 };

        Array.Sort(arr);

        Console.WriteLine(Array.IndexOf(arr, 2));
        Console.WriteLine(Array.LastIndexOf(arr, 2));
    }
}
