using System;
using System.Linq;

namespace _8._Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] condenced = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                condenced[i] += numbers[i];
            }


            if (numbers.Length > 0)
            {
                while (condenced.Length > 1)
                {
                    int[] sum = new int[condenced.Length - 1];
                    for (int i = 0; i < condenced.Length - 1; i++)
                    {
                        sum[i] += condenced[i] + condenced[i + 1];
                    }
                    condenced = sum;
                }
                Console.WriteLine($"{condenced[0]}");
            }
            else
            {
                Console.WriteLine($"{numbers[0]}");
            }


        }
    }
}
