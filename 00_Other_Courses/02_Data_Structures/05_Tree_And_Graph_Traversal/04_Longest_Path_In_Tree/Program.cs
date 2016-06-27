namespace _04_Longest_Path_In_Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _02_Round_Dance;

    class Program
    {
        private static Dictionary<int, Node> tree;
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());
            tree = ReadTree(nodes, edges);
            var root = GetRoot(tree);
            long sum = DFS_Biggest_Sum_of_Children(root);
            Console.WriteLine($"Largest sum from leaf to leaf passing through the root is: {sum}");
        }

        static Node GetRoot(Dictionary<int, Node> tree)
        {
            var rootKVP = tree.FirstOrDefault(n => n.Value.Parent == null);
            return rootKVP.Value;
        }
        static int DFS_Find_Biggest_Sum_For_Children(Node currentNode)
        {
            int sum = 0;
            foreach (Node child in currentNode.Children)
            {
                int childSum = DFS_Find_Biggest_Sum_For_Children(child);
                if (childSum > sum)
                {
                    sum = childSum;
                }
            }
            sum += currentNode.Value;
            return sum;
        }
        static long DFS_Biggest_Sum_of_Children(Node currentNode)
        {
            List<long> sums = new List<long>();
            sums.Add(0);
            sums.Add(0);
            foreach (Node child in currentNode.Children)
            {
                bool hasSorted = false;
                int sumOfChild = DFS_Find_Biggest_Sum_For_Children(child);
                if (sums.Count < 2)
                {
                    sums.Add(sumOfChild);
                }
                else
                {
                    if (!hasSorted)
                    {
                        sums.Sort();
                        hasSorted = true;
                    }
                    if (sums[1] < sumOfChild)
                    {
                        if (sums[0] < sumOfChild)
                        {
                            sums[0] = sumOfChild;
                        }
                        else
                        {
                            sums[1] = sumOfChild;
                        }
                    }
                }
                
            }
            return sums[0] + sums[1] + currentNode.Value;
        }

        static Dictionary<int, Node> ReadTree(int nodes, int edges)
        {
            Dictionary<int, Node> newTree = new Dictionary<int, Node>();

            for (int i = 0; i < edges; i++)
            {
                int[] splitted = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int nodeNumber = splitted[0];

                if (!newTree.ContainsKey(nodeNumber))
                {
                    newTree[nodeNumber] = new Node(nodeNumber);
                }
                foreach (int j in splitted.Skip(1))
                {
                    if (!newTree.ContainsKey(j))
                    {
                        newTree[j] = new Node(j);
                    }
                    newTree[nodeNumber].Children.Add(newTree[j]);
                    newTree[j].Parent = newTree[nodeNumber];
                }
            }
            return newTree;
        }
    }
}

