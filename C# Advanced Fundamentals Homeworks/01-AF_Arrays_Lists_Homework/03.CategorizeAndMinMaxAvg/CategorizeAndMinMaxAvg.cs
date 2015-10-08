//Write a program that reads N floating-point numbers from the console.
//    Your task is to separate them in two sets, one containing only the round numbers
//    (e.g. 1, 1.00, etc.) and the other containing the floating-point numbers with non-zero fraction.
//    Print both arrays along with their minimum, maximum, sum and average (rounded to two decimal places). 

using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CategorizeAndMinMaxAvg
{
    class CategorizeAndMinMaxAvg
    {
        static void Main(string[] args)
        {
            double[] ainput = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            List<int> lint = new List<int>();
            List<double> ldoub = new List<double>();
            for (int i = 0; i < ainput.Length; i++)
            {
                if (ainput[i] % 1 == 0)
                {
                    lint.Add((int)ainput[i]);
                }
                else
                {
                    ldoub.Add(ainput[i]);
                }
            }
            Console.WriteLine(string.Join(", ", lint));
            Console.WriteLine("{0:F2}, {1:F2}, {2:F2}", lint.Min(),lint.Max(),lint.Average());
            Console.WriteLine(string.Join(", ", ldoub));
            Console.WriteLine("{0:F2}, {1:F2}, {2:F2}", ldoub.Min(), ldoub.Max(), ldoub.Average());


        }
    }
}
