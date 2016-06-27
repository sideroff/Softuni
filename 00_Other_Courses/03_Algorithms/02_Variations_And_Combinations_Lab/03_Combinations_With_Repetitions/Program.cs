namespace _03_Combinations_With_Repetitions
{
    using System;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] array = new int[k];

            GenerateCombinations(array, n, 0);
        }

        static void GenerateCombinations(int[] array, int sizeOfSet, int index, int start = 1)
        {
            if (index == array.Length)
            {
                PrintArray(array);
                return;
            }
            for (int i = start; i <= sizeOfSet; i++)
            {
                array[index] = i;
                GenerateCombinations(array,sizeOfSet,index+1,i);
            }
        }
        static void PrintArray(int[] array)
        {
            Console.WriteLine(string.Join(" ", array));
        }
    }
}
