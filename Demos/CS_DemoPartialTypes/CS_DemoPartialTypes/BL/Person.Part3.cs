using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoPartialTypes.BL
{
    internal partial class Person
    {
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public partial void OnCreated()
        {
            // This method is called when the object is created.
            // You can add custom initialization logic here if needed.
            Console.WriteLine($"Person created: {this}");
        }
    }
}
