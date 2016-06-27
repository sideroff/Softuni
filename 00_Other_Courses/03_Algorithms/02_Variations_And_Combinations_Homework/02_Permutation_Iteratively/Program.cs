namespace _02_Permutation_Iteratively
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {

            int maxDigit = int.Parse(Console.ReadLine());
            int[] array = Enumerable.Range(1, maxDigit).ToArray();
            int numberOfPermutations = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    Swap(ref array[i], ref array[j]);
                    numberOfPermutations++;
                    PrintArray(array);
                }
            }
            Console.WriteLine("Total permutatuions: " + numberOfPermutations);
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

        static void PrintArray(int[] array)
        {
            Console.WriteLine(string.Join(" ", array));
        }
    }
}
