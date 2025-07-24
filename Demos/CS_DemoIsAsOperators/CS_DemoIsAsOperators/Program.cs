using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoIsAsOperators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            object obj = "Hello, World!";
            //object obj = 10;
            // Using 'is' operator
            if (obj is string str)
            {
                Console.WriteLine($"The object is a string: {str}");
            }
            else
            {
                Console.WriteLine("The object is not a string.");
            }
            Console.WriteLine();
            // Using 'as' operator
            string str2 = obj as string;
            if (str2 != null)
            {
                Console.WriteLine($"The object is a string: {str2}");
            }
            else
            {
                Console.WriteLine("The object is not a string.");
            }
            Console.ReadKey();
        }
    }
}
