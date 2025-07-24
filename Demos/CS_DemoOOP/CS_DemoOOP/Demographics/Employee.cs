using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoOOP.Demographics
{
    internal class Employee: Person
    {
        public string EmployeeId { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }

        public Employee(string firstName, string lastName, int age, string employeeId, string department, double salary)
            : base(firstName, lastName, age) // Call the base class constructor
        {
            EmployeeId = employeeId;
            Department = department;
            Salary = salary;
        }

        public new string Display()
        {
            return $"{base.Display()}, Employee ID: {EmployeeId}, Department: {Department}, Salary: {Salary:C}";
        }
    }
}
