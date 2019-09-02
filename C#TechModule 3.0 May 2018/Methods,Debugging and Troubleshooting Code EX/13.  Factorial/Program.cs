using System;
using System.Numerics;

namespace _13.__Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger n = BigInteger.Parse(Console.ReadLine());
            BigInteger factoriel = Factoriel(n);
            int count = ZerosCount(factoriel);

            Console.WriteLine($"{count}");
        }
        static BigInteger Factoriel(BigInteger n)
        {
            BigInteger factoriel = 1;
            for (int i = 1; i <= n; i++)
            {
                factoriel *= i;
            }
            return factoriel;
        }
        static int ZerosCount(BigInteger factoriel)
        {
            BigInteger num = factoriel;
            BigInteger temp = 0;
            int count = 0;
            while (temp == 0)
            {
                temp = num % 10;
                num /= 10;
                if (temp == 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
