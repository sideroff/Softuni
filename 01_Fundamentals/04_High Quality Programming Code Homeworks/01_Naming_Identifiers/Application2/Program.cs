using System;
using System.Collections.Generic;

namespace _03.CustomMinesweeper
{
    public class Minesweeper
    {
        public class HighScore
        {
            private string name;

            private int points;

            public string player
            {
                get{return name;}
                set{name = value;}
            }

            public int Points
            {
                get{return points;}
                set{points = value;}
            }

            public HighScore()
            {
            }

            public HighScore(string name, int points)
            {
                this.name = name;
                this.points = points;
            }
        }

        private static void Main()
        {
            string command = string.Empty;
            char[,] field = createField();
            char[,] bombs = placeBombs();
            List<HighScore> champions = new List<HighScore>(6);
            int counter = 0;
            bool boom = false;

            int row = 0;
            int col = 0;

            bool flag = true;
            bool flag2 = false;

            const int max = 35;

            do
            {
                if (flag)
                {
                    Console.WriteLine(
                        "Lets play Minesweeper. Try and find all mines."
                        + " 'top' shows Highscores, 'restart' restarts the game, 'exit' terminates the game");
                    printField(field);
                    flag = false;
                }

                Console.Write("Awaiting row and col input : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out col)
                        && row <= field.GetLength(0) && col <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Rating(champions);
                        break;
                    case "restart":
                        field = createField();
                        bombs = placeBombs();
                        printField(field);
                        boom = false;
                        flag = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, bye!");
                        break;
                    case "turn":
                        if (bombs[row, col] != '*')
                        {
                            if (bombs[row, col] == '-')
                            {
                                Turn(field, bombs, row, col);
                                counter++;
                            }

                            if (max == counter)
                            {
                                flag2 = true;
                            }
                            else
                            {
                                printField(field);
                            }
                        }
                        else
                        {
                            boom = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nCommand not supported!\n");
                        break;
                }

                if (boom)
                {
                    printField(bombs);
                    Console.Write("\nYou died with {0} points. " + "Type your nickname please ", counter);
                    string nickname = Console.ReadLine();
                    HighScore table = new HighScore(nickname, counter);
                    if (champions.Count < 5)
                    {
                        champions.Add(table);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < table.Points)
                            {
                                champions.Insert(i, table);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((HighScore r1, HighScore r2) => r2.player.CompareTo(r1.player));
                    champions.Sort((HighScore r1, HighScore r2) => r2.Points.CompareTo(r1.Points));
                    Rating(champions);

                    field = createField();
                    bombs = placeBombs();
                    counter = 0;
                    boom = false;
                    flag = true;
                }

                if (flag2)
                {
                    Console.WriteLine("\nCongradulations, You found 35 cells with no missing hp.");
                    printField(bombs);
                    Console.WriteLine("Type your name please");
                    string name = Console.ReadLine();
                    HighScore points = new HighScore(name, counter);
                    champions.Add(points);
                    Rating(champions);
                    field = createField();
                    bombs = placeBombs();
                    counter = 0;
                    flag2 = false;
                    flag = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria");
            Console.WriteLine("Goodbye.");
            Console.Read();
        }

        private static void Rating(List<HighScore> highScores)
        {
            Console.WriteLine("\nPoints:");
            if (highScores.Count > 0)
            {
                for (int i = 0; i < highScores.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} Boxes", i + 1, highScores[i].player, highScores[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty!\n");
            }
        }

        private static void Turn(char[,] field, char[,] bombs, int row, int col)
        {
            char bombsCounter = countBombs(bombs, row, col);
            bombs[row, col] = bombsCounter;
            field[row, col] = bombsCounter;
        }

        private static void printField(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] createField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] placeBombs()
        {
            int rows = 5;
            int cols = 10;
            char[,] field = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    field[i, j] = '-';
                }
            }

            List<int> randoms = new List<int>();
            while (randoms.Count < 15)
            {
                Random random = new Random();
                int rnd = random.Next(50);
                if (!randoms.Contains(rnd))
                {
                    randoms.Add(rnd);
                }
            }

            foreach (int integer in randoms)
            {
                int col = integer / cols;
                int row = integer % cols;
                if (row == 0 && integer != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                field[col, row - 1] = '*';
            }

            return field;
        }

        private static void Calculation(char[,] field)
        {
            int row = field.GetLength(1);
            int col = field.GetLength(0);

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (field[i, j] != '*')
                    {
                        char bombsCount = countBombs(field, i, j);
                        field[i, j] = bombsCount;
                    }
                }
            }
        }

        private static char countBombs(char[,] field, int first, int second)
        {
            int count = 0;
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            if (first - 1 >= 0)
            {
                if (field[first - 1, second] == '*')
                {
                    count++;
                }
            }

            if (first + 1 < rows)
            {
                if (field[first + 1, second] == '*')
                {
                    count++;
                }
            }

            if (second - 1 >= 0)
            {
                if (field[first, second - 1] == '*')
                {
                    count++;
                }
            }

            if (second + 1 < cols)
            {
                if (field[first, second + 1] == '*')
                {
                    count++;
                }
            }

            if ((first - 1 >= 0) && (second - 1 >= 0))
            {
                if (field[first - 1, second - 1] == '*')
                {
                    count++;
                }
            }

            if ((first - 1 >= 0) && (second + 1 < cols))
            {
                if (field[first - 1, second + 1] == '*')
                {
                    count++;
                }
            }

            if ((first + 1 < rows) && (second - 1 >= 0))
            {
                if (field[first + 1, second - 1] == '*')
                {
                    count++;
                }
            }

            if ((first + 1 < rows) && (second + 1 < cols))
            {
                if (field[first + 1, second + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}