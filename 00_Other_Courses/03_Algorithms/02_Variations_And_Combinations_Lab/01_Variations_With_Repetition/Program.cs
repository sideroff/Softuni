namespace _01_Variations_With_Repetition
{
    using System;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] array = new int[k];

            GenerateVariations(array, n);

        }

        static void GenerateVariations(int[] array, int sizeOfSet, int index = 0)
        {
            if (index == array.Length)
            {
                PrintArray(array);
                return;
            }
            for (int i = 1; i <= sizeOfSet; i++)
            {
                array[index] = i;
                GenerateVariations(array, sizeOfSet, index + 1);
            }
        }

        static void PrintArray(int[] array)
        {
            Console.WriteLine(string.Join(" ", array));
        }
    }
}
