namespace _02_Nested_Loops
{
    using System;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            NestedLoops(n, array);
        }

        static void NestedLoops(int n, int[] array, int level = 0)
        {
            if (level == n)
            {
                PrintArray(array);
                return;
            }
            for (int i = 0; i < n; i++)
            {
                array[level] = i;

                NestedLoops(n, array, level + 1);
            }
        }

        static void PrintArray(int[] array)
        {
            Console.WriteLine(string.Join(" ", array));
        }
    }
}

