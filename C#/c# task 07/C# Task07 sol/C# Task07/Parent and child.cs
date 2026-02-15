using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Task07
{
    class Parent
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Parent(int x, int y)
        {
            X = x;
            Y = y;
        }

        public virtual int Product() => X * Y;

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    class Child : Parent
    {
        public int Z { get; set; }

        public Child(int x, int y, int z) : base(x, y)
        {
            Z = z;
        }

        // using new
        public new int Product()
        {
            return X * Y * Z;
        }

        // using override
        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }
    }

}
