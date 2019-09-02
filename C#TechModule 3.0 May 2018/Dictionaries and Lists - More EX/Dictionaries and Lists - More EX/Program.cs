using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionaries_and_Lists___More_EX
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> hours = Console.ReadLine().Split().ToList();
            List<string> result = new List<string>();

            foreach (var item in hours.OrderBy(x => x))
            {
                result.Add(item);
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
