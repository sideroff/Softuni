using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Human_Student_Worker
{
    class Student : Human
    {
        private string facNumber;

        public string FacNumber
        {
            get { return facNumber; }
            set
            {
                if (value.Length > 10) throw new ArgumentOutOfRangeException("Faculty number should be 10 letters/numbers long.");
                this.facNumber = value;
            }
        }
        public Student(string fName, string lName, string facNumber)
            :base(fName,lName)
        {
            this.FacNumber = facNumber;
        }
        public override string ToString()
        {
            return $"Type: Student, Fname: {this.FName}, LName:{this.LName}, facNumber:{this.FacNumber}";
        }

    }
}
