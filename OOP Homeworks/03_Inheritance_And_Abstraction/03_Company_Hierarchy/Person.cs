using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03_Company_Hierarchy.Persons;

namespace _03_Company_Hierarchy
{
    public abstract class Person : IPerson
    {
        protected Person(uint id, string fname, string lname)
        {
            this.Id = id;
            this.Fname = fname;
            this.Lname = lname;
        }

        public uint Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }

        public override string ToString()
        {
            return $"{this.Id}, {this.Fname}, {this.Lname}";
        }
    }
}
