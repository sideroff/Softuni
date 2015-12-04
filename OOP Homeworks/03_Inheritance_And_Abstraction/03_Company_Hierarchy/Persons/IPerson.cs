using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Company_Hierarchy.Persons
{
    interface IPerson
    {
        uint Id { get; set; }
        string Fname { get; set; }
        string Lname { get; set; }
    }
}
