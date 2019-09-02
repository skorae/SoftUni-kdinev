using System;

namespace Count_the_Integers
{
    class Program
    {
        static void Main(string[] args)
        {

            int count = 0;

            while (true)
            {
                count++;
                try
                {
                    int n = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine(count - 1);
                    return;
                }
            }
        }
    }
}