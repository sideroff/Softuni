using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Tower_Of_Hanoi
{
    class Program
    {
        private static Stack<int> source;
        private static Stack<int> spare;
        private static Stack<int> destination;
        private static int steps = 0;

        static void Main()
        {
            int numberOfDisks = int.Parse(Console.ReadLine());
            source = new Stack<int>(Enumerable.Range(1, numberOfDisks).Reverse());
            spare = new Stack<int>();
            destination = new Stack<int>();

            MoveDisks(numberOfDisks, source, spare, destination);
        }

        private static void MoveDisks(
            int disksToMove,
            Stack<int> source,
            Stack<int> spare,
            Stack<int> destination)
        {
            if (disksToMove == 1)
            {
                steps++;
                Console.WriteLine($"Step №{steps}");
                destination.Push(source.Pop());
                PrintPegs();
            }
            else
            {
                MoveDisks(disksToMove - 1, source, destination, spare);
                MoveDisks(1, source, spare, destination);
                MoveDisks(disksToMove - 1, spare, source, destination);
            }
        }

        private static void PrintPegs()
        {
            Console.WriteLine($"Source: {string.Join(" ", source.Reverse())}");
            Console.WriteLine($"Spare: {string.Join(" ", spare.Reverse())}");
            Console.WriteLine($"Destination: {string.Join(" ", destination.Reverse())}");
            Console.WriteLine();
        }
    }

}
