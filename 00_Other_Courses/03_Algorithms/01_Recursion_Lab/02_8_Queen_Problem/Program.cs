namespace _02_8_Queen_Problem
{
    using System;

    class Program
    {
        public static void Main(string[] args)
        {
            Chessboard.PutQueens(0);
            Console.WriteLine(Chessboard.solutionsFound);
        }
    }
}
