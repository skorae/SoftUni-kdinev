using System;
using System.Linq;

namespace Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int countLongest = 0;
            int numLongest = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int tempCountLongest = 0;
                int tempNumLongest = 0;

                if (arr[i] == arr[i + 1])
                {
                    for (int y = i; y < arr.Length; y++)
                    {
                        if (arr[i] == arr[y])
                        {
                            tempCountLongest++;
                            tempNumLongest = arr[i];
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (tempCountLongest > countLongest)
                {
                    countLongest = tempCountLongest;
                    numLongest = tempNumLongest;
                }
            }

            for (int i = 0; i < countLongest; i++)
            {
                Console.Write($"{numLongest} ");
            }
        }
    }
}
