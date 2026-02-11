using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day06_Task
{
    #region problem 4
    internal class Point2
    {
        public int X;
        public int Y;

        public Point2(int x)
        {
            X = x;
            Y = 0;
        }

        public Point2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
//What are constructors in structs?


//Constructors initialize struct fields.

//Struct constructors must initialize all fields.

//Structs always have an implicit parameterless constructor.

//Overloaded constructors allow different initialization scenarios. 
#endregion
