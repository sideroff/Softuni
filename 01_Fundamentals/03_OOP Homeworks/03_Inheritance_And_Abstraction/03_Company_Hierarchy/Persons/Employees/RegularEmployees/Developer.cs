using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _03_Company_Hierarchy.Persons.Employees.RegularEmployees
{
    class Developer : RegularEmployee
    {
        private List<Project> projects;


        public Developer(uint id, string fname, string lname, uint salary, Departments deparment) 
            :base(id, fname, lname, salary, deparment)
        {
            this.projects= new List<Project>();
        }

        public IEnumerable<Project> Projects => this.projects;

        public void AddProject(Project newProject)
        {
            this.projects.Add(newProject);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            this.projects.ForEach(project => sb.Append(Environment.NewLine + "\t" + project));

            return base.ToString() + sb.ToString();
        }
    }
}
