namespace _05_LinkedQueue_Implementation
{
    using System;

    public class LinkedQueue<T>
    {
        public int Count { get; private set; }

        public Node<T> Head { get; private set; }

        public Node<T> Tail { get; private set; }


        public void Enqueue(T element)
        {

            var newNode = new Node<T>(element);
            if (this.Count==0)
            {
                this.Head = this.Tail = newNode;
            }
            else if (this.Count == 1)
            {
                this.Tail = newNode;
                this.Head.PrevNode = this.Tail;
                this.Tail.NextNode = this.Head;
            }
            else
            {
                newNode.NextNode = this.Tail;
                this.Tail.PrevNode = newNode;
                this.Tail = newNode;
            }
            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }
            var currentHead = this.Head;
            if (this.Count != 1)
            {
                this.Head = currentHead.PrevNode;
                this.Head.NextNode = null;
            }
            else
            {
                this.Head = this.Tail = null;
            }
            currentHead.PrevNode = null;
            Count--;
            return currentHead.Value;
        }
    }
}