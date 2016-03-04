namespace _07_Linked_List_Implementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CustomLinkedList<T> : IEnumerable<T>
    {
        public Node<T> Head{ get; set; }

        public Node<T> Tail{ get; set; }

        public int Count { get; private set; }

        public CustomLinkedList()
        {
            this.Head = this.Tail = null;
            this.Count = 0;
        }

        public Node<T> Add(T element)
        {
            Node<T> newNode = new Node<T>(element);
            if (this.Count < 1)
            {
                this.Head = this.Tail = newNode;
                this.Head.Next = this.Tail;
            }
            else
            {
                this.Tail.Next = newNode;
                this.Tail = newNode;
            }
            this.Count++;

            return newNode;

        }

        public void AddAfter(Node<T> specifiedNode, T element)
        {
            Node<T> newNode = new Node<T>(element);
            if (specifiedNode.Next == null)
            {
                specifiedNode.Next = newNode;
            }
            else
            {
                var swap = specifiedNode.Next;
                specifiedNode.Next = newNode;
                newNode.Next = swap;
            }
        }

        public void ForEach(Action<T> action)
        {
            var currentNode = this.Head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                if (currentNode.Next == null)
                {
                    break;
                }
                currentNode = currentNode.Next;
            }
        }

        public int FirstIndexOf(T element)
        {
            int index = 0;
            bool hasFound = false;
            foreach (var i in this)
            {
                if (i.Equals(element))
                {
                    hasFound = true;
                    break;
                }
                index++;
            }
            if (hasFound)
            {
                return index;
            }
            else
            {
                return -1;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.Head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                if (currentNode.Next == null)
                {
                    break;
                }
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}