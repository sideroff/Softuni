using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Company_Hierarchy
{
    public abstract class RegularEmployee :Employee
    {
        protected RegularEmployee(uint id, string fname, string lname, uint salary, Departments deparment) 
            : base(id, fname, lname, salary, deparment)
        {
        }
    }
}
