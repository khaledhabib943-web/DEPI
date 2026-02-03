using System;

class Program
{
    static void Main()
    {
        int[] arr1 = { 1, 2, 3 };

        // Shallow copy (reference copy)
        int[] arr2 = arr1;
        arr2[0] = 99;

        Console.WriteLine(arr1[0]); // 99 (affected)

        // Deep copy using Clone
        int[] arr3 = (int[])arr1.Clone();
        arr3[1] = 77;

        Console.WriteLine(arr1[1]); // unchanged
        Console.WriteLine(arr3[1]); // 77
    }
}
