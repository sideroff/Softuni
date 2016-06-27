using System;
using System.Linq;

namespace _01_Election
{
    class Program
    {
        private static int numberOfPartii = 0;
        private static int targetSum = 0;
        private static int[] myNumbers;
        static void Main()
        {

            targetSum = int.Parse(Console.ReadLine());
            int numbers = int.Parse(Console.ReadLine());
            myNumbers = new int[numbers];
            for (int i = 0; i < numbers; i++)
            {
                myNumbers[i] = int.Parse(Console.ReadLine());
            }

            int[] array = new int[numbers];

            for (int i = 1; i <= numbers; i++)
            {
                GenerateCombinations(i,array, numbers, 0);
            }
            Console.WriteLine(numberOfPartii);
        }

        static void GenerateCombinations(int end,int[] array, int sizeOfSet, int index, int start = 0)
        {
            if (index == end)
            {
                PrintArray(end, array);
                return;
            }
            for (int i = start; i < sizeOfSet; i++)
            {
                array[index] = i;
                GenerateCombinations(end,array, sizeOfSet, index + 1, i + 1);
            }
        }

        static void PrintArray(int end,int[] array)
        {
            long sum = 0;
            for (int i = 0; i < end; i++)
            {
                sum += myNumbers[array[i]];
            }
            if (sum >= targetSum)
            {
                numberOfPartii++;
            }
        }
    }
}

