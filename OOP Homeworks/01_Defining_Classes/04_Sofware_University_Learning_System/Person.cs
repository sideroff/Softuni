using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Sofware_University_Learning_System
{
    class Person
    {
        private string fname;
        private string lname;
        private int age;

        public string Fname
        {
            get
            {
                return this.fname;
            }
            set
            {
                if (value == "") throw new Exception("Invalid first name.");
                this.fname = value;
            }
        }
        public string Lname
        {
            get
            {
                return this.lname;
            }
            set
            {
                if (value == "") throw new Exception("Invalid last name.");
                this.lname = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value <0) throw new Exception("Invalid age.");
                this.age = value;
            }
        }

    }
}
