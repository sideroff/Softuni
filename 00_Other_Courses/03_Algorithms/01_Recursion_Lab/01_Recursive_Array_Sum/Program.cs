namespace _01_Recursive_Array_Sum
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Input array elements seperated by space:");
            string input = Console.ReadLine();
            int[] array = new int[0];
            if (!String.IsNullOrEmpty(input))
            {
                array = input.Split().Select(int.Parse).ToArray();
            }

            Console.WriteLine(FindSum(array));
        }

        private static decimal FindSum(int[] array, int index = 0)
        {
            if (index == array.Length)
            {
                return 0;
            }

            return array[index] + FindSum(array, index + 1);
        }
    }
}
