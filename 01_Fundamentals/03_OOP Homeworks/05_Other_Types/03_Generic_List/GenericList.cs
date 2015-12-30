using System;
using System.Text;

namespace _03_Generic_List
{
    public class GenericList<T> where T : IComparable
    {
        private const int DefaultSize = 4;

        private T[] array;
        private int capacity;
        private int index;

        public GenericList()
        {
            InitializeArray(DefaultSize);
        }

        public GenericList(int Capacity)
        {
            InitializeArray(Capacity);
        }

        public void InitializeArray(int capacity)
        {
            this.array = new T[capacity];
            this.capacity = capacity;
            this.index = 0;
        }

        public int GetElement(T element)
        {
            for (int i = 0; i < this.index; i++)
            {
                if (array[i].CompareTo(element) == 0)
                {
                    return i;
                }
            }
            return 0;
        }

        public T GetAt(int index)
        {
            if (IndexInRange(index))
            {
                return this.array[index];
            }
            throw new ArgumentOutOfRangeException("Index must be >=0 and < list.Size()");
        }

        public void PutAt(int index, T value)
        {
            this.ResizeArrayIfNeccessery();
            for (int i = this.index; i > index; i--)
            {
                array[i] = array[i - 1];
            }
            this.array[index] = value;
            this.index += 1;

        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.index; i++)
            {
                if (array[i].CompareTo(element) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < this.index; i++)
            {
                this.array[i] = array[i + 1];
            }
            this.index -= 1;
            this.ResizeArrayIfNeccessery();

        }

        public T Min()
        {
            T min = array[0];
            for (int i = 0; i < this.index; i++)
            {
                if (min.CompareTo(array[i]) == 1)
                {
                    min = array[i];
                }
            }
            return min;
        }

        public T Max()
        {
            T max = array[0];
            for (int i = 0; i < this.index; i++)
            {
                if (max.CompareTo(array[i]) == -1)
                {
                    max = array[i];
                }
            }
            return max;
        }

        public void Clear()
        {
            this.index = 0;
            this.array = new T[DefaultSize];
            this.capacity = DefaultSize;
        }

        private bool IndexInRange(int index)
        {
            if (index < 0 || index >= this.index)
            {
                return false;
            }
            return true;
        }

        public void Add(T element)
        {
            this.ResizeArrayIfNeccessery();
            this.array[index] = element;
            this.index += 1;
        }

        public void Remove()
        {
            this.index -= 1;
            this.ResizeArrayIfNeccessery();
        }

        private void ResizeArrayIfNeccessery()
        {
            if (this.index == this.capacity)
            {
                this.ResizeUpArray();
            }
            else if (this.index == this.capacity / 2 && this.capacity != DefaultSize)
            {
                this.ResizeDownArray();
            }
        }

        private void ResizeUpArray()
        {

            T[] tempArray = new T[this.capacity * 2];
            for (int i = 0; i < this.capacity; i++)
            {
                tempArray[i] = this.array[i];
            }
            this.array = tempArray;

            this.capacity *= 2;
        }

        private void ResizeDownArray()
        {
            T[] tempArray = new T[(this.capacity / 2)];
            for (int i = 0; i < this.index; i++)
            {
                tempArray[i] = this.array[i];
            }

            this.array = tempArray;
            this.capacity /= 2;
        }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("[");
            for (int i = 0; i < this.index - 1; i += 1)
            {
                sb.AppendFormat("{0}, ", array[i]);
            }
            if (this.index > 0)
            {
                sb.AppendFormat("{0}", array[this.index - 1]);
            }

            sb.AppendFormat("]");
            return sb.ToString();
        }

    }
}