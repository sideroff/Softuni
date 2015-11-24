using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Point3d
{
    public class Point3D
    {
        private static int pointCounter=0;
        private static Point3D startingPoint = new Point3D(0, 0, 0);

        private int x;
        private int y;
        private int z;
        private int count;
        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }
        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }
        public int Z
        {
            get { return this.z; }
            set { this.z = value; }
        }
        private int Count
        {
            get { return this.count; }
            set
            {
                this.count = value;
            }
        }
        public static string StartingPoint
        {
            get
            {
                return String.Format($"Starting Point({Point3D.startingPoint.X},{Point3D.startingPoint.Y},{Point3D.startingPoint.Z})");
            }
        }

        public Point3D(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.Count = Point3D.pointCounter++;
        }
        public override string ToString()
        {
            Point3D.pointCounter++;
            return String.Format($"({this.X},{this.Y},{this.Z})");

        }
    }
}
