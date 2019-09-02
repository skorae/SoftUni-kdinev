using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random random = new Random();

            int index = random.Next(0, Count - 1);

            string temp = this.ElementAt(index);
            this.RemoveAt(index);

            return temp;
        }
    }
}
