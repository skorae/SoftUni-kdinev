using CollectionHierarchy.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionHierarchy.Lists
{
   public class AddCollections : IAddCollection
    {
        public AddCollections()
        {
            this.AddCollection = new List<string>(100);
        }
        public List<string> AddCollection { get; set; }

        public void Add(string[] arr)
        {
            StringBuilder builder = new StringBuilder();
            int count = 0;
            foreach (var item in arr)
            {
                this.AddCollection.Add(item);
                builder.Append($"{count++} ");
            }
           
            Console.WriteLine(builder.ToString().Trim());
        }
    }
}
