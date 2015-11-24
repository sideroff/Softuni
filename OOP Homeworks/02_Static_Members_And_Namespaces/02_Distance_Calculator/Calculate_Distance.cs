using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Point3d;

namespace _02_Distance_Calculator
{
    public static class Calculate_Distance
    {
        public static double Calc_Distance(Point3D a, Point3D b)
        {
            return Math.Sqrt( Math.Pow((b.X - a.X), 2) +
                              Math.Pow((b.Y - a.Y), 2) +
                              Math.Pow((b.Z - a.Z), 2));
        }
    }
}
