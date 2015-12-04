using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Company_Hierarchy.Persons.Employees.RegularEmployees
{
    public class SalesEmployee : RegularEmployee
    {
        private List<Sale> sales;

        public SalesEmployee(uint id, string fname, string lname, uint salary, Departments deparment) 
            :base(id, fname, lname, salary, deparment)
        {
            this.sales = new List<Sale>();
        }

        public IEnumerable<Sale> Sales => this.sales;

        public void AddSale(Sale newSale)
        {
            this.sales.Add(newSale);
        }

        public override string ToString()
        {
            StringBuilder sb= new StringBuilder();
            this.sales.ForEach(sale => sb.Append(Environment.NewLine + "\t" + sale));

            return base.ToString() + sb.ToString();
        }
    }
}
