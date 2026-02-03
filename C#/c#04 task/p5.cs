using System;

class Program
{
    static void Main()
    {
        int[] arr = { 1, 2, 3, 4, 5 };

        for (int i = 0; i < arr.Length; i++)
            Console.WriteLine(arr[i]);

        foreach (int x in arr)
            Console.WriteLine(x);

        int index = arr.Length - 1;
        while (index >= 0)
        {
            Console.WriteLine(arr[index]);
            index--;
        }
    }
}
