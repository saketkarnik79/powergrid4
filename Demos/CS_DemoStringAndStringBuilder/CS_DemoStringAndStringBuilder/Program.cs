using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoStringAndStringBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "Hello";
            s+= " World";//Creates a new string object
            
            StringBuilder sb = new StringBuilder("Hello");
            sb.Append(" World"); // Modifies the existing StringBuilder object
            s= sb.ToString(); // Convert StringBuilder to string
            Console.WriteLine(s); // Output: Hello World
            s.Contains("Hello"); // Check if the string contains "Hello"
            s.StartsWith("Hello"); // Check if the string starts with "Hello"
            s.EndsWith("World"); // Check if the string ends with "World"
            s.Substring(0, 5); // Get substring from index 0 to 5 (exclusive)
            s.LastIndexOf("o"); // Find the last index of character 'o'
            s.IndexOf("l"); // Find the first index of character 'l'
            s.ToUpper(); // Convert string to uppercase
            s.ToLower(); // Convert string to lowercase
            s.Trim(); // Remove leading and trailing whitespace
            s.Replace("Hello", "Hi"); // Replace "Hello" with "Hi"
            s.Split(' '); // Split the string by space character
            s = s.Insert(5, " Beautiful"); // Insert " Beautiful" at index 5
            s = s.Remove(5, 10); // Remove 10 characters starting from index 5
            s = s.PadLeft(20, '*'); // Pad the string on the left with '*' to make it 20 characters long
            s = s.PadRight(20, '*'); // Pad the string on the right with '*' to make it 20 characters long

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(); // Wait for user input before closing the console window
        }
    }
}
