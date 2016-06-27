using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Round_Dance
{
    using System.Runtime.CompilerServices;

    class Program
    {
        static void Main(string[] args)
        {
            int edges = int.Parse(Console.ReadLine());
            int startRoot = int.Parse(Console.ReadLine());

            Dictionary<int, Node> graph = ReadGraph(edges);

            Console.WriteLine(DFS_Find_Deepest_Hole(graph[startRoot], 0));

            //root values must be unique
        }
        static Dictionary<int, bool> hasVisited = new Dictionary<int, bool>();
        static int DFS_Find_Deepest_Hole(Node node, int currentLenght)
        {
            int longestPath = currentLenght;
            hasVisited[node.Value] = true;
            if (node.Children.Any())
            {
                foreach (var child in node.Children)
                {
                    if (!hasVisited.ContainsKey(child.Value))
                    {
                        hasVisited[child.Value] = false;
                    }
                    if (!hasVisited[child.Value])
                    {
                        int newLenght = DFS_Find_Deepest_Hole(child, currentLenght+1);
                        if (longestPath < newLenght)
                        {
                            longestPath = newLenght;
                        }
                    }
                }
            }
            return longestPath;
        }

        static Dictionary<int, Node> ReadGraph(int edges)
        {
            Dictionary<int, Node> dict = new Dictionary<int, Node>();

            for (int i = 0; i < edges; i++)
            {
                int[] splitted = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (!splitted.Any())
                {
                    i--;
                }
                foreach (var j in splitted)
                {
                    if (!dict.ContainsKey(j))
                    {
                        dict[j] = new Node(j);
                    }
                }
                dict[splitted[0]].Children.Add(dict[splitted[1]]);
                dict[splitted[1]].Children.Add(dict[splitted[0]]);
            }
            return dict;
        }
    }
}
