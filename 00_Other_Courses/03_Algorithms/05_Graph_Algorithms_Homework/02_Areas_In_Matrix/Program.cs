using System;

namespace _02_Areas_In_Matrix
{
    using System.Collections.Generic;

    class Program
    {
        private static bool[,] visited;
        static void Main()
        {
            //sample input:
            //6
            //8
            //aacccaac
            //baaaaccc
            //baabaccc
            //bbdaaccc
            //ccdccccc
            //ccdccccc

            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            char[,] array = new char[rows, cols];
            visited = new bool[rows, cols];
            SortedDictionary<char, int> areas = new SortedDictionary<char, int>();
            for (int i = 0; i < rows; i++)
            {
                char[] elements = Console.ReadLine().ToCharArray();
                for (int j = 0; j < elements.Length; j++)
                {
                    array[i, j] = elements[j];
                }
            }

            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int col = 0; col < array.GetLength(1); col++)
                {
                    if (visited[row, col])
                    {
                        continue;
                    }
                    if (!areas.ContainsKey(array[row, col]))
                    {
                        areas[array[row, col]] = 0;
                    }
                    areas[array[row, col]]++;
                    TraverseArray(row, col, array);
                }
            }
            
            foreach (var area in areas)
            {
                Console.WriteLine($"{area.Key} - {area.Value}");
            }
        }

        private static void TraverseArray(int row, int col, char[,] array)
        {
            visited[row, col] = true;
            TryGo(row - 1, col, row, col, array);
            TryGo(row, col + 1, row, col, array);
            TryGo(row + 1, col, row, col, array);
            TryGo(row, col - 1, row, col, array);
        }

        private static void TryGo(int toRow, int toCol, int fromRow, int fromCol, char[,] array)
        {
            if (IsInArray(toRow, toCol, array))
            {
                if (isSameCharAs(array[fromRow, fromCol], toRow, toCol, array))
                {
                    if (!visited[toRow, toCol])
                    {
                        TraverseArray(toRow, toCol, array);
                    }
                }
            }
        }

        private static bool isSameCharAs(char template, int row, int col, char[,] array)
        {
            return array[row, col] == template;
        }
        private static bool IsInArray(int row, int col, char[,] array)
        {
            if (row >= 0 && row < array.GetLength(0)
                && col >= 0 && col < array.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}

