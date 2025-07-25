using CS_DemoJsonSerializationWithDCS.Models;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace CS_DemoJsonSerializationWithDCS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DemoSingleClassSerialization();

            DemoInheritanceSerialization();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void DemoInheritanceSerialization()
        {
            var employee = new Employee
            {
                Name = "Jane Smith",
                Age = 28,
                Address = "456 Elm St, Othertown, USA",
                Department = "Engineering",
                Salary = 75000.00m
            };
            string fileName = "employee-dc.json";

            // Serialize the employee object to JSON and save it to a file
            var serializer = new DataContractJsonSerializer(typeof(Employee));
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                serializer.WriteObject(fs, employee);
                Console.WriteLine("Serialized employee object to JSON file using DataContractJsonSerializer successfully...");
            }
            employee = null;
            GC.Collect();
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                // Deserialize the JSON file back to an employee object
                var deserializer = new DataContractJsonSerializer(typeof(Employee));
                employee = deserializer.ReadObject(fs) as Employee;
                Console.WriteLine($"Deserialized employee object from JSON file using DataContractJsonSerializer successfully...");
                Console.WriteLine($"Name: {employee.Name}, Age: {employee.Age}, Address: {employee.Address}, Department: {employee.Department}, Salary: {employee.Salary}");
            }
        }

        private static void DemoSingleClassSerialization()
        {
            var person = new Person
            {
                Name = "John Doe",
                Age = 30,
                Address = "123 Main St, Anytown, USA"
            };
            string fileName = "person-dc.json";

            // Serialize the person object to JSON and save it to a file
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                var serializer = new DataContractJsonSerializer(typeof(Person));
                serializer.WriteObject(fs, person);
                Console.WriteLine("Serialized person object to JSON file using DataContractJsonSerializer successfully...");
            }
            person = null;
            GC.Collect();
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                // Deserialize the JSON file back to a person object
                var deserializer = new DataContractJsonSerializer(typeof(Person));
                person = deserializer.ReadObject(fs) as Person;
                Console.WriteLine($"Deserialized person object from JSON file using DataContractJsonSerializer successfully...");
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, Address: {person.Address}");
            }
        }
    }
}
