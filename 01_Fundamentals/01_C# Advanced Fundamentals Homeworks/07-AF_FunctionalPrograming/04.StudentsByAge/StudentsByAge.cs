using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students_Directory;

class StudentsByAge
{
    static void Main()
    {
        // creating an instance of the StudentsDirectory class, so that we can use its IList<Student> 
        StudentsDirectory database = new StudentsDirectory();

        // running LINQ query
        var studentsByAge =
            from student in database.Students
            orderby student.Age
            select student;


        // printing
        foreach (var student in studentsByAge)
        {
            Console.WriteLine("Name: {0} {1}, Age: {2}",
                                student.FirstName, student.LastName, student.Age);
        }
    }
}
