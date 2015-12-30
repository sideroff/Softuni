using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03_Company_Hierarchy.Persons.Employees.RegularEmployees;

namespace _03_Company_Hierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(0);
            SalesEmployee saler = new SalesEmployee(1,"Goasho","Goshev", 555, Departments.Sales);
            saler.AddSale(new Sale("Waffle",null,0.99m));
            saler.AddSale(new Sale("Cheese",DateTime.Now,3.99m));

            Developer developer = new Developer(2,"Ivan","Ivanov", 231,Departments.Production);
            developer.AddProject(new Project("Softuni", new DateTime(2015,11,28),"University", true));
            developer.AddProject(new Project("Google X",null,"Alien Tech", true));
            developer.Projects.FirstOrDefault(project => project.Name == "Google X").CloseProject();

            Manager manager = new Manager(3,"Petar","Petrov",800,Departments.Accounting);
            manager.AddEmployee(saler);
            manager.AddEmployee(developer);

            Customer customer = new Customer(4,"Baba","Ivanka",300);
            //This doesnt work as by demand.
            //manager.AddEmployee(customer);

            List<Person> people = new List<Person>();
            people.Add(saler);
            people.Add(developer);
            people.Add(manager);
            people.Add(customer);

            people.ForEach(person => Console.WriteLine(person));
        }
    }
}
