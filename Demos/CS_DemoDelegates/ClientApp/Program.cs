using MyLib;

namespace ClientApp
{
    internal class Program
    {
        static void SayHello(string n)
        {
            Console.WriteLine($"Hello, {n}!");
        }
        static void SayGoodbye(string n)
        {
            Console.WriteLine($"Goodbye, {n}!");
        }
        static void Main(string[] args)
        {
            Greeter greeter = new Greeter();
            //greeter.Greet("Saket", new GreetHandler(SayHello));
            //greeter.Greet("Saket", SayHello);
            //greeter.Greet("Saket",delegate (string n) 
            //{ 
            //    Console.WriteLine($"Good Morning, {n}!");
            //});
            greeter.Greet("Saket", (n) =>
            {
                Console.WriteLine($"Good Morning, {n}!");
            });
            greeter.SendOff("Saket", new GreetHandler(SayGoodbye));

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
