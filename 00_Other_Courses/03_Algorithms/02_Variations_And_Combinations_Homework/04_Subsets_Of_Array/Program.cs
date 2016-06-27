using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Subsets_Of_Array
{
    class Program
    {
        private static string[] words;
        static void Main()
        {
            words = Console.ReadLine().Split().ToArray();
            int n = words.Length;
            int k = int.Parse(Console.ReadLine());

            int[] array = new int[k];

            GenerateCombinations(array, n);

        }

        private static void GenerateCombinations(int[] array, int lenghtOfSet, int index = 0, int startAt = 0)
        {
            if (index == array.Length)
            {
                PrintArray(array);
                return;
            }
            for (int i = startAt; i < lenghtOfSet; i++)
            {
                array[index] = i;
                GenerateCombinations(array, lenghtOfSet, index + 1, i + 1);
            }
        }

        static void PrintArray(int[] array)
        {
            Console.WriteLine(string.Join(" ", array.Select(i => words[i])));
        }
    }
}
