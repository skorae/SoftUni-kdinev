using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LinkedQueue<T>
{
    private QueueNode<T> head;
    private QueueNode<T> tail;

    public int Count { get; private set; }

    public void Enqueue(T element)
    {
        switch (this.Count)
        {
            case 0:
                this.head = this.tail = new QueueNode<T>(element);
                break;
            case 1:
                this.tail = new QueueNode<T>(element, this.head);
                this.head.NextNode = this.tail;
                break;
            default:
                this.tail.NextNode = new QueueNode<T>(element, this.tail);
                this.tail = this.tail.NextNode;
                break;
        }

        this.Count++;
    }

    public T Dequeue()
    {
        T result;

        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }
        else if (this.Count == 1)
        {
            result = this.head.Value;
            this.head = this.tail = null;
        }
        else
        {
            result = this.head.Value;
            this.head = this.head.NextNode;
        }

        return result;
    }

    public T[] ToArray()
    {
        var currentNode = this.head;
        var result = new T[this.Count];

        for (int i = 0; i < this.Count; i++)
        {
            result[i] = currentNode.Value;
            currentNode = currentNode.NextNode;
        }

        return result;
    }

}
