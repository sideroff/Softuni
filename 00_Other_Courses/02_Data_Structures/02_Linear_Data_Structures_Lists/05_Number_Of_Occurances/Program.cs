using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Number_Of_Occurances
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Dictionary<int,int> dict = new Dictionary<int, int>();

            foreach (var i in list)
            {
                if (!dict.ContainsKey(i))
                {
                    dict[i] = 0;
                }
                dict[i]++;
            }

            foreach (var kvPair in dict)
            {
                Console.WriteLine($"{kvPair.Key} -> {kvPair.Value} times");
            }
        }
    }
}
