using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoOOP.Arithmetic
{
    internal class CalcV2: CalcV1
    {
        // Inherits all methods from CalcV1
        // You can add new methods or override existing ones here if needed
        public double Power(double baseNum, double exponent)
        {
            return Math.Pow(baseNum, exponent);
        }

        public string Add(string a, string b)
        {
            // Overloaded method to concatenate strings
            return $"{a} {b}";
        }
        public override string ToString()
        {
            return "Calculator Version 2.0 with Power functionality";
        }
    }
}
