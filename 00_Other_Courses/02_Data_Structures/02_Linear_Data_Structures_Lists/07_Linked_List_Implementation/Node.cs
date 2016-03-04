namespace _07_Linked_List_Implementation
{
    using System.Collections;
    using System.Collections.Generic;

    public class Node<T>
    {
        public T Value { get; set; }

        public Node<T> Next { get; set; }

        public Node(T value)
        {
            this.Value = value;
        }
    }
}