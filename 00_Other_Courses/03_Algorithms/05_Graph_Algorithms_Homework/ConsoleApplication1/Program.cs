using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            Console.ReadLine();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Distances to find:")
                {
                    break;
                }
                string[] input = command
                    .Split(new char[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                // init node
                int node = int.Parse(input[0].Trim());
                graph[node] = new List<int>();
                if (input.Length > 1)
                {
                    // init others as children and nodes
                    int[] children =
                        input[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
                    foreach (var child in children)
                    {
                        graph[node].Add(child);
                        if (!graph.ContainsKey(child))
                        {
                            graph[child] = new List<int>();
                        }
                    }
                }
            }

            while (true)
            {
                string findDistanceCommand = Console.ReadLine();
                if (string.IsNullOrEmpty(findDistanceCommand))
                {
                    break;
                }
                int[] nodes = findDistanceCommand
                                .Split('-')
                                .Select(int.Parse)
                                .ToArray();

                // algorithm works with distance between 2 elements 
                if (nodes.Length != 2)
                {
                    break;
                }
                Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
                HashSet<int> visited = new HashSet<int>();
                queue.Enqueue(new Tuple<int, int>(nodes[0], 0));
                bool hasFoundSolution = false;
                {
                    while (queue.Count != 0)
                    {

                        Tuple<int, int> current = queue.Dequeue();
                        if (visited.Contains(current.Item1))
                        {
                            continue;
                        }

                        visited.Add(current.Item1);

                        if (current.Item1 == nodes[1])
                        {
                            Console.WriteLine($"{{{nodes[0]} - {nodes[1]}}} -> {current.Item2} ");
                            hasFoundSolution = true;
                            break;
                        }
                        foreach (var child in graph[current.Item1])
                        {
                            queue.Enqueue(new Tuple<int, int>(child, current.Item2 + 1));
                        }

                    }
                }
                if (!hasFoundSolution)
                {
                    Console.WriteLine($"{{{nodes[0]} - {nodes[1]}}} -> -1");
                }

            }
        }
    }
}
