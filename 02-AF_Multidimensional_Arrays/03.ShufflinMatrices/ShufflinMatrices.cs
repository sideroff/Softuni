using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ShufflinMatrices
{
    class ShufflinMatrices
    {
        static int[,] matrix;
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            matrix = new int[dimensions[0], dimensions[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            string[] command = Console.ReadLine().Split();
            while (!((command[0] != "swap") || (command[0] != "END")))
            {
                Console.WriteLine("Please enter a correct command.");
                command = Console.ReadLine().Split();
            }
            ExecuteCommand(command);
        }
        static void ExecuteCommand(string[] command)
        {
            if (command[0] == "swap")
            {
                int x1 = int.Parse(command[1]);
                int x2 = int.Parse(command[2]);
                int y1 = int.Parse(command[3]);
                int y2 = int.Parse(command[4]);
                int swap = matrix[x1, y1];
                matrix[x1, y1] = matrix[x2, y2];
                matrix[x2, y2] = swap;
                Console.WriteLine("Awaiting input:");
                command = Console.ReadLine().Split();
                ExecuteCommand(command);
            }
            if (command[0] == "END")
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int k = 0; k < matrix.GetLength(1); k++)
                    {
                        Console.Write(matrix[i, k]);
                    }
                    Console.WriteLine();
                }
            }
        }

    }
}
