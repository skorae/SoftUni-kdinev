using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_5._Magic_Exchangeable_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string first = text[0];
            string second = text[1];

            Dictionary<char, char> chars = new Dictionary<char, char>();
            int count = 0;

            if (first.Length <= second.Length)
            {
                for (int i = 0; i < first.Length; i++)
                {
                    if (chars.ContainsKey(first[i]) == false)
                    {
                        chars.Add(first[i], second[i]);
                    }
                    else if (chars.ContainsValue(second[i]) == false)
                    {
                        Console.WriteLine("false");
                        return;
                    }
                }
                for (int i = 0; i < second.Length; i++)
                {
                    if (chars.ContainsValue(second[i]) == false)
                    {
                        Console.WriteLine("false");
                        return;
                    }
                }
                Console.WriteLine("true");
            }
            else
            {
                for (int i = 0; i < second.Length; i++)
                {
                    if (chars.ContainsKey(second[i]) == false)
                    {
                        chars.Add(second[i], first[i]);
                    }
                    else if (chars.ContainsValue(first[i]) == false)
                    {
                        Console.WriteLine("flase");
                        return;
                    }
                }
                for (int i = 0; i < first.Length; i++)
                {
                    if (chars.ContainsValue(first[i]) == false)
                    {
                        Console.WriteLine("false");
                        return;
                    }
                }
                Console.WriteLine("true");
            }
        }
    }
}
