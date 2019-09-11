using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayBasedStack
{
    public class ArrayStack<T>
    {
        private const int InitialCapacity = 16;

        private T[] elements;

        public ArrayStack(int capacity = InitialCapacity)
        {
            this.elements = new T[capacity];
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.Count + 1 > this.elements.Length)
            {
                this.Grow();
            }

            this.elements[this.Count++] = element;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var result = this.elements[this.Count - 1];
            this.elements[this.Count] = default(T);

            this.Count--;

            return result;
        }

        public T[] ToArray()
        {
            var result = new T[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                result[i] = this.elements[this.Count - 1 - i];
            }

            return result;
        }

        private void Grow()
        {
            var newArrayStack = new T[this.elements.Length * 2];

            for (int i = 0; i < this.Count; i++)
            {
                newArrayStack[i] = this.elements[i];
            }

            this.elements = newArrayStack;
        }
    }
}
