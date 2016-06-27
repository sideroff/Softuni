using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Tree_Builder_And_Traverser
{
    class Program
    {
        public static Tree<int> GetTreeNodeByValue(int value)
        {
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new Tree<int>(value);
            }
            return nodeByValue[value];

        }
        static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();
        static void Main(string[] args)
        {

            int numberOfNodes = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfNodes; i++)
            {
                string[] edge = Console.ReadLine().Split();
                int parentValue = int.Parse(edge[0]);
                Tree<int> parentNode = GetTreeNodeByValue(parentValue);
                int childValue = int.Parse(edge[1]);
                Tree<int> childNode = GetTreeNodeByValue(childValue);
                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;
            }
            int pathSum = int.Parse(Console.ReadLine());
            int subTreeSum = int.Parse(Console.ReadLine());
            
        }

        static Tree<int> FindTreeRootNode(int value)
        {
            var root = nodeByValue.Values.FirstOrDefault(t => t.Parent == null);
            return root;
        }

        static IEnumerable<Tree<int>> FindMiddleTrees()
        {
            var middleTrees = nodeByValue.Values.Where(t => t.Parent != null && t.Children.Count == 0);
            return middleTrees;
        } 

        
    }
}
