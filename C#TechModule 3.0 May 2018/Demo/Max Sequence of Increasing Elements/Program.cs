using System;
using System.Linq;

namespace Max_Sequence_of_Increasing_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int countLongest = 0;
            string numLongest = "";

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int tempCountLongest = 0;
                string tempNumLongest = "";

                if (arr[i+ 1] == arr[i] + 1)
                {
                    tempCountLongest = 1;
                    tempNumLongest += arr[i] + " ";
                    for (int y = i + 1; y < arr.Length; y++)
                    {
                        if (arr[y] == arr[y - 1] + 1)
                        {
                            tempCountLongest++;
                            tempNumLongest += arr[y] + " ";
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

            Console.WriteLine(numLongest);
        }
    }
}
