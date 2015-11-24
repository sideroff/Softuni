using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Laptop_Shop
{
    class Main_Laptop_Shop
    {
        static void Main(string[] args)
        {
            Laptop newLaptop = new Laptop("Pravets fastasshit3000", 999);
            Laptop newerLaptop = new Laptop("Lenovo", 500, "epa Lenovo mai", "nqkuv gotin procesor", 500, "nvidia avi komodo3000", "ssd 9999", "1 milion incha monitor", "bateriq 1950");
            Console.WriteLine(newLaptop);
            Console.WriteLine();
            Console.WriteLine(newerLaptop);
        }
    }
}
