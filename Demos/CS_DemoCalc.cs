using System;
using static System.Console;
namespace CS_DemoCalc
{
	class Program
	{
		static void Main()
		{
			int x=0;
			int y=0;
			int result=0;
			char op=default(char);
			Write("Enter a number: ");
			//x=int.Parse(ReadLine());
			if(!int.TryParse(ReadLine(),out x))
			{
				WriteLine ("Input is not a valid number...");
				return;
			}
			Write("Enter another number: ");
			y=int.Parse(ReadLine());
			Write("Enter the operator<+, -, *, /, %>: ");
			op=char.Parse(ReadLine());
			//result = x + y;
			// if(op == '+')
			// {
				// result=x+y;
			// }
			// else if(op == '-')
			// {
				// result=x-y;
			// }
			// else if(op == '*')
			// {
				// result=x*y;
			// }
			// else if(op == '/')
			// {
				// result=x/y;
			// }
			// else if(op == '%')
			// {
				// result=x%y;
			// }
			// else
			// {
				// WriteLine("Invalid operator entered...");
			// }
			const plus='+';
			switch(op)
			{
				case plus:
					result=x+y;
					break;
				case '-':
					result=x-y;
					break;
				case '*':
					result=x*y;
					break;
				case '/':
					result=x/y;
					break;
				case '%':
					result=x%y;
					break;
				default:
					WriteLine("Invalid operator entered...");
					break;
			}
			
			WriteLine($"{x} {op} {y} = {result}");
		}
	}
}