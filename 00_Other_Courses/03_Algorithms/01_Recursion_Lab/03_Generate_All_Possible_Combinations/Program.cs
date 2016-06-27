using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Generate_All_Possible_Combinations
{
    class Program
    {
        public static int count = 0;

        static void Main(string[] args)
        {
            Console.Write("Number lenght: ");
            int numberLenght = int.Parse(Console.ReadLine());
            Console.Write("Digits from 0 to (inclusive): ");
            int digits = int.Parse(Console.ReadLine());

            int[] array = new int[numberLenght];

            GenerateCombinations(array, numberLenght - 1, digits);

            Console.WriteLine($"Number of different combinations = {count}");
        }

        static void GenerateCombinations(int[] array, int index, int digits)
        {
            if (index == -1)
            {
                Console.WriteLine(string.Join(" ", array));
                count++;
                return;
            }
            for (int i = 0; i <= digits; i++)
            {
                array[index] = i;
                GenerateCombinations(array, index - 1, digits);
            }
        }
    }
}
