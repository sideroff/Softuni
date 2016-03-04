namespace _05_LinkedQueue_Implementation
{
    using System.Net.NetworkInformation;

    public class Node<T>
    {
        public T Value { get; set; }

        public Node<T> NextNode { get; set; }

        public Node<T> PrevNode { get; set; }

        public Node(T value)
        {
            this.Value = value;
        }
    }
}