using System;

namespace C__Day06_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TypeA obj = new TypeA();

            // Console.WriteLine(obj.F); // ❌ Not accessible (private)
            Console.WriteLine(obj.G);    // ✔ Accessible within same assembly
            Console.WriteLine(obj.H);    // ✔ Accessible everywhere
        }
    }
}
