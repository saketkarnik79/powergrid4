using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoObjectBaseClass
{
    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public override string ToString()
        {
            return $"{Make} {Model}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Car otherCar)
            {
                return Make == otherCar.Make && Model == otherCar.Model;
            }
            return false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car
            {
                Make = "Toyota",
                Model = "Corolla"
            };
            Console.WriteLine(myCar);
            // Output: Toyota Corolla

            Car car2 = new Car
            {
                Make = "Toyota",
                Model = "Corolla"
            };
            Console.WriteLine(car2);
            // Output: Toyota Corolla
            Console.WriteLine(myCar.Equals(car2));
            //Console.WriteLine(myCar==car2);
            object obj2=myCar;
            Console.WriteLine(myCar==obj2);
            // Output: True
            object obj="Toyota Corolla";
            Console.WriteLine(myCar.Equals(obj));
            Console.WriteLine(obj2.GetType());
            // Output: False, because obj is not a Car object
            Console.ReadKey();
        }
    }
}
