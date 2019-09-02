using System;
using System.Collections;
using System.Collections.Generic;

namespace ListIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private readonly List<T> items;
        private int current = 0;

        public ListyIterator(params T[] items)
        {
            this.items = new List<T>();
            this.items.AddRange(items);
        }

        public bool Move()
        {
            if (HasNext())
            {
                current++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            return current + 1 <= items.Count - 1;
        }

        public T Print()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation");
            }
            return items[current];
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < items.Count; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
