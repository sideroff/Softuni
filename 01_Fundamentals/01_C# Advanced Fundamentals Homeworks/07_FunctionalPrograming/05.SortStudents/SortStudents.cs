using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students_Directory;

namespace _05.SortStudents
{
    class SortStudents
    {
        static void Main(string[] args)
        {
            StudentsDirectory database = new StudentsDirectory();

            var sortedStudents =
                from student in database.Students
                orderby student.FirstName descending,
                student.LastName descending
                select student;

            var sortedStudent = database.Students.OrderByDescending(student => student.FirstName).ThenByDescending(student => student.LastName);

            Console.WriteLine("LINQ");
            foreach (var student in sortedStudent) Console.Write("{0} {1}\n",student.FirstName, student.LastName);
            Console.WriteLine();
            Console.WriteLine("Lambda");
            foreach(var student in sortedStudents) Console.Write("{0} {1}\n", student.FirstName, student.LastName);
        }
    }
}
