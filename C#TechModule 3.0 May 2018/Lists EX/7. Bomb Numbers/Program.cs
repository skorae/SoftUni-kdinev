using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> bombProp = Console.ReadLine().Split().Select(int.Parse).ToList();

            int sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bombProp[0])
                {
                    if (i - bombProp[1] >= 0)
                    {
                        for (int y = 1; y <= bombProp[1]; y++)
                        {
                            numbers.RemoveAt(i - 1);
                            i--;
                        }
                    }
                    else
                    {
                        for (int y = 0; y < i; y++)
                        {
                            numbers.RemoveAt(y);
                            i--;
                        }
                    }
                    if (i + bombProp[1] <= numbers.Count - 1)
                    {
                        for (int y = 1; y <= bombProp[1]; y++)
                        {
                            numbers.RemoveAt(i + 1);
                        }
                    }
                    else
                    {
                        for (int y = i; y < numbers.Count - 1; y++)
                        {
                            numbers.RemoveAt(i + 1);
                            i--;
                        }
                    }
                    numbers.Remove(bombProp[0]);
                    i--;
                }
            }
            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }
            Console.WriteLine(sum);
        }
    }
}
