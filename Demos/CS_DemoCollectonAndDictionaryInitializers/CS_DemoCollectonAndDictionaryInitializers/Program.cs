namespace CS_DemoCollectonAndDictionaryInitializers
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //DemoCollectionInitializer();

            //DemoDictionaryInitializer();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void DemoDictionaryInitializer()
        {
            Dictionary<string, Person> peopleDictionary = new Dictionary<string, Person>() // Dictionary Initializer
            {
                { "Alice", new Person() { Name = "Alice", Age = 30 } },
                { "Bob", new Person() { Name = "Bob", Age = 25 } },
                { "Charlie", new Person() { Name = "Charlie", Age = 35 } }
            };
            foreach (var key in peopleDictionary.Keys)
            {
                Console.WriteLine($"Key: {key}, Person: {peopleDictionary[key].Name} - {peopleDictionary[key].Age}");
            }

            var scores = new Dictionary<string, int>() // Dictionary Initializer with primitive type
            {
                ["Alice"]=95,//collection expression
                ["Bob"]=85,
                ["Charlie"]=90
            };
            foreach (var key in scores.Keys)
            {
                Console.WriteLine($"Key: {key}, Score: {scores[key]}");
            }
        }

        private static void DemoCollectionInitializer()
        {
            var people = new List<Person>()//Collection Initializer
            {
                new Person() { Name = "Alice", Age = 30 },
                new Person() { Name = "Bob", Age = 25 },
                new Person() { Name = "Charlie", Age = 35 }
            };

            foreach (var person in people)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
            }
        }
    }
}
