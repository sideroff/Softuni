namespace _03_ArrayStack_Implementation
{
    public class ArrayStack<T>
    {
        private T[] elements;
        public int Count { get; private set; }
        private const int InitialCapacity = 16;

        public ArrayStack(int capacity = InitialCapacity)
        {
            this.elements = new T[capacity];
            this.Count = 0;
        }

        public void Push(T element)
        {
            this.TryResizeUp();
            this.elements[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            var result = this.elements[this.Count-1];
            this.elements[this.Count-1] = default(T);
            this.Count--;
            this.TryResizeDown();

            return result;
        }

        public T[] ToArray()
        {
            var array = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                array[i] = this.elements[i];
            }

            return array;
        }

        private void TryResizeUp()
        {
            if (this.Count >= this.elements.Length)
            {
                this.Resize(this.elements.Length*2);
            }
        }

        private void TryResizeDown()
        {
            if (this.Count <= this.elements.Length * 25 / 100.0)
            {
                this.Resize(this.elements.Length/2);
            }
        }
        private void Resize(int newCapacity)
        {
            var newArray = new T[newCapacity];
            for (int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.elements[i];
            }
            this.elements = newArray;
        }
    }

}