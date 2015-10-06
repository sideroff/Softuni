using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students_Directory;

namespace _08.ExcellentStudents
{
    class ExcellentStudents
    {
        static void Main(string[] args)
        {
            StudentsDirectory database = new StudentsDirectory();
            var excellentStudent =
                from student in database.Students
                where student.Marks.Contains(6)
                select student;
            foreach(var student in excellentStudent)
            Console.WriteLine("{0} {1}, {2}", student.FirstName,student.LastName,string.Join(",",student.Marks));

        }
    }
}
