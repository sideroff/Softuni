using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Company_Hierarchy.Persons.Employees.RegularEmployees
{
    public class Sale
    {
        public Sale(string productName, DateTime? date, decimal price)
        {
            ProductName = productName;
            Date = date;
            Price = price;
        }

        public string ProductName { get; set; }

        public DateTime? Date { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"Sale Name: {this.ProductName}, Sale price: {this.Price}";
        }
    }
}
