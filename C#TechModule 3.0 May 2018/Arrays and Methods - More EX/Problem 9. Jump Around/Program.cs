using System;
using System.Linq;

namespace Problem_9._Jump_Around
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int sum = numbers[0];
            int index = 0;

            while (index < numbers.Length && index >= 0)
            {
                if (index + numbers[index] <= numbers.Length -1)
                {
                    index += numbers[index];
                    sum += numbers[index];
                }
                else if (index + numbers[index] >= numbers.Length - 1 && index - numbers[index] >= 0)
                {
                    index -= numbers[index];
                    sum += numbers[index];
                }
                else
                {
                    Console.WriteLine(sum);
                    return;
                }
            }
        }
    }
}
