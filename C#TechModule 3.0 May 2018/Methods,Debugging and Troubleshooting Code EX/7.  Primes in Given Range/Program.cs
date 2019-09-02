using System;
using System.Collections.Generic;

namespace _7.__Primes_in_Given_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            Primes(a, b);
        }
        static List<int> Primes(int a, int b)
        {
            
            for (int i = a; i <= b; i++)
            {

                switch (i)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        add(i);
                        break;
                    default:
                        if (i % 2 == 0)
                        {
                            break;
                        }
                        else
                        {
                          result =$"{i}, ";
                        }
                        break;
                }
            }
            return lis;
        }
    }
}
