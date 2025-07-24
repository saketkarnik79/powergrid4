using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CS_DemoTracing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Trace.Listeners.Clear();
            //Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            //Trace.AutoFlush = true;

            Trace.WriteLine($"Application started at {DateTime.Now}");
            int result = Add(5, 10);
            Trace.WriteLine($"Result of Add: {result}");
            Trace.WriteLine($"Application ended at {DateTime.Now}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static int Add(int a, int b)
        {
            Trace.WriteLine($"Entering Add method with parameters: a={a}, b={b}");
            int sum = a + b;
            Trace.WriteLine($"Exiting Add method with result: {sum}");
            return sum;
        }
    }
}
