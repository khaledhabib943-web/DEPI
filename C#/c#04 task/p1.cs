using System;

class Program
{
    static void Main()
    {
        // 1) Using new int[size]
        int[] arr1 = new int[3];

        // 2) Using initializer list
        int[] arr2 = new int[] { 10, 20, 30 };

        // 3) Using array syntax sugar
        int[] arr3 = { 100, 200, 300 };

        // Assign values to arr1
        for (int i = 0; i < arr1.Length; i++)
            arr1[i] = (i + 1) * 5;

        Console.WriteLine("arr1:");
        foreach (int x in arr1)
            Console.WriteLine(x);

        Console.WriteLine("arr2:");
        foreach (int x in arr2)
            Console.WriteLine(x);

        Console.WriteLine("arr3:");
        foreach (int x in arr3)
            Console.WriteLine(x);

        // IndexOutOfRangeException
        Console.WriteLine(arr1[5]); // Exception
    }
}
