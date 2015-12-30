using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Human_Student_Worker
{
    abstract class Human
    {
        private string fName;

        public string FName
        {
            get { return fName; }
            set { fName = value; }
        }
        private string lName;

        public string LName
        {
            get { return lName; }
            set { lName = value; }
        }
        public Human(string fName, string lName)
        {
            this.fName = fName;
            this.LName = lName;
        }
        public override string ToString()
        {
            return $"Type:   Human, Fname: {this.FName}, LName:{this.LName}";
        }
    }
}
