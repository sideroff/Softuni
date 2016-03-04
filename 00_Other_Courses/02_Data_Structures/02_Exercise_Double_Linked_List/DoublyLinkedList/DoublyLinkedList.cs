using System;
using System.Collections;
using System.Collections.Generic;

using Double_Linked_List;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    public int Count { get; private set; }

    private ListNode<T> Head { get; set;}

    private ListNode<T> Tail { get; set;}

    public void AddFirst(T element)
    {
        var currentFirst = this.Head;
        if (this.Count == 0)
        {
            this.Head = this.Tail = new ListNode<T>(element);
        }
        else
        {
            var currentHead = this.Head;
            this.Head = new ListNode<T>(element);
            this.Head.NextNode = currentHead;
            currentHead.PrevNode = this.Head;
        }
        this.Count++;
    }

    public void AddLast(T element)
    {
        if (this.Count == 0)
        {
            this.Head = this.Tail = new ListNode<T>(element);
        }
        else
        {
            var currentTail = this.Tail;
            this.Tail = new ListNode<T>(element);
            this.Tail.PrevNode = currentTail;
            currentTail.NextNode = this.Tail;
        }
        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("No elements found!");
        }
        var element = this.Head.Value;
        this.Head = this.Head.NextNode;
        if (this.Head != null)
        {
            this.Head.PrevNode = null;
        }
        else
        {
            this.Tail = null;
        }
        this.Count--;
        return element;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("No elements found!");
        }
        var element = this.Tail.Value;
        this.Tail = this.Tail.PrevNode;
        if (this.Tail != null)
        {
            this.Tail.NextNode = null;
        }
        else
        {
            this.Head = null;
        }
        this.Count--;
        return element;
    }

    public void ForEach(Action<T> action)
    {
        var currentNode = this.Head;
        while (currentNode != null)
        {
            action(currentNode.Value);
            currentNode = currentNode.NextNode;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = this.Head;
        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        var array = new T[this.Count];
        var currentNode = this.Head;
        for (int i = 0; i < this.Count; i++)
        {
            array[i] = currentNode.Value;
            currentNode = currentNode.NextNode;
        }

        return array;
    }
}