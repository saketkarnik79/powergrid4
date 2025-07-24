using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoPartialTypes.BL
{
    internal partial class Person
    {
        public Person()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
        }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        ~Person()
        {
            // Destructor logic can be added here if needed.
            // This is called when the object is being garbage collected.
            Console.WriteLine($"Person destroyed: {this}");
        }
    }
}
