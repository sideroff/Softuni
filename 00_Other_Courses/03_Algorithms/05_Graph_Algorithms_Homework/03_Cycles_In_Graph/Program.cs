namespace _03_Cycles_In_Graph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        static Dictionary<string, int> predecesorsCount = new Dictionary<string, int>();
        static HashSet<string> visited = new HashSet<string>();

        static void Main()
        {
            while (true)
            {
                string command = Console.ReadLine();
                if (string.IsNullOrEmpty(command))
                {
                    break;
                }
                string[] input = command.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                string vertex = input[0].Trim();
                string vertex2 = input[1].Trim();
                if (!graph.ContainsKey(vertex))
                {
                    graph[vertex] = new List<string>();
                }
                if (!graph.ContainsKey(vertex2))
                {
                    graph[vertex2] = new List<string>();
                }
                graph[vertex].Add(vertex2);
                graph[vertex2].Add(vertex);
            }
            var randomNode = graph.First().Key;
            Console.WriteLine($"Is Acyclic: {!TraverseGraph(randomNode)}");
        }

        private static bool TraverseGraph(string node, string comingFrom = "")
        {
            if (visited.Contains(node))
            {
                return true;
            }
            visited.Add(node);
            graph[node].Remove(comingFrom);
            foreach (var neighbour in graph[node])
            {
                if (TraverseGraph(neighbour, node))
                {
                    return true;
                }
            }
            return false;

        }

    }
}



