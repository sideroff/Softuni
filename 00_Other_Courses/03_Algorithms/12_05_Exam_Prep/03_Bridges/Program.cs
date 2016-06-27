using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Bridges
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var result = Enumerable.Repeat("X", sequence.Length).ToArray();

            int last = 0;
            for (var i = 1; i < sequence.Length; i++)
            {
                for (int j = last; j < i; j++)
                {
                    if (sequence[i] == sequence[j])
                    {
                        last = i;
                        result[j] = sequence[j].ToString();
                        result[i] = sequence[i].ToString();
                        break;
                    }
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
