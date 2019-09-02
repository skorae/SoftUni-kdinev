using System;
using System.Linq;

namespace _5._Compare_Char_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] firstArr = Console.ReadLine().Split().Select(char.Parse).ToArray();
            char[] secondArr = Console.ReadLine().Split().Select(char.Parse).ToArray();

            int loopValue = Math.Min(firstArr.Length, secondArr.Length);
            for (int i = 0; i < loopValue; i++)
            {
                if (firstArr[i] < secondArr[i])
                {
                    Console.WriteLine(string.Join("", firstArr));
                    Console.WriteLine(string.Join("", secondArr));
                    break;
                }
                else if (secondArr[i] < firstArr[i])
                {
                    Console.WriteLine(string.Join("", secondArr));
                    Console.WriteLine(string.Join("", firstArr));
                    break;
                }
                else if (firstArr[i] == secondArr[i])
                {
                    if (i == loopValue - 1)
                    {
                        if (firstArr.Length < secondArr.Length)
                        {
                            Console.WriteLine(string.Join("", firstArr));
                            Console.WriteLine(string.Join("", secondArr));
                            break;
                        }
                        else if (secondArr.Length< firstArr.Length)
                        {
                            Console.WriteLine(string.Join("", secondArr));
                            Console.WriteLine(string.Join("", firstArr));
                            break;
                        }
                        else
                        {
                            Console.WriteLine(string.Join("", firstArr));
                            Console.WriteLine(string.Join("", secondArr));
                            break;
                        }
                    }
                }
                
                

            }
        }
    }
}
