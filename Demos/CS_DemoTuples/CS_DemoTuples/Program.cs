
namespace CS_DemoTuples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (string, int) person = ("John Doe", 30);
            Console.WriteLine($"Name: {person.Item1}, Age: {person.Item2}");

            // Using named tuples
            (string Name, int Age) namedPerson = ("Jane Doe", 25);
            Console.WriteLine($"Name: {namedPerson.Name}, Age: {namedPerson.Age}");

            // Using deconstruction
            var (name, age) = namedPerson;
            Console.WriteLine($"Deconstructed Name: {name}, Age: {age}");

            // Tuple with multiple types
            (string Name, int Age, double Height) complexPerson = ("Alice", 28, 5.5);
            Console.WriteLine($"Name: {complexPerson.Name}, Age: {complexPerson.Age}, Height: {complexPerson.Height}");
            
            //tuple returned from a method
            var result = GetStats(new [] { 1, 2, 3, 4, 5 });
            Console.WriteLine($"Sum: {result.Sum}, Average: {result.Average}");



            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        // Method that returns a tuple
        private static (int Sum, double Average) GetStats(int[] ints)
        {
            int sum = 0;
            foreach (var i in ints)
            {
                sum += i;
            }
            double average = (double)sum / ints.Length;
            return (sum, average);
        }
    }
}
