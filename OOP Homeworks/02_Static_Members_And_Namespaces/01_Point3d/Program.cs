using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Point3d
{
    class Program
    {
        static void Main(string[] args)
        {
            Point3D a = new Point3D(1, 2, 3);
            Point3D b = new Point3D(2, 3, 4);
            Console.WriteLine(Point3D.StartingPoint);
            Console.WriteLine(a);
            Console.WriteLine(b);
            
        }
    }
}
