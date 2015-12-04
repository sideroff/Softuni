using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Human_Student_Worker
{
    class Worker : Human
    {
        decimal weekSalary;
        int workHoursPerDay;

        public decimal WeekSalary { get; set; }
        public int WorkHoursPerDay { get; set; }

        public Worker(string fName, string lName, decimal weekSalary, int workHoursPerDay)
            :base(fName,lName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal MoneyPerHour()
        {
            return this.WeekSalary / this.WorkHoursPerDay * 7m;
        }
        public override string ToString()
        {
            return $"Type:  Worker, Fname: {this.FName}, LName:{this.LName}, MoneyPerHour:{this.MoneyPerHour():F2}";
        }
    }
}
