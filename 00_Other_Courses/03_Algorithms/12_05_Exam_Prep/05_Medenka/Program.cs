using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Medenka
{
    using System.CodeDom;

    class Program
    {
        static StringBuilder output = new StringBuilder();

        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            StringBuilder sb = new StringBuilder();
            GenerateCombinations(0, numbers, "");
            Console.Write(output);
        }

        private static void GenerateCombinations(int index, int[] array, string sb)
        {
            if (index == array.Length)
            {
                output.AppendLine(sb.Substring(0, sb.Length - 1));
                return;
            }
            int sum = 0;
            for (int i = index; i < array.Length; i++)
            {
                sum += array[i];
                sb += array[i].ToString();
                if (sum == 1)
                {
                    GenerateCombinations(i + 1, array, sb + "|");
                }
                if (sum > 1)
                {
                    return;
                }
            }
        }
    }
}

