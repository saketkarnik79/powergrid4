using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoExceptions.Exceptions
{
    internal class InvalidAgeException: ApplicationException
    {
        public InvalidAgeException():base("Invalid age provided.")
        {
            //Logging code can be added here
            Console.WriteLine(this.Message);
        }
        public InvalidAgeException(string message)
            : base(message)
        {
            //Logging code can be added here
            Console.WriteLine(this.Message);
        }
        public InvalidAgeException(string message, Exception innerException)
            : base(message, innerException)
        {
            //Logging code can be added here
            Console.WriteLine(this.Message);
        }
    }
}
