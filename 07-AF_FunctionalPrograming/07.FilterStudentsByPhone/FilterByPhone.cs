using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students_Directory;

namespace _07.FilterStudentsByPhone
{
    class FilterByPhone
    {
        static void Main(string[] args)
        {
            StudentsDirectory database = new StudentsDirectory();
            var studentsByPhone =
                from student in database.Students
                where student.Phone.StartsWith("02") || student.Phone.StartsWith("+3592")|| student.Phone.StartsWith("+359 2")
                select student;
            foreach (var student in studentsByPhone) Console.WriteLine("{0} {1}, {2}",student.FirstName, student.LastName, student.Phone);
        }
    }
}
