using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_DemoExceptions.Exceptions;

namespace CS_DemoExceptions.Demographics
{
    internal class Person
    {
        public string Name { get; set; }
        
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 0 || value > 120)
                {
                    throw new InvalidAgeException($"Invalid age provided: {value}. Age must be between 0 and 120.");
                }
                _age = value;
            }
        }

        public Person(string name, int age)
        {
            Name = name;

            try
            {
                Age = age; // This will throw InvalidAgeException if age is invalid
            }
            catch (InvalidAgeException ex)
            {
                // Log the exception or handle it as needed
                throw new ApplicationException("Error creating person...", ex);
            }
        }

        public void Display()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }
    }
}
