using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students_Directory;

namespace _09.WeakStudents
{
    class WeakStudents
    {
        static void Main(string[] args)
        {
            StudentsDirectory database = new StudentsDirectory();

            var weakStudents =
                from student in database.Students
                where (student.Marks.Count(x => x == 2) == 2)
                select student;
            foreach(var student in weakStudents)
                Console.WriteLine("{0} {1}, {2}", student.FirstName, student.LastName, string.Join(",", student.Marks));

        }
    }
}
