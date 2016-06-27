namespace _07_Connecte_Areas_In_Matrix
{
    using System;
    using System.Linq;
    using System.Runtime.InteropServices;

    class Program
    {
        private static string[,] matrix;
        private static int areaCount = 0;
        private static bool shouldIncreaseArea = false;
        static void Main()
        {
            Console.WriteLine("This algorithm finds all connected areas");
            Console.WriteLine($"sample input:{Environment.NewLine}" +
                              $"3{Environment.NewLine}" +
                              $"3{Environment.NewLine}" +
                              $"oxo{Environment.NewLine}" +
                              $"xxx{Environment.NewLine}" +
                              $"oxo");
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            matrix = new string[rows, cols];
            Read();
            FindAreas();
            Print();

        }

        static void Read()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j].ToString();
                }
            }
        }
        static void Print()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Total areas = {areaCount}");
        }
        static void FindAreas()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    shouldIncreaseArea = false;
                    MarkThisAndAdjacent(i, j);
                    if (shouldIncreaseArea)
                    {
                        areaCount++;
                    }
                }
            }
        }

        static void MarkThisAndAdjacent(int i, int j)
        {
            if (i < 0 || i >= matrix.GetLength(0) ||
                j < 0 || j >= matrix.GetLength(1))
            {
                return;
            }
            if (matrix[i, j] != "o")
            {
                return;
            }
            matrix[i, j] = areaCount.ToString();
            shouldIncreaseArea = true;
            MarkThisAndAdjacent(i - 1, j);
            MarkThisAndAdjacent(i + 1, j);
            MarkThisAndAdjacent(i, j - 1);
            MarkThisAndAdjacent(i, j + 1);

        }
    }
}
