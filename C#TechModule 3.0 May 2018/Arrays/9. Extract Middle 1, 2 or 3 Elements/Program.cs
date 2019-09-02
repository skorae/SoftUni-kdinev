using System;
using System.Linq;

namespace _9._Extract_Middle_1__2_or_3_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
           
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            if (numbers.Length <= 3)
            {
                Console.WriteLine("{ " + $"{numbers[numbers.Length / 2]} " + "}");
            }
            else if (numbers.Length % 2 == 0)
            {
                Console.WriteLine("{ " + $"{numbers[numbers.Length  / 2 - 1]} " +
                    $"{numbers[numbers.Length / 2]}" + " }");
            }
            else
            {
                Console.WriteLine("{ " + $"{numbers[numbers.Length / 2 - 1]} " +
                    $"{numbers[numbers.Length / 2]} " +
                    $"{numbers[numbers.Length / 2 + 1]}" + " }");
            }


        }
    }
}
