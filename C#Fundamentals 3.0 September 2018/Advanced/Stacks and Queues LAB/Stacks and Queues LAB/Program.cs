using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_and_Queues_LAB
{
    class Program
    {
        static void Main(string[] args)
        {
            string arr = Console.ReadLine();

            Stack<char> stack = new Stack<char>(arr.ToCharArray());
            while (stack.Count != 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
