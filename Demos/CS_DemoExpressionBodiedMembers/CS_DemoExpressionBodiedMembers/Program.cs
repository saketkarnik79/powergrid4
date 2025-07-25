namespace CS_DemoExpressionBodiedMembers
{
    class Person
    {
        public Person(string name, int age)=>(Name, Age) = (name, age);//Expression-bodied constructor

        public string Name { get; }
        public int Age { get; }

        public string GetInfo() => $"{Name} is {Age} years old."; //Expression-bodied method

        public bool IsAdult() => Age >= 18; //Expression-bodied property

        public override string ToString() => GetInfo(); //Expression-bodied ToString method

        ~Person() => System.Console.WriteLine("Destructor called for " + Name); //Expression-bodied destructor
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var person = new Person("Alice", 30);
            Console.WriteLine(person.GetInfo());
            Console.WriteLine();
            Console.WriteLine(person);
            Console.WriteLine($"Is adult: {person.IsAdult()}");

            Console.WriteLine();
            Console.WriteLine("Press any to exit...");
            Console.ReadKey();
        }
    }
}
