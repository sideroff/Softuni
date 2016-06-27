using System;
using System.Runtime.CompilerServices;

public class CircularQueue<T>
{
    private const int DefaultCapacity = 16;
    private T[] elements;
    private int head;
    private int tail;
    public int Count { get; private set; }

    public CircularQueue(int capacity = DefaultCapacity)
    {
        this.elements = new T[capacity];
        this.head = 0;
        this.tail = 0;
    }
   
    public void Enqueue(T element)
    {
        this.TryResizeUp();
        this.elements[this.tail] = element;
        this.tail = (this.tail + 1) % this.elements.Length;
        this.Count++;
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("There are no elements in the queue.");
        }

        var result = this.elements[this.head];
        this.head = (this.head + 1) % this.elements.Length;
        this.Count--;
        return result;
    }

    public T[] ToArray()
    {
        T[] newArray = this.Resize(this.Count);
        return newArray;
    }

    private T[] Resize(int capacity)
    {
        T[] newArray = new T[capacity];
        int sourceIndex = this.head;
        int destinationIndex = 0;
        for (int i = 0; i < this.Count; i++)
        {
            newArray[destinationIndex] = this.elements[sourceIndex];
            sourceIndex = (sourceIndex + 1) % this.elements.Length;
            destinationIndex++;
        }
        this.head = 0;
        this.tail = this.Count;
        return newArray;
    }

    private void TryResizeUp()
    {
        if (this.Count >= this.elements.Length)
        {
            var result = this.Resize(this.Count * 2);
            this.elements = result;
        }
    }
}
