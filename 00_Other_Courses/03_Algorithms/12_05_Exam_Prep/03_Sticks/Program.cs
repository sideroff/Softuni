using System;
using System.Collections.Generic;

namespace TSUsingSourceDFS
{
    using System.Linq;

    public class DFSTS
    {
        public static void Main()
        {
            int numberOfNodes = int.Parse(Console.ReadLine());
            List<int>[] graph = new List<int>[numberOfNodes];
            for (var i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }
            int numberOfSticksOnTop = int.Parse(Console.ReadLine());
            for (var i = 0; i < numberOfSticksOnTop; i++)
            {
                int[] sticks = Console.ReadLine().Split().Select(int.Parse).ToArray();
                graph[sticks[0]].Add(sticks[1]);
            }
            // Calculate the predecessorsCount
            var predecessorsCount = new int[graph.Length];
            for (int node = 0; node < graph.Length; node++)
            {
                foreach (var childNode in graph[node])
                {
                    predecessorsCount[childNode]++;
                }
            }

            // Topological sorting: source removal algorithm
            var isRemoved = new bool[graph.Length];
            var removedNodes = new List<int>();
            bool nodeRemoved = true;
            while (nodeRemoved)
            {
                nodeRemoved = false;
                for (int node = graph.Length-1; node >=0;node--)
                {
                    if (predecessorsCount[node] == 0 && !isRemoved[node])
                    {
                        // Found a node with 0 predecessors -> remove it from the graph

                        foreach (var childNode in graph[node])
                        {
                            predecessorsCount[childNode]--;
                        }
                        isRemoved[node] = true;
                        removedNodes.Add(node);
                        nodeRemoved = true;
                        break;
                    }
                }
            }

            if (removedNodes.Count == graph.Length)
            {
                Console.WriteLine(string.Join(" ", removedNodes));
            }
            else
            {
                Console.WriteLine($"Cannot lift all sticks{Environment.NewLine}{string.Join(" ",removedNodes)}");
            }

        }
    }
}
