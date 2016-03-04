namespace _04_LinkedStack_Implementation
{
    public class StackNode<T>
    {
        public T Value { get; set; }
        public StackNode<T> PreviousNode { get; set; }

        public StackNode(T value = default(T), StackNode<T> PreviousNode = null)
        {
            this.Value = value;
            this.PreviousNode = PreviousNode;
        }
    }
}