using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03_Company_Hierarchy.Persons;

namespace _03_Company_Hierarchy
{
    public abstract class Employee : Person, IEmployee
    {
        protected Employee(uint id, string fname, string lname, uint salary, Departments deparment) 
            : base(id, fname, lname)
        {
            this.Salary= salary;
            this.Department = deparment;
        }

        public uint Salary { get; set; }
        public Departments Department { get; set; }
        public override string ToString()
        {
            return base.ToString() + $" Salary: {this.Salary} Department: {this.Department}";
        }
    }
}
