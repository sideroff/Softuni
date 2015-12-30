using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Point3d;

namespace _03_Path3d
{
    class Path3d
    {
        List<Point3D> path;
        public Path3d()
        {
            this.path = new List<Point3D>();
        }

        public void addPoint(int x, int y, int z)
        {
            Point3D newPoint = new Point3D(x, y, z);
            this.path.Add(newPoint);
        }

        public override string ToString()
        {
            return string.Join(" > ", this.path);
        }
    }
}
