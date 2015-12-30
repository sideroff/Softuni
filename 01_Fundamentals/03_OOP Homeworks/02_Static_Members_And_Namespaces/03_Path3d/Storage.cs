using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using _01_Point3d;
using System.Text.RegularExpressions;
using _03_Path3d;

namespace _03_Path3d

{
    class Storage
    {
        public static string WriteToFile(string input, string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter($"../../{fileName}.txt"))
                {
                    writer.WriteLine(input);
                }
                return "All went as planned.";
            }
            catch (Exception)
            {
                return "Something went wrong.";
            }
        }
        public static void ReadFromFile(string fileName, Path3d path)
        {

            using (StreamReader reader = new StreamReader($"../../{fileName}.txt"))
            {
                string line = reader.ReadLine();
                Regex rgx = new Regex(@"(\d+),(\d+),(\d+)");
                MatchCollection matches = rgx.Matches(line);

                foreach (Match match in matches)
                {
                    int x = int.Parse(match.Groups[1].Value);
                    int y = int.Parse(match.Groups[2].Value);
                    int z = int.Parse(match.Groups[3].Value);
                    path.addPoint(x, y, z);

                }

            }
        }
    }
}

