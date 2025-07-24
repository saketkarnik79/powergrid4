using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoPartialTypes.BL
{
    internal partial class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public partial void OnCreated();
    }
}
