using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03_Company_Hierarchy.Persons.Employees;

namespace _03_Company_Hierarchy
{
    class Manager : Employee, IManager
    {
        private List<Employee> employees;
        

        public Manager(uint id, string fname, string lname, uint salary, Departments deparment)
            : base(id, fname, lname, salary, deparment)
        {
            this.employees = new List<Employee>();
        }


        public IEnumerable<Employee> Employees => this.employees;

        public void AddEmployee(Employee newEmployee)
        {
            this.employees.Add(newEmployee);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            this.employees.ForEach(employee => sb.Append(Environment.NewLine + "\t" + employee));
            return base.ToString() + sb;
        }
    }
}
