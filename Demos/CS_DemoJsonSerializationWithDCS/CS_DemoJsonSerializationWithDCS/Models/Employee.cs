using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CS_DemoJsonSerializationWithDCS.Models
{
    public class Employee: Person
    {
        [DataMember]
        public string Department { get; set; }

        [DataMember]
        public decimal Salary { get; set; }
    }
}
