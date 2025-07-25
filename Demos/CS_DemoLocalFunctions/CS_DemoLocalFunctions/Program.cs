using System.Threading.Tasks;

namespace CS_DemoLocalFunctions
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting calculation...\n");
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Local function to calculate the sum of an array
            int CalculateSum()
            {
                int sum = 0;
                foreach (var num in numbers)
                {
                    sum += num;
                }
                return sum;
            }

            //Async local function to simulate saving result
            async Task SaveResultAsync(int result)
            {
                await Task.Delay(1000); // Simulate a delay for saving
                Console.WriteLine($"Result saved: {result}");
            }

            //Local function with expression bodied syntax
            int CalculateProduct() => numbers.Aggregate(1, (acc, num) => acc * num);

            int sum = CalculateSum();
            int product = CalculateProduct();
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Product: {product}");
            // Call the async local function
            await SaveResultAsync(sum);

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

    }
}
