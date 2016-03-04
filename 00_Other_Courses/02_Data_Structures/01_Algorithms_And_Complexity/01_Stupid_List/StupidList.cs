namespace _01_Stupid_List
{
    using System;

    public class StupidList<T>
    {
        private T[] arr = new T[0];

        //Complexity O(1)
        public int Length
        {
            get
            {
                return this.arr.Length;
            }
        }

        //Complexity O(1)
        public T this[int index]
        {
            get
            {
                return this.arr[index];
            }
        }

        //Complexity O(1)
        public T First
        {
            get
            {
                return this.arr[0];
            }
        }

        //Complexity O(1)
        public T Last
        {
            get
            {
                return this.arr[this.arr.Length - 1];
            }
        }

        //Complexity O(n)
        public void Add(T item)
        {
            var newArr = new T[this.arr.Length + 1];
            Array.Copy(this.arr, newArr, this.arr.Length);
            newArr[newArr.Length - 1] = item;
            this.arr = newArr;
        }

        //Complexity O(n) - for best, average and worst case scenario
        public T Remove(int index)
        {
            T result = this.arr[index];
            var newArr = new T[this.arr.Length - 1];
            Array.Copy(this.arr, newArr, index);
            Array.Copy(this.arr, index + 1, newArr, index, this.arr.Length - index - 1);
            this.arr = newArr;
            return result;
        }

        //Complexity O(n)
        public T RemoveFirst()
        {
            return this.Remove(0);
        }

        //Complexity O(n)
        public T RemoveLast()
        {
            return this.Remove(this.Length - 1);
        }
    }
}

