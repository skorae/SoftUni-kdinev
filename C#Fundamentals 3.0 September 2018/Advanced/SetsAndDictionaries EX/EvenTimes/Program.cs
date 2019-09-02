using System;
using System.Collections.Generic;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (dic.ContainsKey(num) == false)
                {
                    dic.Add(num, new List<int>());
                    dic[num].Add(num);
                }
                else
                {
                    dic[num].Add(num);
                }
            }

            foreach (var key in dic.Keys)
            {
                if (dic[key].Count % 2 == 0)
                {
                    Console.WriteLine(key);
                }
            }
        }
    }
}
