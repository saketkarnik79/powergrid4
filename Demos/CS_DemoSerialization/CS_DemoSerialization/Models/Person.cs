using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CS_DemoSerialization.Models
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
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
        }
    }
}
