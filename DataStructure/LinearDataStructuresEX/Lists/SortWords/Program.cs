using System;
using System.Linq;

namespace SortWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(" ", Console.ReadLine().Split().ToList().OrderBy(x => x)));
        }
    }
}
