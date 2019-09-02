using System;

namespace Magic_Letter
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            char c = char.Parse(Console.ReadLine());

            
            for (char i = first; i <= second; i++)
            {
                for (char y = first; y <= second; y++)
                {
                    for (char j = first; j <= second; j++)
                    {
                        
                        if (i != c && y != c && j != c)
                        {
                            Console.Write($"{i}{y}{j} ", i.ToString(), y.ToString(),j.ToString());
                        }
                    }
                }
            }
        }
    }
}
