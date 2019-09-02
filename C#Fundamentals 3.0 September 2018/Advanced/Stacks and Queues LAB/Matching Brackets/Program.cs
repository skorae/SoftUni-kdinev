using System;
using System.Collections.Generic;
using System.Linq;

namespace Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();

            List<char> arr = new List<char>();

            for (int i = 0; i < a.Length; i++)
            {
                arr.Add(a[i]);
            }

            Stack<List<char>> stack = new Stack<List<char>>();

            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] == '(')
                {
                    Arr(arr, arr[i],stack);
                    break;
                }
            }
            while (stack.Count != 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }

        private static void Arr(List<char> arr, char v, Stack<List<char>> stack)
        {
            List<char> c = new List<char>();
            c.Add('(');

            for (int i = arr.IndexOf(v) + 1; i < arr.Count; i++)
            {
                switch (arr[i])
                {
                    case ')':
                        c.Add(arr[i]);
                        stack.Push(c);
                        break;
                    case '(':
                        Arr(arr, arr[i], stack);
                        break;    
                    default:
                        c.Add(arr[i]);
                        break;
                }
            }
        }
    }
}
