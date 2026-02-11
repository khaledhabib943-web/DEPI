using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day06_Task
{
    #region Problem 2
    public class TypeA
    {
        private int F;
        internal int G;
        public int H;


        public void Print()
        {
            Console.WriteLine(F);
            Console.WriteLine(G);
        }
    }
}
//private                 Inside the same class only
//internal                Anywhere in the same assembly
//public                  From any project or assembly

#endregion