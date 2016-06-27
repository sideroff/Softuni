using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Ride_The_Chess_Horse
{
    using System.Xml;

    class Program
    {
        private static int[,] field;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            field = new int[n, m];

            int hi;
            int hj;
            do
            {
                Console.WriteLine("Position of horse: ");
                hi = int.Parse(Console.ReadLine());
                hj = int.Parse(Console.ReadLine());

            }
            while (!checkIfInsideField(hi, hj));

            field[hi, hj] = 1;
            Point startingPoint = new Point(hi, hj);

            Queue<Point> queue = new Queue<Point>();

            queue.Enqueue(startingPoint);

            while (queue.Count > 0)
            {
                var currentPoint = queue.Dequeue();
                int i = currentPoint.I;
                int j = currentPoint.J;
                //up
                if (tryStepOnField(i - 2, j - 1))
                {
                    field[i - 2, j - 1] = field[i, j] + 1;
                    queue.Enqueue(new Point(i - 2, j - 1));
                }
                if (tryStepOnField(i - 2, j + 1))
                {
                    field[i - 2, j + 1] = field[i, j] + 1;
                    queue.Enqueue(new Point(i - 2, j + 1));
                }
                //right
                if (tryStepOnField(i - 1, j + 2))
                {
                    field[i - 1, j + 2] = field[i, j] + 1;
                    queue.Enqueue(new Point(i - 1, j + 2));
                }
                if (tryStepOnField(i + 1, j + 2))
                {
                    field[i + 1, j + 2] = field[i, j] + 1;
                    queue.Enqueue(new Point(i + 1, j + 2));
                }

                //down
                if (tryStepOnField(i + 2, j - 1))
                {
                    field[i + 2, j - 1] = field[i, j] + 1;
                    queue.Enqueue(new Point(i + 2, j - 1));
                }
                if (tryStepOnField(i + 2, j + 1))
                {
                    field[i + 2, j + 1] = field[i, j] + 1;
                    queue.Enqueue(new Point(i + 2, j + 1));
                }
                //left
                if (tryStepOnField(i - 1, j - 2))
                {
                    field[i - 1, j - 2] = field[i, j] + 1;
                    queue.Enqueue(new Point(i - 1, j - 2));
                }
                if (tryStepOnField(i + 1, j - 2))
                {
                    field[i + 1, j - 2] = field[i, j] + 1;
                    queue.Enqueue(new Point(i + 1, j - 2));
                }
            }
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i, j] + " ");
                }
                Console.WriteLine();
            }
        }


        static bool tryStepOnField(int i, int j)
        {
            if (checkIfInsideField(i, j))
            {
                if (field[i, j] == default(int))
                {
                    return true;
                }
            }
            return false;

        }

        static bool checkIfInsideField(int i, int j)
        {
            if (i >= 0 && i < field.GetLength(0) && j >= 0 && j < field.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}
