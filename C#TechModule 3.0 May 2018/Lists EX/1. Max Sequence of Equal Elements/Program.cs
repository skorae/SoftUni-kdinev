using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();

            int bestLenght = 1;
            int curentLenght = 1;
            int bestIndex = 0;
            for (int i = 1; i < input.Count; i++)
            {


                if (input[i] == input[i - 1])
                {
                    curentLenght++;

                    if (curentLenght > bestLenght)
                    {
                        bestLenght = curentLenght;
                        bestIndex = i;
                    }
                }
                else
                {
                    curentLenght = 1;
                }
            }
            for (int i = bestIndex; i > bestIndex - bestLenght; i--)
            {
                Console.Write(input[i] + " ");
            }
        }
    }
}
