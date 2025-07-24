using CS_DemoPartialTypes.BL;

namespace CS_DemoPartialTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();
            person1.FirstName = "John";
            person1.LastName = "Doe";
            person1.OnCreated();
            Console.WriteLine(person1);
            Console.WriteLine();
            Person person2 = new Person("Jane", "Smith");

            person2.OnCreated();
            Console.WriteLine(person2);
            Console.WriteLine();
            Person person3 = new Person()
            {
                FirstName = "Alice",
                LastName = "Johnson"
            };

            person3.OnCreated();
            Console.WriteLine(person3);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
