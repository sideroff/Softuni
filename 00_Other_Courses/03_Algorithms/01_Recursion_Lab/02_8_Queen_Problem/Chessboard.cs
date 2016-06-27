namespace _02_8_Queen_Problem
{
    using System;
    using System.Collections.Generic;

    public class Chessboard
    {
        public const int size = 8;

        public static bool[,] board = new bool[size, size];
        public static int solutionsFound = 0;
        static HashSet<int> attackedRows = new HashSet<int>();
        static HashSet<int> attackedCols = new HashSet<int>();
        static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        static HashSet<int> attackedRightDiagonals = new HashSet<int>();


        public static void PutQueens(int row)
        {
            if (row == size)
            {
                PrintSolution();
            }
            else
            {
                for (int col = 0; col < size; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAllAttackedPositions(row, col);
                        PutQueens(row + 1);
                        UnMarkAllAttackedPositions(row, col);
                    }
                }
            }
        }

        static bool CanPlaceQueen(int row, int col)
        {
            var positionOccupied = attackedRows.Contains(row) || attackedCols.Contains(col)
                                   || attackedLeftDiagonals.Contains(col - row)
                                   || attackedRightDiagonals.Contains(col + row);
            return !positionOccupied;
        }

        static void MarkAllAttackedPositions(int row, int col)
        {
            attackedRows.Add(row);
            attackedCols.Add(col);
            attackedLeftDiagonals.Add(col - row);
            attackedRightDiagonals.Add(col + row);
            board[row, col] = true;

        }

        static void UnMarkAllAttackedPositions(int row, int col)
        {
            attackedRows.Remove(row);
            attackedCols.Remove(col);
            attackedLeftDiagonals.Remove(col - row);
            attackedRightDiagonals.Remove(col + row);
            board[row, col] = false;
        }

        static void PrintSolution()
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (board[row, col])
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write('-');
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            solutionsFound++;
        }
    }
}