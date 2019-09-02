using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CustomStack
{
    public class StackOfStrings : List<string>
    {
        public List<string> List { get; set; }
        
        public void Push(string element)
        {
            Add(element);
        }

        public string Pop()
        {
            if (IsEmpty())
            {
                throw new ArgumentException("Stack is Empty");
            }
            string temp = this.Last();
            Remove(this.Last());

            return temp;
        }

        public string Peek()
        {
            string temp = this.Last();

            return temp;
        }

        public bool IsEmpty()
        {
            return Count < 1;
        }
    }
}
