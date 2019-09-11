using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LinkedStack<T>
{
    private Node<T> firstNode;

    public int Count { get; private set; }

    public void Push(T element)
    {
        if (this.Count == 0)
        {
            this.firstNode = new Node<T>(element);
        }
        else
        {
            this.firstNode = new Node<T>(element, this.firstNode);
        }

        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        var result = this.firstNode.Value;

        this.firstNode = this.firstNode.NextNode;
        
        this.Count--;

        return result;
    }

    public T[] ToArray()
    {
        var nodeIterator = this.firstNode;
        var result = new T[this.Count];
        int index = 0;

        while (nodeIterator != null)
        {
            result[index++] = nodeIterator.Value;
            nodeIterator = nodeIterator.NextNode;
        }

        return result;
    }
}
