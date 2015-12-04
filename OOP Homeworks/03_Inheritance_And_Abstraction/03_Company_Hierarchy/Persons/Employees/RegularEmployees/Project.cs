using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Company_Hierarchy.Persons.Employees.RegularEmployees
{
    public class Project
    {
        public Project(string name, DateTime? date, string details, bool isOpen)
        {
            this.Name = name;
            this.Date = date;
            this.Details = details;
            this.IsOpen = isOpen;
        }

        public string Name { get; set; }

        public DateTime? Date { get; set; }

        public string Details { get; set; }

        public bool IsOpen { get; set; }

        public void CloseProject()
        {
            this.IsOpen = false;
        }

        public override string ToString()
        {
            return $"Project Name: {this.Name}, Open: {this.IsOpen}";
        }
    }
}
