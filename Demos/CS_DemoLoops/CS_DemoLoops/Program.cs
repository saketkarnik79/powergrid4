using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CS_DemoLoops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // For loop example
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"For Loop Iteration: {i}");
            }
            // While loop example
            int j = 0;
            while (j < 5)
            {
                Console.WriteLine($"While Loop Iteration: {j}");
                j++;
            }
            // Do-while loop example
            int k = 0;
            do
            {
                Console.WriteLine($"Do-While Loop Iteration: {k}");
                k++;
            } while (k < 5);
            // Foreach loop example
            List<string> items = new List<string> { "Apple", "Banana", "Cherry" };
            foreach (var item in items)
            {
                Console.WriteLine($"Foreach Item: {item}");
            }

            // Demo for Binary File handling
            string filePath = "demo_binary.dat";

            // Write binary data to file
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                writer.Write(123); // int
                writer.Write(45.67); // double
                writer.Write("Hello Binary File"); // string
            }

            // Read binary data from file
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                int intValue = reader.ReadInt32();
                double doubleValue = reader.ReadDouble();
                string stringValue = reader.ReadString();

                Console.WriteLine($"Read from binary file: Int={intValue}, Double={doubleValue}, String={stringValue}");
            }

            Console.ReadKey();
        }
    }
}
