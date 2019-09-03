using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ImplementTheDataStructureReversedList
{
    public class ReversedList<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 2;

        private T[] arr;

        public ReversedList(int capacity = InitialCapacity)
        {
            this.arr = new T[capacity];
        }

        public int Count { get; private set; }

        public int Capacity => this.arr.Length;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.arr[this.Count - index - 1];
            }

            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                this.arr[this.Count - index - 1] = value;
            }
        }

        public void Add(T element)
        {
            if (this.Count == this.arr.Length)
            {
                this.Resize();
            }

            this.arr[Count++] = element;
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            var element = this.arr[this.Count - index - 1];

            for (int i = this.Count - index; i < this.Count; i++)
            {
                this.arr[i - 1] = this.arr[i];
            }

            this.Count--;

            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Resize()
        {
            Array.Resize(ref this.arr, this.Count * 2);
        }
    }
}