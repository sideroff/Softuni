namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using Sortable_Collection.Contracts;

    public class SortableCollection<T>
        where T : IComparable<T>
    {
        public SortableCollection()
        {
        }

        public SortableCollection(IEnumerable<int> items)
        {
            this.Items = new List<int>(items);
        }

        public SortableCollection(params int[] items)
            : this(items.AsEnumerable())
        {
        }

        public List<int> Items { get; } = new List<int>();

        public int Count => this.Items.Count;

        public void Sort(ISorter<int> sorter)
        {
            sorter.Sort(this.Items);
        }

        public int BinarySearch(T item)
        {
            if (this.Items == null || !this.Items.Any())
            {
                return -1;
            }
            return this.Binary(item, 0, this.Items.Count - 1);
        }

        public int InterpolationSearch(int item)
        {
            int index = this.Interpolation(item, 0, this.Items.Count - 1);
            return index;
        }

        public void Shuffle()
        {
            throw new NotImplementedException();
        }

        public int[] ToArray()
        {
            return this.Items.ToArray();
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", this.Items)}]";
        }

        public int Binary(T item, int start, int end)
        {
            if (this.Items[start].CompareTo(item) > 0 || this.Items[end].CompareTo(item) < 0)
            {
                return -1;
            }
            int middle = start + (end - start) / 2;
            if (this.Items[middle].CompareTo(item) == 0)
            {
                return middle;
            }
            if (this.Items[middle].CompareTo(item) > 0)
            {
                return this.Binary(item, start, middle);
            }
            else
            {
                return this.Binary(item, middle + 1, end);
            }

        }

        private int Interpolation(int item, int start, int end)
        {
            if (end < start)
            {
                return -1;
            }
            if (this.Items[start].CompareTo(item) > 0 || this.Items[end].CompareTo(item) < 0)
            {
                if (this.Items[start].Equals(item))
                {
                    return start;
                }

                return -1;
            }
            int mid = start
                      + ((item - this.Items[start]) * (end - start))
                      / (this.Items[end] - this.Items[start]);
            if (this.Items[mid] == item)
            {
                return mid;
            }
            if (this.Items[mid] > item)
            {
                return this.Interpolation(item, start, mid-1);
            }
            if (this.Items[mid] < item)
            {
                return this.Interpolation(item, mid+1, end);
            }
            return -1;
        }
    }
}