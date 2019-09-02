using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustumStack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private readonly List<T> stack;

        public MyStack()
        {
            stack = new List<T>();
        }

        public void Push(T[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                stack.Insert(0, elements[i]);
            }
        }

        public T Pop()
        {
            if (stack.Count == 0)
            {
                throw new ArgumentException($"No elements");
            }

            T element = stack[0];
            stack.RemoveAt(0);
            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = stack.Count - 1; i >= 0; i--)
            {
                yield return stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var item in stack)
            {
                builder.AppendLine($"{item}");
            }

            return builder.ToString().Trim();
        }
    }
}
