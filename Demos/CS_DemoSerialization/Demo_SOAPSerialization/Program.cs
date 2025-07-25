using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization;

namespace Demo_SOAPSerialization
{
    [Serializable]
    public class Person: ISerializable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person() { }

        public Person(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("Name");
            Age = info.GetInt32("Age");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Age", Age);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            DemoSOAPSerialization(new Person
            {
                Name = "John Doe",
                Age = 30
            });
            
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }

        private static void DemoSOAPSerialization(Person person)
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
