using static CS_DemoStatic.MathUtilities;

namespace CS_DemoStatic
{
    static class MathUtilities
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }
        public static int Multiply(int a, int b)
        {
            return a * b;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Add(2,3));
            Console.WriteLine(Multiply(2,3));

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
