using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Combinations_Iteratively
{
    using System.Runtime.Remoting.Messaging;

    class Program
    {
        static void Main()
        {

            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine();
            int[] com = new int[k];
            int numberOfPermutations = 0;
            for (int i = 0; i < k; i++) com[i] = i;
            while (com[k - 1] < n)
            {
                for (int i = 0; i < k; i++)
                {
                    Console.Write(com[i]+" ");
                }
                Console.WriteLine();
                int t = k - 1;
                while (t != 0 && com[t] == n - k + t)
                {
                    t--;
                }
                com[t]++;
                for (int i = t + 1; i < k; i++)
                {
                    com[i] = com[i - 1] + 1;
                }
            }
        }


    }
}
