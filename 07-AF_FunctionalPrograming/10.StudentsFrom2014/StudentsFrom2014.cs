using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students_Directory;
using System.Text.RegularExpressions;


namespace _10.StudentsFrom2014
{
    class StudentsFrom2014
    {
        static void Main(string[] args)
        {
            StudentsDirectory database = new StudentsDirectory();
            string pattern = @"(\d{4}14|\d{4}15)";
            Regex rgx = new Regex(pattern);
            var studentsFrom2014 =
                from student in database.Students
                where rgx.IsMatch(student.FacultyNumber.ToString())
                select student;
            foreach(var student in studentsFrom2014)
                Console.WriteLine("{0} {1}, {2}",student.FirstName,student.LastName,student.FacultyNumber);
        }
    }
}
