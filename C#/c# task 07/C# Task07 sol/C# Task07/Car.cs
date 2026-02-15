using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Task07
{
    class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }

        // 1. Default constructor
        public Car()
        {
            Id = 0;
            Brand = "Unknown";
            Price = 0;
        }

        // 2. Constructor with Id
        public Car(int id)
        {
            Id = id;
        }

        // 3. Constructor with Id and Brand
        public Car(int id, string brand)
        {
            Id = id;
            Brand = brand;
        }

        // 4. Constructor with all properties
        public Car(int id, string brand, decimal price)
        {
            Id = id;
            Brand = brand;
            Price = price;
        }
        
        class Calculator
        {
            public int Sum(int a, int b) => a + b;
            public int Sum(int a, int b, int c) => a + b + c;
            public double Sum(double a, double b) => a + b;
        }

    }

}
