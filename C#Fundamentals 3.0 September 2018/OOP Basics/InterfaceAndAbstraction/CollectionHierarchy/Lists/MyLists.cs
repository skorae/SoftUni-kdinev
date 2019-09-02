using CollectionHierarchy.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionHierarchy.Lists
{
    public class MyLists : AddRemoveCollection, IMyList
    {
        public MyLists()
        {
            this.MyList = new List<string>(100);
            this.Used = 0;
        }
        public List<string> MyList { get; set; }

        public int Used { get; set; }

        public override void Add(string[] arr)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var item in arr)
            {
                this.MyList.Insert(0, item);
                builder.Append($"{0} ");
                this.Used++;
            }
           
            Console.WriteLine(builder.ToString().Trim());
        }

        public override void Remove(int n)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                builder.Append($"{MyList[0]} ");
                this.MyList.RemoveAt(0);
                this.Used--;
            }

            Console.WriteLine(builder.ToString().Trim());
        }
    }
}
