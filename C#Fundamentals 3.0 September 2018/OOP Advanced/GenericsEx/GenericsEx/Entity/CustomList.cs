using GenericsEx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericsEx.Entity
{
    public class CustomList<T> : ICustomList<T> where T : IComparable<T>
    {
        public CustomList()
        {
            Arr = new List<T>();
        }

        public List<T> Arr { get; set; }

        public void Add(T element)
        {
            Arr.Add(element);
        }

        public bool Contains(T element)
        {
            return Arr.Contains(element);
        }

        public int CountGreaterThan(T element)
        {
            int count = 0;

            foreach (var c in Arr)
            {
                if (element.CompareTo(c) < 0)
                {
                    count++;
                }
            }
            return count;
        }

        public T Max()
        {
            T max = Arr[0];

            foreach (var a in Arr)
            {
                if (max.CompareTo(a) == -1)
                {
                    max = a;
                }
            }

            return max;
        }

        public T Min()
        {
            T max = Arr[0];

            foreach (var a in Arr)
            {
                if (max.CompareTo(a) == 1)
                {
                    max = a;
                }
            }

            return max;
        }

        public T Remove(int index)
        {
            T element = Arr[index];
            Arr.RemoveAt(index);

            return element;
        }

        public void Swap(int index1, int index2)
        {
            T temp = Arr[index1];
            Arr[index1] = Arr[index2];
            Arr[index2] = temp;
        }

        public void Sort()
        {
            foreach (var b in Arr)
            {

            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var a in Arr)
            {
                builder.AppendLine(a.ToString());
            }

            return builder.ToString().Trim();
        }
    }
}
