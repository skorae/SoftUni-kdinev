using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Problem_1._Convert_from_Base_10_to_Base_N
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();

            BigInteger baseNum = BigInteger.Parse(input[0]);
            char[] numToConvert = input[1].ToCharArray();
           
            BigInteger temp = 0;

            for (int i = numToConvert.Length; i > 0; i--)
            {
                BigInteger power = 1;
                if (i - 1 == 0)
                {
                    power = 1;
                }
                else
                {
                    for (int j = 0; j < i - 1; j++)
                    {
                        power *= baseNum;
                    }
                }
                temp += BigInteger.Parse(numToConvert[numToConvert.Length - i].ToString()) * power;
                
            }

            Console.WriteLine(temp);
        }
    }
}
