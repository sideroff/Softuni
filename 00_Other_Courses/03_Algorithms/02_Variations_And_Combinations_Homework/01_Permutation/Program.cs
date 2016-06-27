namespace _01_Permutation
{
    using System;
    using System.Linq;

    class Program
    {

        private static int numberOfPermutations = 0;

        static void Main()
        {
            int maxDigit = int.Parse(Console.ReadLine());
            int[] array = Enumerable.Range(1, maxDigit).ToArray();
            bool[] used = new bool[maxDigit];

            //CalculatePermutations(array, used, maxDigit);
            //PrintNumberOfPermutationsAndMakeCounterZero();

            CalculatePermutationsWithoutUsedArray(array);
            PrintNumberOfPermutationsAndMakeCounterZero();
        }

        private static void CalculatePermutationsWithoutUsedArray(int[] array, int startIndex = 0)
        {
            if (startIndex == array.Length - 1)
            {
                numberOfPermutations++;
                PrintArray(array);
                return;
            }
            else
            {
                for (int i = startIndex; i < array.Length; i++)
                {
                    Swap(ref array[startIndex], ref array[i]);
                    CalculatePermutationsWithoutUsedArray(array, startIndex + 1);
                    Swap(ref array[startIndex], ref array[i]);
                }
            }
        }

        static void Swap(ref int i, ref int j)
        {
            if (i == j)
            {
                return;
            }

            i ^= j;
            j ^= i;
            i ^= j;
        }

        private static void CalculatePermutations(int[] array, bool[] used, int maxDigit, int index = 0)
        {
            if (index == array.Length)
            {
                numberOfPermutations++;
                PrintArray(array);
                return;
            }
            for (int i = 1; i <= maxDigit; i++)
            {
                if (!used[i - 1])
                {
                    used[i - 1] = true;
                    array[index] = i;
                    CalculatePermutations(array, used, maxDigit, index + 1);
                    used[i - 1] = false;
                }
            }
        }

        static void PrintArray(int[] array)
        {
            Console.WriteLine(string.Join(" ", array));
        }

        static void PrintNumberOfPermutationsAndMakeCounterZero()
        {
            Console.WriteLine("Total Permutations: " + numberOfPermutations);
            numberOfPermutations = 0;
        }
    }
}