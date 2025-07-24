namespace CS_DemoAnonymousTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var person = new
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 30,
                Address = new
                {
                    Street = "123 Main St",
                    City = "Anytown",
                    ZipCode = "12345"
                }
            };
            //Console.WriteLine(person);
            Console.WriteLine($"Name: {person.FirstName} {person.LastName}, Age: {person.Age}, Address: {person.Address.Street}, {person.Address.City}, {person.Address.ZipCode}");

            var people=new List<string>
            {
                "Alice",
                "Bob",
                "Charlie"
            };
            var anonymousList = people.Select((name,index) => new
            {
                Id = index+1,
                Name = name,
                IsActive = name.StartsWith("A")
            });
            Console.WriteLine();
            Console.WriteLine("Anonymous List:");
            foreach (var item in anonymousList)
            {
                Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, IsActive: {item.IsActive}");
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
