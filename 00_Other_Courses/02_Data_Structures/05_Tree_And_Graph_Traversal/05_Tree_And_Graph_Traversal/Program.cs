using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Tree_And_Graph_Traversal
{

    class Program
    {
        static void Main()
        {

            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            List<int>[] graph = ReadGraph(n,m);

            TraverseGraph(graph,n);
        }

        static List<int>[] ReadGraph(int n, int m)
        {
            List<int>[] newGraph = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                newGraph[i] = new List<int>();
            }

            for (int i = 0; i < m; i++)
            {
                List<int> splitted = Console.ReadLine().Split().Select(int.Parse).ToList();
                if (!splitted.Any())
                {
                    i--;
                    continue;
                }
                int index = splitted[0];

                for (int j = 1; j < splitted.Count; j++)
                {
                    newGraph[index].Add(splitted[j]);
                }

            }

            return newGraph;
        }

        static void TraverseGraph(List<int>[] newGraph, int n)
        {
            Dictionary<int, int> indexTimesRefferenced = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                indexTimesRefferenced[i] = 0;
            }
            bool[] hasVisited = new bool[newGraph.Length];
            for (int i = 0; i < newGraph.Length; i++)
            {
                if (!hasVisited[i])
                {
                    hasVisited[i] = true;
                    for (int j = 0; j < newGraph[i].Count; j++)
                    {
                        indexTimesRefferenced[newGraph[i][j]] += 1;
                    }
                }
            }

            var zeroReferencedTimes = indexTimesRefferenced.Where(kvp => kvp.Value == 0).ToList();
            var allOthersAre1 = indexTimesRefferenced.Where(kvp => kvp.Value == 1).ToList();

            int sum = 0;
            foreach (var keyValuePair in indexTimesRefferenced)
            {
                sum += keyValuePair.Value;
            }
            if (zeroReferencedTimes.Count() == 1 && allOthersAre1.Count()
                == indexTimesRefferenced.Count - 1)
            {
                Console.WriteLine($"The graph is a tree holding {indexTimesRefferenced.Count} nodes ({0}...{indexTimesRefferenced.Count-1}) and {sum} edges. The root node is {zeroReferencedTimes.First(t=>t.Value==0).Key}.");
            }
            else if (zeroReferencedTimes.Count() > 1
                     && allOthersAre1.Count() < indexTimesRefferenced.Count - 1)
            {
                Console.WriteLine(
                    $"The graph is not a tree (it is a forest). The graph has {indexTimesRefferenced.Count} nodes ({0}...{indexTimesRefferenced.Count - 1}) and {sum} edges. There are several trees in the forest and their roots are: {string.Join(", ", zeroReferencedTimes)}.");
            }
            else if (zeroReferencedTimes.Count == 0)
            {
                Console.WriteLine($"The graph is not a tree (all nodes have parents). The graph has {indexTimesRefferenced.Count} nodes ({0}...{indexTimesRefferenced.Count - 1}) and {sum} edges.");
            }
            
        }
    }
}
