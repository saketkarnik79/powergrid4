

namespace CS_DemoRefReturnsAndLocals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            Console.WriteLine("Original Array");
            PrintArray(numbers);

            ref int refToElement = ref GetElementRef(numbers, 2);

            //Modify the element using the reference
            refToElement = 10;
            Console.WriteLine("\nModified Array");
            PrintArray(numbers);

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }

        private static ref int GetElementRef(int[] numbers, int index)
        {
            if (index < 0 || index >= numbers.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return ref numbers[index];
        }

        private static void PrintArray(int[] numbers)
        {
            foreach (var number in numbers)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();
        }
    }
}
