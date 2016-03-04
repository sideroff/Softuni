namespace _04_LinkedStack_Implementation
{
    using System;
    using System.IO;

    public class LinkedStack<T>
    {
        public int Count { get; private set; }

        public StackNode<T> Top { get; set; }

        public LinkedStack()
        {
        }
        public void Push(T element)
        {
            var newTop = new StackNode<T>(element);
            newTop.PreviousNode = this.Top;
            this.Top = newTop;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }
            var elementValue = this.Top.Value;
            this.Top = this.Top.PreviousNode;
            this.Count--;

            return elementValue;
        }
    }
}