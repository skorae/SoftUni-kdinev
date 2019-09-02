using System;
using System.Collections.Generic;
using System.Text;

namespace ComparingObjects
{
    public class Person<T> where T : IComparable<T>
    {
        public Person()
        {
            People = new List<T>();
        }

        public List<T> People { get; set; }

        public int Compare(int index)
        {
            T person = People[index - 1];
            int count = 0;

            foreach (var p in People)
            {
                if (person.CompareTo(p) == 0)
                {
                    count++;
                }
            }

            if (count < 2)
            {
                throw new ArgumentException("No matches");
            }

            return count;
        }

    }
}
