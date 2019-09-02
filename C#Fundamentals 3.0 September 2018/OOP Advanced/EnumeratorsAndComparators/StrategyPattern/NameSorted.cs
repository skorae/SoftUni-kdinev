using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyPattern
{
    public class NameSorted : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            var result = x.Name.Length.CompareTo(y.Name.Length);

            if (result == 0)
            {
                result = x.Name.First().ToString().CompareTo(y.Name.First().ToString());
            }

            return result;
        }
    }
}
