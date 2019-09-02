using System;
using System.Collections.Generic;

namespace Balanced_Parantheses
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] arr = Console.ReadLine().ToCharArray();

            Stack<char> stack = new Stack<char>();

            if (arr.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            foreach (var item in arr)
            {
                if (item == ' ')
                {
                    continue;
                }

                switch (item)
                {
                    case '(':
                    case '[':
                    case '{':
                        stack.Push(item);
                        break;
                    case ')':
                        if (stack.Peek() == '(') 
                        {
                            stack.Pop();
                            continue;
                        }
                        Console.WriteLine($"NO");
                        return;
                    case ']':
                        if (stack.Peek() == '[')
                        {
                            stack.Pop();
                            continue;
                        }
                        Console.WriteLine($"NO");
                        return;
                    case '}':
                        if (stack.Peek() == '{')
                        {
                            stack.Pop();
                            continue;
                        }
                        Console.WriteLine($"NO");
                        return;
                }
            }
            Console.WriteLine("YES");

        }
    }
}
