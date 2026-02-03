using System;

class Program
{
    static void Main()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        int sum1 = 0, sum2 = 0;

        for (int i = 0; i < arr.Length; i++)
            sum1 += arr[i];

        foreach (int x in arr)
            sum2 += x;

        Console.WriteLine(sum1);
        Console.WriteLine(sum2);
    }
}
