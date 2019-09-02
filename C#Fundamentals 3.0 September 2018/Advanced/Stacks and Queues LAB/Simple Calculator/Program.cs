using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split(" ");

            Stack<string> stack = new Stack<string>(arr.Reverse());

            while (stack.Count > 1)
            {
                int a = int.Parse(stack.Pop());
                string @operator = stack.Pop();
                int b = int.Parse(stack.Pop());

                switch (@operator)
                {
                    case "+":
                        stack.Push((a + b).ToString());
                        break;
                    case "-":
                        stack.Push((a - b).ToString());
                        break;
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
