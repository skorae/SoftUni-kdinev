using System;
using System.Collections;
using System.Collections.Generic;

public partial class LinkedList<T> : IEnumerable<T>
{
    private Node<T> tail;
    private Node<T> head;

    public int Count { get; private set; }

    public void AddFirst(T item)
    {
        var newHead = new Node<T>(item);

        switch (this.Count)
        {
            case 0:
                this.tail = this.head = newHead;
                break;
            case 1:
                this.head = newHead;
                this.head.Next = this.tail;
                this.tail.Previous = this.head;
                break;
            default:
                newHead.Next = this.head;
                this.head.Previous = newHead;
                this.head = newHead;
                break;
        }

        this.Count++;
    }

    public void AddLast(T item)
    {
        var newTail = new Node<T>(item);

        switch (this.Count)
        {
            case 0:
                this.head = this.tail = newTail;
                break;
            case 1:
                this.tail = newTail;
                this.tail.Previous = this.head;
                this.head.Next = newTail;
                break;
            default:
                newTail.Previous = this.tail;
                this.tail.Next = newTail;
                this.tail = newTail;
                break;
        }

        Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        var result = this.head.Value;

        if (this.Count == 1)
        {
            this.head = this.tail = null;
        }
        else
        {
            this.head = this.head.Next;
            this.head.Previous = null;
        }

        this.Count--;

        return result;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        var result = this.tail.Value;

        if (this.Count == 1)
        {
            this.head = this.tail = null;
        }
        else
        {
            this.tail = this.tail.Previous;
            this.tail.Next = null;
        }

        this.Count--;

        return result;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = this.head;
        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
