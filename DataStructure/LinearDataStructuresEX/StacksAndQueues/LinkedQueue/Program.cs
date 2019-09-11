using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var queue = new LinkedQueue<int>();

        for (int i = 1; i < 4; i++)
        {
            queue.Enqueue(i);
        }

        Console.WriteLine(string.Join(" ", queue.ToArray()));
    }
}