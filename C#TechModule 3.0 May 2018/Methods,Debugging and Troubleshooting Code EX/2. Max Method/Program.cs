using System;

namespace _2._Max_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int result = GetMax(a,b,c);

            Console.WriteLine(result);
        }
        static int GetMax(int a, int b, int c)
        {
            int result = Math.Max(a,Math.Max(b, c));
            return result;
        }
    }
}
