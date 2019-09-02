using System;
using System.Linq;

namespace _6._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int digit = 0;
            int max = 1;
            
            for (int i = 0; i < sequence.Length - 1; i++)
            {
                int longest = 0;
                int currentIndex = sequence[i];
                for (int j = i; j < sequence.Length; j++)
                {
                    if (sequence[i] == sequence[j])
                    {
                        longest++;
                        if (max < longest)
                        {
                            max = longest;
                            digit = currentIndex;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            for (int i = 0; i < max; i++)
            {
                Console.Write(digit + " ");
            }
        }
    }
}
