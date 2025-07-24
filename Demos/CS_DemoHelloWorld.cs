using System;
using static System.Console;
namespace CS_DemoHelloWorld
{
	class Program
	{
		//static void Main(string[] args)
		static void Main()
		{
			//System.Console.WriteLine("Hello, World!");
			//System.Console.WriteLine("Hello, {0}", args[0]);
			//System.Console.WriteLine($"Hello, {args[0]}");
			string input=string.Empty;
			//System.Console.Write("Enter your Name: ");
			//Console.Write("Enter your Name: ");
			Write("Enter your Name: ");
			//input = System.Console.ReadLine();
			input = ReadLine();
			//System.Console.WriteLine($"Hello, {input}");
			WriteLine($"Hello, {input}");
		}
	}
}