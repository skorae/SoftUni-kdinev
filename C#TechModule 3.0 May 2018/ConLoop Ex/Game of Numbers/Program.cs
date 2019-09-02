using System;

namespace Game_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int magic = int.Parse(Console.ReadLine());
            int count = 0;
            string result = "";
            bool isFound = false;

            for (int i = n; i <= m; i++)
             {
                for (int y = n; y <= m; y++)
                {
                    count++;

                    if ((i + y) == magic)
                    {
                        isFound = true;
                        result = $"{i} + {y}";
                    }
                }
            }
            if (isFound)
            {
                Console.WriteLine($"Number found! {result} = {magic}");
            }
            else
            {
                Console.WriteLine($"{count} combinations - neither equals {magic}");
            }
        }
    }
}
