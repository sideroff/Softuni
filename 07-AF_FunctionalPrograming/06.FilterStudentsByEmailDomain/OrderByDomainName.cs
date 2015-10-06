using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students_Directory;


namespace _06.FilterStudentsByEmailDomain
{
    class OrderByDomainName
    {
        static void Main(string[] args)
        {
            StudentsDirectory database = new StudentsDirectory();

            var studentsByEmail =
                from student in database.Students
                where student.Email.Substring(student.Email.Length - 6) == "abv.bg"
                select student;
            foreach (var student in studentsByEmail)
                Console.WriteLine("{0} {1}, {2}", student.FirstName, student.LastName, student.Email);

        }
    }
}
