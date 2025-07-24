using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoFunctionsAndParameters
{
    internal class Program
    {
        static void DemoPassByValue(int x)
        {
            x += 10; // This change will not affect the original variable
            Console.WriteLine($"Inside DemoPassByValue: x = {x}");
        }

        static void DemoPassByReferenceIn(in int x)
        {
            //x += 10; 
            Console.WriteLine($"Inside DemoPassByReferenceIn: x = {x}");
        }

        static void DemoPassByReferenceOut(out int x)
        {
            x = 10; // This will initialize the out parameter
            Console.WriteLine($"Inside DemoPassByReferenceOut: x = {x}");
        }

        static void DemoPassByReferenceRef(ref int x)
        {
            //x += 10; // This will modify the original variable
            Console.WriteLine($"Inside DemoPassByReferenceRef: x = {x}");
        }

        static void Greet(string name="Guest")
        {
            Console.WriteLine($"Hello, {name}!");
        }

        static void Main(string[] args)
        {
            int originalValue = 5;
            Console.WriteLine($"Before DemoPassByValue: originalValue = {originalValue}");
            DemoPassByValue(originalValue);
            Console.WriteLine($"After DemoPassByValue: originalValue = {originalValue}");

            Console.WriteLine();
            DemoPassByReferenceIn(in originalValue);
            Console.WriteLine($"After DemoPassByReferenceIn: originalValue = {originalValue}");

            Console.WriteLine();
            int outValue;
            DemoPassByReferenceOut(out outValue);
            Console.WriteLine($"After DemoPassByReferenceOut: outValue = {outValue}");
            Console.WriteLine($"After DemoPassByReferenceOut: originalValue = {originalValue}");

            Console.WriteLine();
            DemoPassByReferenceRef(ref originalValue);
            Console.WriteLine($"After DemoPassByReferenceRef: originalValue = {originalValue}");

            Greet("Alice");
            Greet();// Using the default parameter value(optional paramaters)
            Greet(name: "Bob");// Using named argument

            Console.ReadKey();
        }
    }
}
