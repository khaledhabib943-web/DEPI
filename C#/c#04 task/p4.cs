using System;

class Program
{
    static void Main()
    {
        int[] arr = { 5, 2, 9, 1, 7 };

        Array.Sort(arr);
        Array.Reverse(arr);

        int index = Array.IndexOf(arr, 5);

        int[] copy = new int[5];
        Array.Copy(arr, copy, arr.Length);

        Array.Clear(arr, 0, arr.Length);

        Console.WriteLine("Original cleared array:");
        foreach (int x in arr)
            Console.WriteLine(x);
    }
}
