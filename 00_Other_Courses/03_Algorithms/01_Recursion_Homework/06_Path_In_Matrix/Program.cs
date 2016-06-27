namespace _06_Path_In_Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Runtime.InteropServices;

    class Program
    {
        private static int[,] matrix;
        static void Main()
        {
            Console.WriteLine("This algorithm finds possible paths to the exit;");
            Console.WriteLine("Mark start with s, and exit with e, steppable places with whitespace and non-steppable places with *");
            Console.WriteLine("Number of Matrix rows:");
            int rows = int.Parse(Console.ReadLine());
            Console.WriteLine("Number of Matrix colums:");
            int cols = int.Parse(Console.ReadLine());
            int startRow = 0;
            int startCol = 0;
            matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = row[j];
                    if (row[j] == 's')
                    {
                        startRow = i;
                        startCol = j;
                        matrix[i, j] = ' ';
                    }
                }
            }
            FindPath(startRow, startCol, ' ', new Stack<char>());

        }

        static void FindPath(int row, int col, char direction, Stack<char> path)
        {
            switch (direction)
            {
                case 'U':
                    row--;
                    break;
                case 'D':
                    row++;
                    break;
                case 'L':
                    col--;
                    break;
                case 'R':
                    col++;
                    break;
                default:
                    break;
            }
            if (row < 0 || row >= matrix.GetLength(0) ||
                col < 0 || col >= matrix.GetLength(1) ||
                matrix[row, col] == '*' ||
                matrix[row, col] == 's')
            {
                return;
            }

            path.Push(direction);
            if (matrix[row, col] == 'e')
            {
                Console.WriteLine($"Path:{string.Join("", path.Reverse())}");
                path.Pop();
                return;
            }
            matrix[row, col] = 's';

            FindPath(row, col, 'U', path);
            FindPath(row, col, 'D', path);
            FindPath(row, col, 'L', path);
            FindPath(row, col, 'R', path);

            matrix[row, col] = ' ';
            path.Pop();
        }
    }
}
