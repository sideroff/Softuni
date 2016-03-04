namespace _06_Reversed_List_Implementation
{
    using System;
    using System.Collections;

    public class ReversedList<T> : IEnumerable
    {
        private const int DefaultCapacity = 16;
        private T[] elements;
        private int count;
        private int capacity;

        public int Count
        {
            get
            {
                return this.count;
            }
            set
            {
                this.count = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        public ReversedList(int capacity = 16)
        {
            this.count = 0;
            this.capacity = capacity;
            this.elements = new T[this.capacity];
        }

        public T this[int index]
        {
            get
            {
                int reversedPosition = this.count - index - 1;
                if (reversedPosition < 0 || reversedPosition >= this.count)
                {
                    throw new InvalidOperationException("Element with such index not found!");
                }
                return this.elements[reversedPosition];
            }
        }

        public void Add(T element)
        {
            this.TryResizeUp();

            this.elements[this.count] = element;

            this.count++;
        }

        /// <summary>
        /// Removes the first instance of the element provided in the list.
        /// </summary>
        /// <param name="element">Element to be removed/</param>
        public void Remove(T element)
        {
            for (int i = 0; i < this.count; i++)
            {
                if (this.elements[i].Equals(element))
                {

                    for (int j = i; j < this.count - 1; j++)
                    {
                        this.elements[j] = this.elements[j + 1];
                    }

                    this.count--;
                    this.elements[this.count] = default(T);
                    this.TryResizeDown();
                    break;
                }
            }
        }

        public void RemoveAt(int index)
        {
            T elementForRemoval = this[index];
            this.Remove(elementForRemoval);
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < this.count; i++)
            {
                yield return this[i];
            }
        }

        private void TryResizeUp()
        {
            if (this.count == this.capacity)
            {
                T[] newArray = new T[this.capacity * 2];
                for (int i = 0; i < this.count; i++)
                {
                    newArray[i] = this.elements[i];
                }
                this.elements = newArray;
                this.capacity *= 2;
            }
        }

        private void TryResizeDown()
        {
            if ((this.count == (this.capacity / 2) - 1) && this.capacity > DefaultCapacity)
            {
                T[] newArray = new T[this.capacity / 2];
                for (int i = 0; i < this.count; i++)
                {
                    newArray[i] = this.elements[i];
                }

                this.elements = newArray;
                this.capacity /= 2;
            }
        }

        
    }
}