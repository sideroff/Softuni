namespace _01_Sum_And_Average
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            List<int> list = new List<int>();
            long sum = 0;
            double average = 0;

            string input = Console.ReadLine();
            if (input != string.Empty)
            {
                list = input
                    .Split()
                    .Select(int.Parse)
                    .ToList();
                sum = list.Sum();
                average = list.Average();
            }

            Console.WriteLine($"Sum={sum}; Average={average}");

        }
    }
}

