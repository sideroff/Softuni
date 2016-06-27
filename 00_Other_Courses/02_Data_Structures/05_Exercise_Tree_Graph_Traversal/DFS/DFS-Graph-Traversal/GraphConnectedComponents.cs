using System;
using System.Collections.Generic;
using System.Linq;

public class GraphConnectedComponents
{
    private static new List<int>[] graph;

    private static bool[] visited;

    public static void Main()
    {
        graph = ReadGraph();

        FindAllConnectedComponents();
    }

    static void DFS(int node)
    {
        if (!visited[node])
        {
            visited[node] = true;
            foreach (var child in graph[node])
            {
                DFS(child);
            }
            Console.Write(" " + node);
        }
    }

    static List<int>[] ReadGraph()
    {
        int n = int.Parse(Console.ReadLine());
        List<int>[] newGraph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            List<int> newNode = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            newGraph[i] = newNode;

        }
        return newGraph;
    }
    static void FindAllConnectedComponents()
    {
        visited = new bool[graph.Length];
        for (int i = 0; i < graph.Length; i++)
        {
            if (!visited[i])
            {
                Console.Write("Connected component:");
                DFS(i);
                Console.WriteLine();
            }

        }
    }
}
