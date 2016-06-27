using System;
using System.Collections.Generic;
using System.Linq;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
    }

    public ICollection<string> TopSort()
    {
        Dictionary<string,int> predecesorCount = new Dictionary<string, int>();
        foreach (var node in this.graph)
        {
            if (!predecesorCount.ContainsKey(node.Key))
            {
                predecesorCount[node.Key] = 0;
            }
            foreach (var child in node.Value)
            {
                if (!predecesorCount.ContainsKey(child))
                {
                    predecesorCount[child] = 0;
                }
                predecesorCount[child]++;
            }
        }

        var removedNodes = new List<string>();
        
        while (true)
        {
            string nodeToRemove = this.graph.Keys.FirstOrDefault(n => predecesorCount[n] == 0);

            if (nodeToRemove == null)
            {
                break;
            }
            foreach (var child in this.graph[nodeToRemove])
            {
                predecesorCount[child]--;
            }
            this.graph.Remove(nodeToRemove);
            removedNodes.Add(nodeToRemove);

        }
        if (this.graph.Count > 0)
        {
            throw new InvalidOperationException("A cycle detected in the graph");
        }
        return removedNodes;
    }
}

