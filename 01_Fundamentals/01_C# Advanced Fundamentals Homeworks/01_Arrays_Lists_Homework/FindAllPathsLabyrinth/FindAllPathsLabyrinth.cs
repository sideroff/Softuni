//this program navigates through a labyrinth and finds all possible paths
//this is not a part of my homework

using System;
using System.Collections.Generic;

namespace FindAllPathsLabyrinth
{
    class FindAllPathsLabyrinth
    {
        static List<char> moves = new List<char>();
        static char[,] maze =  { { ' ', ' ', ' ', ' ', 'x', ' ', ' ', ' ' },
                               {'x', 'x', 'x', ' ', 'x', ' ', 'x', ' '},
                               {' ', ' ', ' ', ' ', 'x', ' ', 'x', ' '},
                               {' ', 'x', 'x', 'x', 'x', ' ', 'x', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', 'x', ' '},
                               {' ', 'x', 'x', 'x', 'x', 'x', 'x', ' '},
                               {' ', 'x', ' ', ' ', ' ', 'x', 'x', ' '}, 
                               {' ', ' ', ' ', 'x', ' ', ' ', ' ', 'e', } };
        static void PathFinder(int row,int col)
        {
            if ((row < 0) || (col < 0) || (row >= maze.GetLength(0)) || (col >= maze.GetLength(1)))
            {
                //out of maze -> delete last move and return 
                moves.RemoveAt(moves.Count - 1);
                return;
            }
            if (maze[row, col] == 'e')
            {
                //current cell is exit -> print moves
                Console.WriteLine("Found the Exit! The path is: {0}", string.Join("", moves));
                
                moves.RemoveAt(moves.Count - 1); ;
                return;
            }
            if (maze[row,col]!=' ')
            {
                //current cell is not empty -> delete last move and return
                    moves.RemoveAt(moves.Count - 1);
                return;
            }

            maze[row, col] = 's';
            moves.Add('L');
            PathFinder(row, col - 1);
            moves.Add('U');
            PathFinder(row - 1, col);
            moves.Add('R');
            PathFinder(row, col + 1);
            moves.Add('D');
            PathFinder(row + 1, col);
            maze[row, col] = ' ';
            if(moves.Count!=0) moves.RemoveAt(moves.Count - 1);

            //Console.WriteLine(string.Join("", moves));    <uncomment if you want to see the pathFinder trace
                                                            //back on every exit of a recursion
        }
        static void Main(string[] args)
        {
            PathFinder(0, 0);
        }
    }
}
