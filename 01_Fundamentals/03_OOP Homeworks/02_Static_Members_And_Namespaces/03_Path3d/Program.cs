using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _03_Path3d
{
    class Program
    {
        static void Main(string[] args)
        {
            Path3d path = new Path3d();
            path.addPoint(1, 2, 3);
            path.addPoint(2, 3, 4);
            path.addPoint(3, 4, 5);

            Console.WriteLine(path);

            Storage.WriteToFile(path.ToString(), "pathfile");
            Path3d newPath = new Path3d();
            Storage.ReadFromFile("pathfile", newPath);
            Console.WriteLine("new path is: " + newPath.ToString());

        }
    }
}
