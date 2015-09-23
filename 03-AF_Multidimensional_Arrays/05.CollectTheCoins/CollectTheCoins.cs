using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CollectTheCoins
{
    class CollectTheCoins
    {

        static char[][] matrix = new char[4][];
        static void Main(string[] args)
        {

            matrix[0] = "Sj0u$hbc".ToArray();
            matrix[1] = "$87yihc87".ToArray();
            matrix[2] = "Ewg3444".ToArray();
            matrix[3] = "$4$$".ToArray();
            //for (int i = 0; i < 4; i++)
            //{
            //    matrix[i] = Console.ReadLine().ToArray();
            //}
            List<char> moves = new List<char>();
            moves = Console.ReadLine().ToArray().ToList();

            int coins = 0;
            int walls = 0;
            if (matrix[0][0] == '$') coins++;
            if (moves.Count>0)
            {
                int row = 0;
                int col = 0;
                do
                {
                    GetNextStep(GetDirection(moves), ref row, ref col,ref coins, ref walls);
                }
                while (moves.Count != 0);
            }
            Console.WriteLine("Coins collected: {0}", coins);
            Console.WriteLine("Walls hit: {0}", walls);
        }

        private static void GetNextStep(char move, ref int row, ref int col, ref int coins, ref int walls) // check what the move is and do the corresponding
                                                                                                           // move through the matrix if possible
        {
            switch (move)
            {
                case '^':
                    if ((row - 1 >= 0) && (col < matrix[row - 1].Length))
                    {
                        row--;
                        if (matrix[row][col] == '$') coins++;
                    }
                    else walls++;
                    break;
                case '>':
                    if (col + 1 < matrix[row].Length)
                    {
                        col++;
                        if (matrix[row][col] == '$') coins++;
                    }
                    else walls++;
                    break;
                case 'v':
                    if ((row + 1 < 4) && (col < matrix[row + 1].Length))
                    {
                        row++;
                        if (matrix[row][col] == '$') coins++;
                    }
                    else walls++;
                    break;
                case '<':
                    if (col - 1 >= 0)
                    {
                        col--;
                        if (matrix[row][col] == '$') coins++;
                    }
                    else walls++;
                    break;
                default:
                    break;
            }
        }

        private static char GetDirection(List<char> moves) //get the first move from first list and then remove it from the list
        {
            char move = moves.ElementAt(0);
            moves.RemoveAt(0);
            return move;
        }
    }
}
