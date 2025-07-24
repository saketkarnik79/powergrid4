using CS_DemoExceptions.Demographics;
using CS_DemoExceptions.Exceptions;

namespace CS_DemoExceptions
{
    internal class Program
    {
        static void ProcessData()
        {
            try
            {
                int[] numbers = { 1, 2, 3 };
                int value=numbers[3]; // This will throw an IndexOutOfRangeException
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new ApplicationException("Error while processing data...",ex);
            }
        }
        static void Main(string[] args)
        {
            //try
            //{
            //    ProcessData();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("\nOuter Exception Caught...");
            //    Console.WriteLine($"Error: {ex.Message}");
            //    if (ex.InnerException != null)
            //    {
            //        Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
            //        Console.WriteLine($"Type: {ex.InnerException.GetType()}");
            //    }
            //}

            try
            {
                Person person = new Person("John Doe", 150); // This will throw an InvalidAgeException
                person.Display();
            }
            catch (ApplicationException ex)
            {
                //Console.WriteLine("\nCustom Exception Caught...");
                //Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("\nCustom Exception Caught...");
                Console.WriteLine($"Error: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                    Console.WriteLine($"Type: {ex.InnerException.GetType()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nGeneral Exception Caught...");
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
