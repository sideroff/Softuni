using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Escape_from_Labyrinth;

public class EscapeFromLabyrinth
{
    private static char[,] field;
    private static Point startingPoint;
    public static void Main()
    {
        field = ReadLabytinth();

        Console.WriteLine(FindShortestPath());


    }

    private static char[,] ReadLabytinth()
    {
        int cols = int.Parse(Console.ReadLine());
        int rows = int.Parse(Console.ReadLine());
        char[,] array = new char[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            string input = Console.ReadLine();
            for (int j = 0; j < cols; j++)
            {
                array[i, j] = input[j];

                if (input[j] == 's')
                {
                    startingPoint = new Point(j, i);
                }
            }
        }
        return array;
    }

    private static string FindShortestPath()
    {
        if (startingPoint == null)
        {
            return "No exit!";
        }
        Queue<Point> queue = new Queue<Point>();
        queue.Enqueue(startingPoint);

        while (queue.Count > 0)
        {
            var currentPoint = queue.Dequeue();
            if (IsExit(currentPoint))
            {
                return TracePathBack(currentPoint);
            }
            TryDirection(queue, currentPoint, "U", 0, -1);
            TryDirection(queue, currentPoint, "R", 1, 0);
            TryDirection(queue, currentPoint, "D", 0, 1);
            TryDirection(queue, currentPoint, "L", -1, 0);
        }
        return "No exit!";

    }

    private static bool IsExit(Point point)
    {
        if (point.X == 0 || point.X == field.GetLength(1) - 1 ||
            point.Y == 0 || point.Y == field.GetLength(0) - 1)
        {
            return true;
        }
        return false;
    }

    private static string TracePathBack(Point point)
    {
        StringBuilder sb = new StringBuilder();

        if (point.PreviousPoint == null)
        {
            sb.Append("Start is at the exit.");
            return sb.ToString();
        }

        sb.Append("Shortest exit: ");
        Stack<string> stack = new Stack<string>();
        while (point.PreviousPoint != null)
        {
            stack.Push(point.Direction);
            point = point.PreviousPoint;
        }
        while (stack.Count > 0)
        {
            sb.Append(stack.Pop());
        }
        return sb.ToString();
    }

    private static void TryDirection(
        Queue<Point> queue,
        Point currentPoint,
        string direction,
        int deltaX,
        int deltaY)
    {
        int newX = currentPoint.X + deltaX;
        int newY = currentPoint.Y + deltaY;
        if (newX >= 0 && newY >= 0 && newX < field.GetLength(1) && newY < field.GetLength(0)
            && field[newY, newX] == '-')
        {
            field[newY, newX] = 's';
            Point nextPoint = new Point(newX, newY)
            {
                Direction = direction,
                PreviousPoint = currentPoint
            };
            queue.Enqueue(nextPoint);
        }
    }
}
