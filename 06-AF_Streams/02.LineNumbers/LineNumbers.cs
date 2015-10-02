using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _02.LineNumbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("../../read.txt");
            StreamWriter writer = new StreamWriter("../../write.txt");
            using (reader)
            {
                using (writer)
                {
                    int lineNumber = 0;
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        lineNumber++;
                        writer.WriteLine("Line {0}: {1}", lineNumber, line);
                        line = reader.ReadLine();
                    }

                }
            }
        }
    }
}
