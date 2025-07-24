using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoOOP.Arithmetic.Extensions
{
    internal static class CalcV1Extensions
    {
        public static int Factorial(this CalcV1 calc, int number)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException(nameof(number), "Number must be non-negative.");
            if (number == 0 || number == 1)
                return 1;
            return number * Factorial(calc, number - 1);
        }
    }
}
