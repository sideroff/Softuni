namespace _04_OrderedSet_Implementation
{
    using System;
    public class Node<T> where T : IComparable<T>
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public Node<T> LeftNode { get; set; }

        public Node<T> RightNode { get; set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}