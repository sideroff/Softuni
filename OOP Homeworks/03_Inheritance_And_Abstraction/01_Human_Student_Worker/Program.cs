using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Human_Student_Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("Nichole", "Doucet", "1111111111"));
            students.Add(new Student("Sueann", "Updegraff", "8888888888"));
            students.Add(new Student("Terina", "Mccain", "3333333333"));
            students.Add(new Student("Vikki", "Krob", "4444444444"));
            students.Add(new Student("Pablo", "Bourgoin", "9999999999"));
            students.Add(new Student("Sean", "Kimberlin", "5555555555")); 
            students.Add(new Student("Sanjuana", "Cistrunk", "6666666666"));
            students.Add(new Student("Ching", "Carra", "0000000000")); 
            students.Add(new Student("Nick", "Tracey", "2222222222"));
            students.Add(new Student("Mackenzie", "Lupo", "7777777777"));


            List<Worker> workers = new List<Worker>();
            workers.Add(new Worker("Belia", "Sachs", 11m, 9));
            workers.Add(new Worker("Alia", "Slosa", 22m, 8));
            workers.Add(new Worker("Kanesha", "Exner", 33m, 7));
            workers.Add(new Worker("Charise", "Murr", 44m, 6));
            workers.Add(new Worker("Alia", "Sloss", 55m, 5)); //5
            workers.Add(new Worker("Cassi", "Braverman", 66m, 4));
            workers.Add(new Worker("Dorinda", "Antes", 77m, 3));
            workers.Add(new Worker("Freda", "Melle", 88m, 2));
            workers.Add(new Worker("Sarah", "Appling", 99m, 1)); //10
            workers.Add(new Worker("Zella", "Quist", 100m, 10));

            Console.WriteLine("\nSorted workers:");
            workers.Sort((e1, e2) => e1.MoneyPerHour().CompareTo(e2.MoneyPerHour()));
            workers.ForEach(x => Console.WriteLine(x));


            Console.WriteLine("\nSorted students:");
            students.Sort((e1, e2) => string.Compare(e1.FacNumber, e2.FacNumber));
            students.ForEach(x => Console.WriteLine(x));
            

            List<Human> humans = new List<Human>();
            foreach (var student in students)
            { humans.Add(student);}
            foreach (var worker in workers)
            {humans.Add(worker);}

            Console.WriteLine("\nSorted humans:");
            humans.OrderBy(e1 => e1.FName).ThenBy(e1 => e1.LName).ToList().ForEach(x => Console.WriteLine(x));

        }
    }
}
