namespace _02_Variations_Without_Repetition
{
    using System;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] array = new int[k];
            bool[] used = new bool[n];

            GenerateVariations(array, n,used);

        }

        static void GenerateVariations(int[] array, int sizeOfSet,bool[] used, int index = 0)
        {
            if (index == array.Length)
            {
                PrintArray(array);
                return;
            }
            for (int i = 1; i <= sizeOfSet; i++)
            {
                if (!used[i-1])
                {
                    used[i-1] = true;
                    array[index] = i;
                    GenerateVariations(array, sizeOfSet,used, index + 1);
                    used[i-1] = false;
                }
            }
        }

        static void PrintArray(int[] array)
        {
            Console.WriteLine(string.Join(" ", array));
        }
    }
}
