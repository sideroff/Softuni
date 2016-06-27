using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Combinations_Without_Repetitions
{
    class Program
    {
        private static int n;
        private static int k;
        private static int[] array;
        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());
            array = new int[k];

            GetCombinations(1,n,array,0);
        }

        static void GetCombinations(int digit, int maxDigit, int[] array, int index)
        {
            if (index == array.Length)
            {
                Console.WriteLine(string.Join(" ", array));
                return;
            }
            for (int i = digit; i <= maxDigit; i++)
            {
                array[index] = i;
                GetCombinations(i + 1, maxDigit, array, index + 1);
            }
        }
    }
}
