using System;
using System.Linq;

class MacimalSum
{
    static void Main()
    {
        //reading matrix size
        int[] rowsAndColsInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        //creating the matrix
        int[,] matrix = new int[rowsAndColsInput[0], rowsAndColsInput[1]];

        int currentSum = 0;
        int maxSum = 0;
        int rowIndex = 0;
        int colIndex = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = input[j];
            }
        }
        for (int i = 0; i < matrix.GetLength(0) - 2; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 2; j++)
            {
                currentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] +
                             matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] +
                             matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    rowIndex = i;
                    colIndex = j;
                }
            }
        }

        Console.WriteLine("Sum = {0}", maxSum);

        for (int i = rowIndex; i < rowIndex + 3; i++)
        {
            for (int j = colIndex; j < rowIndex + 3; j++)
            {
                Console.Write("{0}, ", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}