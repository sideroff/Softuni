using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.Customer;

namespace _02_Customer
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer one = new Customer("Gosho", "Peshev", "Meshev", 1111111111,"address","0000000000","email",CustomerType.Diamond);

            var two = one.Clone() as Customer;

            Console.WriteLine(two);
            Console.WriteLine(one == two);
            Console.WriteLine(one.CompareTo(two));



        }
    }
}
