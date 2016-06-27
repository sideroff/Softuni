namespace _03_Combinations_With_Repetitions
{
    using System;

    class Program
    {
        private static int n;
        private static int k;
        private static int[] array;

        public static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());
            array = new int[k];
            GetCombinations(0, 1, n);

        }

        static void GetCombinations(int index, int digit, int maxDigit)
        {
            if (index == array.Length)
            {
                Console.WriteLine($"({string.Join(" ", array)})");
                return;
            }

            for (int i = digit; i <= maxDigit; i++)
            {
                array[index] = i;
                GetCombinations(index + 1, i, maxDigit);
            }
        }
    }
}


