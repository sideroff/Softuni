namespace ConsoleApplication1
{
    using System;

    class Program
    {
        static void Main()
        {
            var matrix = new double[,] 
            { 
                { 1, 3 }, 
                { 5, 7 }
            };
            var matrix2 = new double[,]
            {
                { 4, 2 }, 
                { 1, 5 }
            };

            var result = CalculateMatrices(matrix, matrix2);

            PrintThisMatrix(result);
        }

        private static void PrintThisMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static double[,] CalculateMatrices(double[,] first, double[,] second)
        {
            if (first.GetLength(1) != second.GetLength(0))
            {
                throw new Exception("Error!");
            }

            var firstRows = first.GetLength(1);
            var result = new double[first.GetLength(0), second.GetLength(1)];

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    for (int k = 0; k < firstRows; k++)
                    {
                        result[i, j] += first[i, k] * second[k, j];
                    }
                }
            }

            return result;
        }
    }
}