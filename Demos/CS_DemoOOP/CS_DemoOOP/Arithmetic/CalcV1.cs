using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoOOP.Arithmetic
{
    internal class CalcV1
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public double Add(double a, double b)//Overloaded method
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }
        public int Multiply(int a, int b)
        {
            return a * b;
        }
        public double Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return (double)a / b;
        }

        public int Modulus(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return a % b;
        }

        public override string ToString()
        {
            return "Calculator Version 1.0";
        }
    }
}
