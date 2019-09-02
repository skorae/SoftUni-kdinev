using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GenericsEx.Entity
{
    public class Box<T> where T : IComparable<T>
    {
        public Box()
        {
            Text = new List<T>();
        }

        public List<T> Text { get; set; }

        public int Compare(T box)
        {
            int count = 0;

            foreach (var b in this.Text)
            {
                if (box.CompareTo(b) < 0)
                {
                    count++;
                }
            }
            return count;
        }

        public override string ToString()
        {
            string result = $"{typeof(T)}: {this.Text}";

            return result;
        }

        
    }
}
