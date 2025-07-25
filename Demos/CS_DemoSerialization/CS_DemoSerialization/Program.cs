using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text.Json;

using System.IO;
using CS_DemoSerialization.Models;
using System.Xml.Serialization;

namespace CS_DemoSerialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var person = new Person
            {
                Name = "John Doe",
                Age = 30
            };
            DemoBinarySerialization(person);
            //DemoXmlSerialization(person);
            //DemoSOAPSerialization(person);
            //DemoJsonSerialization(person);
            Console.WriteLine("Deserialization complete.");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void DemoJsonSerialization(Person? person)
        {
            string jsonFilePath = "person.json";
            // Serialize the person object to a JSON file
            using (FileStream fs = new FileStream(jsonFilePath, FileMode.Create, FileAccess.Write))
            {
                JsonSerializer.Serialize(fs, person);
                person = null;
                // Clear the reference to the object
                // to ensure it is not kept in memory
                Console.WriteLine("Person object serialized to JSON file.");
                GC.Collect(); // Optional: Force garbage collection
            }
            // Deserialize the person object from the JSON file
            using (FileStream fs = new FileStream(jsonFilePath, FileMode.Open, FileAccess.Read))
            {
                var deserializedPerson = JsonSerializer.Deserialize<Person>(fs);
                Console.WriteLine($"Name: {deserializedPerson.Name}, Age: {deserializedPerson.Age}");
            }
        }

        private static void DemoBinarySerialization(Person? person)
        {
            string filePath = "person.dat";

            // Serialize the person object to a file
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, person);
                person = null;
                // Clear the reference to the object
                // to ensure it is not kept in memory
                Console.WriteLine("Person object serialized to file.");
                GC.Collect(); // Optional: Force garbage collection
            }

            // Deserialize the person object from the file
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                var deserializedPerson = formatter.Deserialize(fs) as Person;
                Console.WriteLine($"Name: {deserializedPerson.Name}, Age: {deserializedPerson.Age}");
            }
        }

        private static void DemoXmlSerialization(Person? person)
        {
            string filePath = "person.xml";

            // Serialize the person object to a file
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Person));
                serializer.Serialize(fs, person);
                person = null;
                // Clear the reference to the object
                // to ensure it is not kept in memory
                Console.WriteLine("Person object serialized to file.");
                GC.Collect(); // Optional: Force garbage collection
            }

            // Deserialize the person object from the file
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Person));
                var deserializedPerson = serializer.Deserialize(fs) as Person;
                Console.WriteLine($"Name: {deserializedPerson.Name}, Age: {deserializedPerson.Age}");
            }
        }

        private static void DemoSOAPSerialization(Person? person)
        {
            string filePath = "person-soap.xml";

            // Serialize the person object to a file
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                SoapFormatter formatter = new SoapFormatter();
                formatter.Serialize(fs, person);
                person = null;
                // Clear the reference to the object
                // to ensure it is not kept in memory
                Console.WriteLine("Person object serialized to file.");
                GC.Collect(); // Optional: Force garbage collection
            }

            // Deserialize the person object from the file
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                SoapFormatter formatter = new SoapFormatter();
                var deserializedPerson = formatter.Deserialize(fs) as Person;
                Console.WriteLine($"Name: {deserializedPerson.Name}, Age: {deserializedPerson.Age}");
            }
        }
    }
}
