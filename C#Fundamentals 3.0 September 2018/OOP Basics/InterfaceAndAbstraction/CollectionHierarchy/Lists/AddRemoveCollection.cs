using CollectionHierarchy.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CollectionHierarchy.Lists
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        public AddRemoveCollection()
        {
            this.AddRemove = new List<string>(100);
        }

        public List<string> AddRemove { get; set; }

        public virtual void Add(string[] arr)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var item in arr)
            {
                this.AddRemove.Insert(0,item);
                builder.Append($"{0} ");
            }
          
            Console.WriteLine(builder.ToString().Trim());
        }

        public virtual void Remove(int n)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                builder.Append($"{AddRemove[AddRemove.Count - 1]} ");
                this.AddRemove.RemoveAt(AddRemove.Count - 1);
            }

            Console.WriteLine(builder.ToString().Trim());
        }
    }
}
