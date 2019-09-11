using System;
using System.Collections.Generic;
using System.Linq;

namespace SequenceN_M
{
    class Program
    {
        private class Item
        {
            public int Value { get; }
            public Item Previous { get; }

            public Item(int value, Item previous = null)
            {
                Value = value;
                Previous = previous;
            }
        }

        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = arr[0];
            int target = arr[1];

            var queue = new Queue<Item>();
            queue.Enqueue(new Item(n));

            while (queue.Count > 0)
            {
                var item = queue.Dequeue();

                if (item.Value < target)
                {
                    queue.Enqueue(new Item(item.Value + 1, item));
                    queue.Enqueue(new Item(item.Value + 2, item));
                    queue.Enqueue(new Item(item.Value * 2, item));
                }
                else if (item.Value == target)
                {
                    var list = new LinkedList<int>();

                    while (item != null)
                    {
                        list.AddFirst(item.Value);
                        item = item.Previous;
                    }

                    Console.WriteLine(string.Join(" -> ", list));

                    break;
                }
            }
        }
    }
}
