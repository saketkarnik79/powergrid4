using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_NullableValueTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 10;
            int? j = null;
            Nullable<int> k = 20;
            //int l = j ?? 0; // Using null-coalescing operator to provide a default value
            Console.WriteLine($"i: {i}");
            if (j.HasValue)
            {
                Console.WriteLine($"j: {j.Value}");
            }
            else
            {
                Console.WriteLine("j is null");
            }
            if (k.HasValue)
            {
                Console.WriteLine($"k: {k.Value}");
            }
            else
            {
                Console.WriteLine("k is null");
            }

            var num = M();
            //var num2;//invalid use of var, must be initialized

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        private static int M()
        {
            return 42;
        }
    }
}
