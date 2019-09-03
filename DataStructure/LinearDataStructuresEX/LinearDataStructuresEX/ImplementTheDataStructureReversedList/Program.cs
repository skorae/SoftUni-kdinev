using System;

namespace ImplementTheDataStructureReversedList
{
    class Program
    {
        static void Main(string[] args)
        {
            ReversedList<int> arr = new ReversedList<int>();

            for (int i = 0; i < 10; i++)
            {
                arr.Add(i);
            }

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
