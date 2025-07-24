using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoOOP.Demographics
{
    internal class Person:IDisposable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Person(string firstName, string lastName, int age) //Initializer
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
        public string Display()
        {
            return $"{FirstName} {LastName}, Age: {Age}";
        }

        public void Dispose()
        {
            Console.WriteLine("Cleaning up from dispose()"); 
            GC.SuppressFinalize(this); // Suppress finalization for this object
        }

        ~Person() //Destructor
        {
            Console.WriteLine($"Destructor called for {FirstName} {LastName}");
        }
    }
}
