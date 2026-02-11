using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day06_Task
{
    #region Problem 1
    internal struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        #region problem 5
        public override string ToString()
        {
            return $"Point => X: {X}, Y: {Y}";
        }
    }

    class TestToString
    {
        static void Main()
        {
            Point[] points =
            {
            new Point(1,2),
            new Point(3,4),
            new Point(5,6)
        };

            foreach (Point p in points)
                Console.WriteLine(p);
        }
//        How does overriding methods like ToString() improve code readability?


//Provides meaningful object representation

//Improves debugging and logging

//Eliminates the need for manual formatting

//Makes code more expressive and self-documenting
        #endregion
    }
}
//        Why can't a struct inherit from another struct or class in C#?


//Structs are value types, not reference types.

//C# enforces single inheritance, and structs implicitly inherit from System.ValueType.

//Allowing inheritance would introduce:

//Object identity

//Heap allocation

//Polymorphism overhead
//These contradict the purpose of structs, which is lightweight, stack-allocated data containers. 
#endregion
