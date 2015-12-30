using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Point3d;

namespace _02_Distance_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {

            Point3D a = new Point3D(1, 2, 3);
            Point3D b = new Point3D(2, 3, 4);
            Console.WriteLine("Distance between\n" + a + "and\n" + b + "is: " + Calculate_Distance.Calc_Distance(a, b));
        }
    }
}
