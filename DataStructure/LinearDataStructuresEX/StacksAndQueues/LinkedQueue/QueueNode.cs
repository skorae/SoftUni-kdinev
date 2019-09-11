using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class QueueNode<T>
{
    public QueueNode(T element, QueueNode<T> prevNode = null, QueueNode<T> nextNode = null)
    {
        this.Value = element;
        this.PrevNode = prevNode;
        this.NextNode = nextNode;
    }

    public T Value { get; private set; }

    public QueueNode<T> NextNode { get; set; }

    public QueueNode<T> PrevNode { get; set; }
}
