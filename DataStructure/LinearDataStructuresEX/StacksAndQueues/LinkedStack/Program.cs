using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        LinkedStack<int> stack = new LinkedStack<int>();

        for (int i = 1; i < 4; i++)
        {
            stack.Push(i);
        }

        Console.WriteLine(string.Join(" ", stack.ToArray()));
    }
}
