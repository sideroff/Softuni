namespace _02_Round_Dance
{
    using System.Collections.Generic;

    public class Node
    {
        public int Value { get; set; }

        public List<Node> Children { get; private set; }

        public Node(int value)
        {
            this.Value = value;
            this.Children = new List<Node>();
        }
    }
}