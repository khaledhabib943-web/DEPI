using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day06_Task
{
    #region Problem 3
    internal struct Employee
    {
        public int id;
        public string name;
        public decimal salary;

        public string GetName()
        {
            return name;
        }

        public void SetName(string value)
        {
            name = value;
        }

        public int EmpId
        {
            get { return id; }
            set { id = value; }
        }

        public decimal Salary
        {
            get { return salary; }
            set
            {
                if (value >= 0)
                    salary = value;
            }
        }
    }

    class TestEmployee
    {
        static void Main()
        {
            Employee emp = new Employee();
            emp.EmpId = 101;
            emp.SetName("Khaled");
            emp.Salary = 5000;

            Console.WriteLine(emp.GetName());
            Console.WriteLine(emp.Salary);
        }
    }
}

//Why is encapsulation critical in software design?

//Encapsulation:

//Protects internal data from invalid states

//Enforces validation rules

//Reduces coupling between components

//Makes systems easier to maintain and modify

//It is a core principle of Object-Oriented Programming.

#endregion