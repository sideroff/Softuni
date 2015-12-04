using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Company_Hierarchy.Persons.Employees
{
    interface IManager
    {
        IEnumerable<Employee> Employees { get; }
    }
}
